package com.example.wearether.adapters;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.databinding.DataBindingUtil;
import androidx.navigation.Navigation;
import androidx.navigation.fragment.NavHostFragment;
import androidx.recyclerview.widget.RecyclerView;
import com.example.wearether.R;
import com.example.wearether.data.DbHelper;
import com.example.wearether.databinding.PlaceItemBinding;
import com.example.wearether.models.pojo.Place;
import com.example.wearether.ui.forecasts.ForecastsFragment;

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
    private final DbHelper dbHelper = DbHelper.getInstance();
    static private List<Place> placesList;
    private boolean isFavoritesFragment;
    private LayoutInflater inflater;

    public ListPlacesAdapter(Context context, List<Place> placesList, boolean isFavoritesFragment){
        inflater = LayoutInflater.from(context);
        setPlacesList(placesList);
        this.isFavoritesFragment = isFavoritesFragment;
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

        if(!isFavoritesFragment) {
            val isExistCity = dbHelper.isExistPlaceId(place.key);

            setImageIbToAddDelToFavorites(holder, (isExistCity)
                    ? android.R.drawable.star_big_on
                    : android.R.drawable.star_big_off);
        }
        else{
            setImageIbToAddDelToFavorites(holder, android.R.drawable.ic_delete);
        }

        holder.binding.llPlace.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                val bundle = new Bundle();
                bundle.putString(ForecastsFragment.PLACE_ID, place.key);
                bundle.putString(ForecastsFragment.PLACE_NAME, place.localizedName);
                val nCtrl = Navigation.findNavController(v);
                nCtrl.navigate(R.id.nav_forecasts, bundle);
            }
        });
        holder.binding.ibAddDelToFavorites.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Integer icon = null;

                if(!isFavoritesFragment) {
                    val isExCity = dbHelper.isExistPlaceId(place.key);

                    if (isExCity) {
                        icon = android.R.drawable.star_big_off;
                        dbHelper.delCity(place.key);
                    } else {
                        icon = android.R.drawable.star_big_on;
                        dbHelper.addCity(place);
                    }

                    setImageIbToAddDelToFavorites(holder, icon);
                }
                else{
                    notifyItemRemoved(placesList.indexOf(place));
                    placesList.remove(place);
                    dbHelper.delCity(place.key);
                }
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
        this.placesList = placesList;
        notifyDataSetChanged();
    }
}