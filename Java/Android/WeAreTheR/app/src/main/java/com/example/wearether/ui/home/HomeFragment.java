package com.example.wearether.ui.home;

import android.app.AlertDialog;
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
import com.example.wearether.databinding.FragmentHomeBinding;
import com.example.wearether.models.pojo.Place;
import com.example.wearether.retrofit.WeatherServiceHelper;
import com.google.gson.Gson;
import java.util.ArrayList;
import java.util.List;
import lombok.val;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class HomeFragment extends Fragment {
    static private final List<Place> placesList = new ArrayList<>();

    private DbHelper dbHelper;
    private static final String ARG_SEARCH_TEXT = "SearchText";
    private ListPlacesAdapter listPlacesAdapter;
    private HomeViewModel homeViewModel;
    private FragmentHomeBinding fragmentHomeBinding;

    static public List<Place> getPlacesList(){ return placesList; }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        dbHelper = new DbHelper(getContext());
        dbHelper.open();
        //initListPlaces();
    }

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        val root = inflater.inflate(R.layout.fragment_home, container, false);
        final TextView tvSearchResultText = root.findViewById(R.id.tvSearchResultText);
        final RecyclerView rvFindedPlaces = root.findViewById(R.id.rvFindedPlaces);

        homeViewModel = ViewModelProviders.of(this).get(HomeViewModel.class);
        homeViewModel.setText(getResources().getString(R.string.default_search_text));
        homeViewModel.getText().observe(getViewLifecycleOwner(), new Observer<String>() {
            @Override
            public void onChanged(@Nullable String s) {
                tvSearchResultText.setText(s);
            }
        });
        homeViewModel.getPlacesList().observe(getActivity(), new Observer<List<Place>>() {
            @Override
            public void onChanged(List<Place> places) {
                listPlacesAdapter = new ListPlacesAdapter(getActivity(), dbHelper, placesList);
                rvFindedPlaces.setHasFixedSize(true);
                rvFindedPlaces.setItemAnimator(new DefaultItemAnimator());
                rvFindedPlaces.setLayoutManager(new LinearLayoutManager(getActivity()));
                rvFindedPlaces.setAdapter(listPlacesAdapter);
            }
        });

        //Результат поиска
        val searchText = getArguments().getString(ARG_SEARCH_TEXT);
        if(searchText != null && searchText.length() > 0){
            new SearchPlaceTask().execute(searchText);
        }

        return root;
    }

    private void initListPlaces(){
        val jsonCity = "{\"Version\":1,\"Key\":\"322527\",\"Type\":\"City\",\"Rank\":55,\"LocalizedName\":\"Днепр\",\"EnglishName\":\"Dnepr\",\"PrimaryPostalCode\":\"\",\"Region\":{\"ID\":\"EUR\",\"LocalizedName\":\"Европа\",\"EnglishName\":\"Europe\"},\"Country\":{\"ID\":\"UA\",\"LocalizedName\":\"Украина\",\"EnglishName\":\"Ukraine\"},\"AdministrativeArea\":{\"ID\":\"12\",\"LocalizedName\":\"Днепропетровская\",\"EnglishName\":\"Dnipropetrovs'k\",\"Level\":1,\"LocalizedType\":\"Провинция\",\"EnglishType\":\"Province\",\"CountryID\":\"UA\"},\"TimeZone\":{\"Code\":\"EET\",\"Name\":\"Europe/Kiev\",\"GmtOffset\":2.0,\"IsDaylightSaving\":false,\"NextOffsetChange\":\"2020-03-29T01:00:00Z\"},\"GeoPosition\":{\"Latitude\":48.522,\"Longitude\":36.071,\"Elevation\":{\"Metric\":{\"Value\":132.0,\"Unit\":\"m\",\"UnitType\":5},\"Imperial\":{\"Value\":432.0,\"Unit\":\"ft\",\"UnitType\":0}}},\"IsAlias\":false,\"SupplementalAdminAreas\":[],\"DataSets\":[\"AirQualityCurrentConditions\",\"AirQualityForecasts\"]}";
        val place = new Gson().fromJson(jsonCity, Place.class);
        placesList.add(place);
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        if(dbHelper != null)
            dbHelper.close();
    }

    class SearchPlaceTask extends AsyncTask<String, Void, Void> {
        @Override
        protected Void doInBackground(String... searchText) {
            WeatherServiceHelper wsh = WeatherServiceHelper.getInstance();
            wsh.getWeatherService().getCitiesByQuery(searchText[0], "ru-ua",
                    WeatherServiceHelper.apiKey)
                    .enqueue(new Callback<List<Place>>() {
                        @Override
                        public void onResponse(Call<List<Place>> call, Response<List<Place>> response) {
                            List<Place> places = response.body();

                            if (places.size() == 0)
                                homeViewModel.setText(getResources().getString(R.string.null_search_result));
                            else
                                homeViewModel.setText("");

                            placesList.clear();
                            placesList.addAll(places);
                            homeViewModel.getPlacesList();
                        }

                        @Override
                        public void onFailure(Call<List<Place>> call, Throwable t) {
                            AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(getActivity());
                            dialogBuilder
                                    .setIcon(android.R.drawable.ic_dialog_info)
                                    .setTitle("Внимание")
                                    .setMessage("Не могу соединится с сервером." +
                                            "Проверьте подключение к Интернету...")
                                    .setPositiveButton("Ок", null);
                            AlertDialog alertDialog = dialogBuilder.create();
                            alertDialog.show();
                        }
                    });

            return null;
        }
    }
}
