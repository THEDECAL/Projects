package com.example.wearether.adapters;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.databinding.DataBindingUtil;
import androidx.recyclerview.widget.RecyclerView;
import com.example.wearether.R;
import com.example.wearether.data.DbHelper;
import com.example.wearether.databinding.PlaceItemBinding;
import com.example.wearether.models.pojo.Place;
import com.example.wearether.ui.favorites.FavoritesFragment;
import com.example.wearether.ui.home.HomeFragment;

import java.util.ArrayList;
import java.util.List;

import lombok.val;

public class ListPlacesAdapter extends RecyclerView.Adapter<ListPlacesAdapter.PlaceHolder> {
    static public class PlaceHolder extends RecyclerView.ViewHolder{
        PlaceItemBinding binding;

        public PlaceHolder(PlaceItemBinding binding){
            super(binding.getRoot());
            this.binding = binding;
        }

        public void bind(Place place){
            binding.setModel(place);
            binding.executePendingBindings();
        }
    }

    static protected DbHelper dbHelper;

    private LayoutInflater inflater;
    private List<Place> placesList = new ArrayList<>();

    public ListPlacesAdapter(Context context, DbHelper dbHelper, List<Place> placesList){
        this.dbHelper = dbHelper;
        inflater = LayoutInflater.from(context);
        setPlacesList(placesList);
    }

    @NonNull
    @Override
    public PlaceHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        PlaceItemBinding binding = DataBindingUtil.inflate(inflater,
                R.layout.place_item, parent, false);
        return new PlaceHolder(binding);
    }

    @Override
    public void onBindViewHolder(@NonNull PlaceHolder holder, int position) {
        val place = placesList.get(position);
        holder.bind(place);

        val isExistCity = dbHelper.isExistPlaceId(place.key);

        setImageIbToAddDelToFavorites(holder, (isExistCity)
                        ? android.R.drawable.star_big_on
                        : android.R.drawable.star_big_off);

        holder.binding.ibAddDelToFavorites.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Integer icon = null;

                if(isExistCity) {
                    icon = android.R.drawable.star_big_off;
                    dbHelper.delCity(place.key);
                }
                else {
                    icon = android.R.drawable.star_big_on;
                    dbHelper.addCity(place);
                }

                setImageIbToAddDelToFavorites(holder, icon);
            }
        });
        holder.binding.llPlace.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                val context = inflater.getContext();
                val intent = new Intent(context, FavoritesFragment.class);
                context.startActivity(intent);
            }
        });
    }

    public void setImageIbToAddDelToFavorites(@NonNull PlaceHolder holder, int imageId){
        val image = inflater.getContext().getResources().getDrawable(imageId);
        holder.binding.ibAddDelToFavorites.setImageDrawable(image);
    }

    @Override
    public int getItemCount() { return placesList.size(); }

    public void setPlacesList(List<Place> placesList){
        this.placesList.clear();
        this.placesList.addAll(placesList);
        notifyDataSetChanged();
    }

    @Override
    public int getItemViewType(int position) {
        return R.layout.place_item;
    }
}