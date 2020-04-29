package com.example.wearether.ui.home;

import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;
import androidx.recyclerview.widget.DefaultItemAnimator;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import com.example.wearether.R;
import com.example.wearether.adapters.ListPlacesAdapter;
import com.example.wearether.data.DbHelper;
import com.example.wearether.dialogs.NetworkErrorDialog;
import com.example.wearether.models.pojo.Place;
import com.example.wearether.retrofit.WeatherServiceHelper;

import java.util.List;
import lombok.val;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class HomeFragment extends Fragment {
    private final DbHelper dbHelper = DbHelper.getInstance();
    private static final String ARG_SEARCH_TEXT = "SearchText";
    private HomeViewModel homeViewModel;
    private RecyclerView rvFindedPlaces;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        dbHelper.open();
        val root = inflater.inflate(R.layout.fragment_home, container, false);
        homeViewModel = ViewModelProviders.of(this).get(HomeViewModel.class);
        rvFindedPlaces = root.findViewById(R.id.rvFindedPlaces);
        setupRecyclerView();

        homeViewModel.setText(getResources().getString(R.string.default_search_text));
        homeViewModel.getText().observe(getViewLifecycleOwner(), new Observer<String>() {
            @Override
            public void onChanged(@Nullable String s) {
                final TextView tvSearchResultText = root.findViewById(R.id.tvSearchResultText);
                tvSearchResultText.setText(s);
            }
        });
        homeViewModel.getLivePlacesList().observe(getViewLifecycleOwner(), new Observer<List<Place>>() {
            @Override
            public void onChanged(List<Place> places) {
                val listPlacesAdapter = (ListPlacesAdapter)rvFindedPlaces.getAdapter();
                listPlacesAdapter.setPlacesList(places);
            }
        });

        //Результат поиска
        val searchText = getArguments().getString(ARG_SEARCH_TEXT);
        if(searchText != null && searchText.length() > 0)
            new GetPlacesTask().execute(searchText);

        return root;
    }

    private void setupRecyclerView(){
        val listPlacesAdapter = new ListPlacesAdapter(getActivity(),
                homeViewModel.getLivePlacesList().getValue()
                , false);
        rvFindedPlaces.setHasFixedSize(true);
        rvFindedPlaces.setItemAnimator(new DefaultItemAnimator());
        rvFindedPlaces.setLayoutManager(new LinearLayoutManager(getActivity()));
        rvFindedPlaces.setAdapter(listPlacesAdapter);
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        if(dbHelper != null && dbHelper.isOpen())
            dbHelper.close();
    }

    private class GetPlacesTask extends AsyncTask<String, Void, Void> {
        @Override
        protected Void doInBackground(String... searchText) {
            WeatherServiceHelper wsh = WeatherServiceHelper.getInstance();
            wsh.getWeatherService().getPlacesByQuery(searchText[0], "ru-ua",
                    WeatherServiceHelper.apiKey)
                    .enqueue(new Callback<List<Place>>() {
                        @Override
                        public void onResponse(Call<List<Place>> call, Response<List<Place>> response) {
                            final List<Place> places = response.body();

                            if (places.size() == 0)
                                homeViewModel.setText(getResources().getString(R.string.null_search_result));
                            else
                                homeViewModel.setText("");

                            homeViewModel.setPlacesList(places);
                        }

                        @Override
                        public void onFailure(Call<List<Place>> call, Throwable t) {
                            new NetworkErrorDialog().show(getParentFragmentManager(), getTag());
                        }
                    });

            return null;
        }
    }
}
