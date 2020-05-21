package com.example.taskonthework;

import androidx.annotation.NonNull;
import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.content.res.Configuration;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.widget.GridView;
import android.widget.ImageButton;
import android.widget.TextView;

import com.example.taskonthework.adapters.NewsAdapter;
import com.example.taskonthework.dialogs.NetworkErrorDialog;
import com.example.taskonthework.models.pojo.Child;
import com.example.taskonthework.models.pojo.RedditData;
import com.google.gson.Gson;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {
    static boolean isNewsDownloaded = false;
    private final String URL_NEWS = "https://www.reddit.com/top.json";
    private final String ADAPTER_KEY = "adapter";
    private final String CURR_PAGE_KEY = "curr_page";
    private List<Child> news;
    //Views
    private PagNavFragment fPagination;
    private GridView gvNews;
    private TextView tvLoadingText;
    private ImageButton ibBack;
    private ImageButton ibNext;
    private TextView tvCurrentPage;
    private TextView tvLastPage;

    @RequiresApi(api = Build.VERSION_CODES.N)
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        initViews();

        new GetNewsTask(gvNews).execute(false);
    }

    public void onSaveInstanceState(@NonNull Bundle outState) {
        super.onSaveInstanceState(outState);
        NewsAdapter adapter = (NewsAdapter) gvNews.getAdapter();
        outState.putSerializable(ADAPTER_KEY, adapter);
    }

    @RequiresApi(api = Build.VERSION_CODES.N)
    @Override
    protected void onRestoreInstanceState(@NonNull Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
        NewsAdapter adapter = (NewsAdapter) savedInstanceState
                .getSerializable(ADAPTER_KEY);
        gvNews.setAdapter(adapter);
        tvCurrentPage.setText(String.valueOf(adapter.getCurretPqge()));
        tvLastPage.setText(String.valueOf(adapter.getAllPqge()));

        //Проверка положения экрана для установки кол-ва колонок в сетке
        int orientation = getResources().getConfiguration().orientation;
        if (orientation == Configuration.ORIENTATION_LANDSCAPE)
            gvNews.setNumColumns(2);
        else
            gvNews.setNumColumns(1);
        gvNews.setAdapter(adapter);
    }

    /**
     * Инициализация видов
     */
    @RequiresApi(api = Build.VERSION_CODES.N)
    protected void initViews(){
        tvLoadingText = findViewById(R.id.tvLoadingText);
        gvNews = findViewById(R.id.gvNews);
        fPagination = (PagNavFragment) getSupportFragmentManager()
                .findFragmentById(R.id.fPagination);

        ibBack = fPagination.getView().findViewById(R.id.ibBack);
        ibNext = fPagination.getView().findViewById(R.id.ibNext);
        tvCurrentPage = fPagination.getView().findViewById(R.id.tvCurrentPage);
        tvLastPage = fPagination.getView().findViewById(R.id.tvLastPage);
    }

    /**
     * Класс для асинхронной загрузки новостей с сайта
     */
    private class GetNewsTask extends AsyncTask<Boolean, Void, List<Child>> {
        private final GridView gridView;
        private NewsAdapter adapter;

        public GetNewsTask(GridView gridView){
            this.gridView = gridView;
            adapter = (NewsAdapter) gridView.getAdapter();
        }

        protected List<Child> doInBackground(Boolean...args){
            final boolean isForceRun = args[0];

            //Для избежания повторной загрузки новостей
            //при повороте экрана, проверяем наличие адаптера
            if(adapter == null || isForceRun) {
                HttpURLConnection urlConnection = null;

                try {
                    final URL url = new URL(URL_NEWS);
                    urlConnection = (HttpURLConnection) url.openConnection();

                    // Проерка успешности соединения
                    if (urlConnection.getResponseCode() == HttpURLConnection.HTTP_OK) {
                        int buffSize = 0;
                        final StringBuilder sb = new StringBuilder();
                        final InputStream is = new BufferedInputStream(urlConnection.getInputStream());
                        BufferedReader reader = new BufferedReader(new InputStreamReader(is));

                        //Получение JSON данных
                        String jsonData;
                        while ((jsonData = reader.readLine()) != null) {
                            sb.append(jsonData);
                        }

                        //Преобразование JSON данных в объект
                        jsonData = sb.toString();
                        List<Child> newsList = new Gson().fromJson(jsonData,
                                RedditData.class).getData().getChildren();

                        return newsList;
                    } else throw new Exception();
                } catch (Exception e) { //В случае исключения показать сообщение об ошибке
                    new NetworkErrorDialog().show(getSupportFragmentManager(),
                            NetworkErrorDialog.class.getName() + "_TAG");
                } finally {
                    if (urlConnection != null)
                        urlConnection.disconnect();
                }
            }
            return new ArrayList<Child>();
        }

        @RequiresApi(api = Build.VERSION_CODES.N)
        protected void onPostExecute(List<Child> newsList) {
            int orientation = getResources().getConfiguration().orientation;
            if (adapter == null) {
                adapter = new NewsAdapter(getApplicationContext(),
                        R.layout.news_item, newsList);
                gridView.setAdapter(adapter);
            }

            //Проверка положения экрана для установки кол-ва колонок в сетке
            if (orientation == Configuration.ORIENTATION_LANDSCAPE)
                gridView.setNumColumns(2);
            else
                gridView.setNumColumns(1);

            tvLoadingText.setText("");

            tvLastPage.setText(String.valueOf(adapter.getAllPqge()));

            ibBack.setOnClickListener(v -> {
                adapter.Back();
                tvCurrentPage.setText(String.valueOf(adapter.getCurretPqge()));
            });
            ibNext.setOnClickListener(v -> {
                adapter.Next();
                tvCurrentPage.setText(String.valueOf(adapter.getCurretPqge()));
            });
        }
    }
}