package com.example.wearether.ui.favorites;

import android.content.Context;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;
import androidx.recyclerview.widget.DefaultItemAnimator;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.wearether.R;
import com.example.wearether.adapters.ListPlacesAdapter;
import com.example.wearether.data.DbHelper;
import com.example.wearether.models.pojo.Place;
import com.example.wearether.ui.home.HomeViewModel;

import java.util.List;

import lombok.val;

public class FavoritesFragment extends Fragment {
    private final DbHelper dbHelper = DbHelper.getInstance();
    private LayoutInflater inflater;
    private View parentView;
    private FavoritesViewModel favoritesViewModel;
    private RecyclerView rvFavoritePlaces;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        dbHelper.open();
        this.inflater = inflater;
        parentView = inflater.inflate(R.layout.fragment_favorites, container, false);
        favoritesViewModel = ViewModelProviders.of(this).get(FavoritesViewModel.class);
        rvFavoritePlaces = parentView.findViewById(R.id.rvFavoritePlaces);
        setupRecyclerView(rvFavoritePlaces);

        val favoritesPlaces = dbHelper.getPlaces();
        favoritesViewModel.setText((favoritesPlaces.size() == 0)
                ? getResources().getString(R.string.default_favorites_message) : "");
        favoritesViewModel.setPlacesList(favoritesPlaces);
        favoritesViewModel.getText().observe(getViewLifecycleOwner(), new Observer<String>() {
            @Override
            public void onChanged(String s) {
                final TextView tvMessage = parentView.findViewById(R.id.tvMessage);
                tvMessage.setText(s);
            }
        });
        favoritesViewModel.getLivePlacesList().observe(getViewLifecycleOwner(), new Observer<List<Place>>() {
            @Override
            public void onChanged(List<Place> places) {
                val listPlacesAdapter = (ListPlacesAdapter)rvFavoritePlaces.getAdapter();
                listPlacesAdapter.setPlacesList(places);
            }
        });

        return parentView;
    }

    private void setupRecyclerView(RecyclerView rv){
        val listPlacesAdapter = new ListPlacesAdapter(getActivity(),
                favoritesViewModel.getLivePlacesList().getValue(),
                true);
        rv.setHasFixedSize(true);
        rv.setItemAnimator(new DefaultItemAnimator());
        rv.setLayoutManager(new LinearLayoutManager(getActivity()));
        rv.setAdapter(listPlacesAdapter);
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        if(dbHelper != null && dbHelper.isOpen())
            dbHelper.close();
    }
}
