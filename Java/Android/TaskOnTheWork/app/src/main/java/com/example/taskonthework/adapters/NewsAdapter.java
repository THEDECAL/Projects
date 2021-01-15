package com.example.taskonthework.adapters;

import android.content.Context;
import android.os.Build;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.annotation.RequiresApi;

import com.example.taskonthework.R;
import com.example.taskonthework.models.pojo.Child;
import com.example.taskonthework.models.pojo.Data_;
import com.example.taskonthework.tools.GetImageTask;

import java.io.Serializable;
import java.util.List;
import java.util.stream.Collectors;

public class NewsAdapter extends ArrayAdapter<Child> implements Serializable {
    public static final int NEWS_ON_PAGE = 7;
    private int currPage = 1;
    private int allPage;

    private final LayoutInflater inflater;
    private final int layout;
    private List<Child> allNewsList;
    private List<Child> currentNewsList;

    @RequiresApi(api = Build.VERSION_CODES.N)
    public NewsAdapter(@NonNull Context context, int resource, @NonNull List<Child> objects) {
        super(context, resource, objects);
        this.allNewsList = objects;
        this.layout = resource;
        this.inflater = LayoutInflater.from(context);
        allPage = (int)Math.
                ceil(new Double(allNewsList.size()) / new Double(NEWS_ON_PAGE));
        setPage(currPage);
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
        final View view = inflater.inflate(layout, parent, false);
        Data_ newsItem =  currentNewsList.get(position).getData();

        try{
            final TextView tvTitle = ((View) view).findViewById(R.id.tvTitle);
            final TextView tvAuthor = view.findViewById(R.id.tvAuthor);
            final TextView tvCommentsCount = view.findViewById(R.id.tvCommentsCount);
            final TextView tvCreateDate = view.findViewById(R.id.tvCreateDate);
            final ImageView ivThumbmnail = view.findViewById(R.id.ivThumbnail);

            //Назначение события увеличения на нажатие по фотографии
//            ivThumbmnail.setOnClickListener(v -> {
//
//            });

            //Ограничение длины заголовка
            String title = newsItem.getTitle();
            tvTitle.setText(title.substring(0, Math.min(title.length(), 50)).concat("..."));

            tvAuthor.setText(newsItem.getAuthor());
            tvCommentsCount.setText("Commments: " + newsItem.getNumComments());

            //Преобразование даты в формат X hours ago
            long createTimeStamp = Double.valueOf(newsItem.getCreatedUtc()).longValue();
            long currentTimestamp = System.currentTimeMillis();

            //Если таймштамп имеет формат из 13 чисел, то сокращаем его до 10
            if(String.valueOf(currentTimestamp).length() > 10)
                currentTimestamp = currentTimestamp / 1000;

            long diff = (currentTimestamp - createTimeStamp) / 60 / 60;

            String date = "";
            if(diff == 0) date = diff + "today...";
            else if(diff <= 24) date = diff + " hours ago...";
            else if(diff > 24) date = (diff / 24) + " days ago...";

            tvCreateDate.setText("Created: " + date);

            //Асинхронная загрузка иконки
            new GetImageTask(ivThumbmnail).execute(newsItem.getThumbnail());
        } catch(Exception e){
            e.getStackTrace();
        }

        return view;
    }



    @RequiresApi(api = Build.VERSION_CODES.N)
    public void Next(){
        //Если страницы дошли до конца переключать на первую
        currPage  = (currPage == allPage) ? 1 : currPage + 1;
        this.currentNewsList = allNewsList.stream()
                .skip((currPage - 1) * NEWS_ON_PAGE)
                .limit(NEWS_ON_PAGE)
                .collect(Collectors.toList());
        notifyDataSetChanged();
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    public void Back(){
        //Если страницы дошли до конца переключать на первую
        currPage  = (currPage == 1) ? allPage : currPage - 1;
        this.currentNewsList = allNewsList.stream()
                .skip((currPage - 1) * NEWS_ON_PAGE)
                .limit(NEWS_ON_PAGE)
                .collect(Collectors.toList());
        notifyDataSetChanged();
    }

    /**
     * Установка конкретной страницы
     * @param pageNumber
     */
    @RequiresApi(api = Build.VERSION_CODES.N)
    public void setPage(int pageNumber){
        currPage = (pageNumber < 1 || pageNumber > allPage)
                ? 1 : pageNumber;
        this.currentNewsList = allNewsList.stream()
                .skip((pageNumber - 1) * NEWS_ON_PAGE)
                .limit(NEWS_ON_PAGE)
                .collect(Collectors.toList());
        notifyDataSetChanged();
    }

    public int getCurretPqge() { return currPage; }
    public int getAllPqge() { return allPage; }

    @Override
    public int getCount() { return currentNewsList.size(); }
}
