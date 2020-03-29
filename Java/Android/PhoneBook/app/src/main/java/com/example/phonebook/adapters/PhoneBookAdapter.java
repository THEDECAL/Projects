package com.example.phonebook.adapters;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;

import com.example.phonebook.EntryManageActivity;
import com.example.phonebook.R;
import com.example.phonebook.data.DbHelper;
import com.example.phonebook.models.PhoneBookEntry;
import com.squareup.picasso.Picasso;

import java.util.List;
import java.util.Random;

import lombok.val;
import lombok.var;

public class PhoneBookAdapter extends RecyclerView.Adapter<PhoneBookAdapter.PhoneBookEntryHolder> {
    static public class PhoneBookEntryHolder extends RecyclerView.ViewHolder{
        public ConstraintLayout clEntry;
        public ImageView ivPhoto;
        public TextView tvSName;
        public TextView tvFName;
        public ImageButton ibDel;

        public PhoneBookEntryHolder(@NonNull View itemView) {
            super(itemView);

            clEntry = itemView.findViewById(R.id.clEntry);
            ivPhoto =  itemView.findViewById(R.id.ivPhoto);
            tvSName = itemView.findViewById(R.id.tvSName);
            tvFName = itemView.findViewById(R.id.tvFName);
            ibDel = itemView.findViewById(R.id.ibDel);
        }
    }

    private LayoutInflater inflater;
    private List<PhoneBookEntry> phoneBookEntryList;
    private Random random = new Random();

    public PhoneBookAdapter(Context context, List<PhoneBookEntry> phoneBookEntryList){
        this.phoneBookEntryList = phoneBookEntryList;
        inflater = LayoutInflater.from(context);
    }

    @NonNull
    @Override
    public PhoneBookEntryHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        var view = inflater.inflate(R.layout.entry_item, parent, false);
        return new PhoneBookEntryHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull PhoneBookEntryHolder holder, final int position) {
        final var entry = phoneBookEntryList.get(position);

        //Устанавливаем случайный поворот фотографии и текста
        final int MIN_ROT_DEG = -10, MAX_ROT_DEG = 10;
        val randomRotDegPhoto = random.nextInt
                (MAX_ROT_DEG - MIN_ROT_DEG) + MIN_ROT_DEG;
        holder.ivPhoto.setRotation(randomRotDegPhoto);
        val randomRotDegText = random.nextInt
                (MAX_ROT_DEG/2 - MIN_ROT_DEG/2) + MIN_ROT_DEG/2;
        holder.tvFName.setRotation(randomRotDegText);
        holder.tvSName.setRotation(randomRotDegText);

        if (entry.getPathToPhoto() != null && entry.getPathToPhoto().equals(""))
            holder.ivPhoto.setImageResource(R.drawable.anonymous_logo);
        else{
            try {
                Picasso.get().load(Uri.parse(entry.getPathToPhoto())).into(holder.ivPhoto);
                holder.ivPhoto.setScaleType(ImageView.ScaleType.CENTER_CROP);
            } catch(Exception ex){}
        }

        holder.tvSName.setText(entry.getSname());
        holder.tvFName.setText(entry.getFname());

        //Изменение записи по нажатию
        holder.clEntry.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                val intent = new Intent(inflater.getContext(), EntryManageActivity.class);
                intent.putExtra("entry", entry);
                inflater.getContext().startActivity(intent);
            }
        });

        //Удаление записи
        holder.ibDel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                val dbHelper = new DbHelper(inflater.getContext());
                dbHelper.open();

                phoneBookEntryList.remove(position);
                dbHelper.delEntry(entry.getId());
                notifyItemRemoved(position);
            }
        });
    }

    @Override
    public int getItemCount() { return phoneBookEntryList.size(); }
}
