package com.example.wearether.ui.forecasts;

import android.os.AsyncTask;
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
import com.example.wearether.adapters.DailyForecastAdapter;
import com.example.wearether.dialogs.NetworkErrorDialog;
import com.example.wearether.models.pojo.DailyForecast;
import com.example.wearether.models.pojo.WeatherForecast;
import com.example.wearether.retrofit.WeatherServiceHelper;

import java.util.ArrayList;
import java.util.List;

import lombok.val;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ForecastsFragment extends Fragment {
    public static final String PLACE_ID = "PlaceId";
    public static final String PLACE_NAME = "PlaceName";
    private String mPlaceId;
    private String mPlaceName;
    private View parentView;
    private RecyclerView rvDays;
    private ForecastsViewModel viewModel;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        if (getArguments() != null) {
            mPlaceName = getArguments().getString(PLACE_NAME);
            mPlaceId = getArguments().getString(PLACE_ID);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        parentView = inflater.inflate(R.layout.fragment_forecasts, container, false);
        rvDays = parentView.findViewById(R.id.rvDays);
        setupRecyclerView(rvDays);

        viewModel = ViewModelProviders.of(this)
                .get(ForecastsViewModel.class);

        viewModel.setText(mPlaceName);
        viewModel.setListForecasts(new ArrayList<>());
        viewModel.getText().observe(getViewLifecycleOwner(), new Observer<String>() {
            @Override
            public void onChanged(String s) {
                final TextView tvPlaceName = parentView.findViewById(R.id.tvPlaceName);
                tvPlaceName.setText(s);
            }
        });
        viewModel.getLiveListForecasts().observe(getViewLifecycleOwner(), new Observer<List<DailyForecast>>() {
            @Override
            public void onChanged(List<DailyForecast> dailyForecastList) {
                val adapter = (DailyForecastAdapter) rvDays.getAdapter();
                adapter.setForecastsList(dailyForecastList);
            }
        });

        //Асинхронное заполнение формы
        new GetForecastTask().execute(mPlaceId);

        return parentView;
    }

    private void setupRecyclerView(RecyclerView rv){
        val adapter = new DailyForecastAdapter(getActivity(), new ArrayList<>());
        rv.setHasFixedSize(true);
        rv.setItemAnimator(new DefaultItemAnimator());
        rv.setLayoutManager(new LinearLayoutManager(getActivity()));
        rvDays.setAdapter(adapter);
    }

    private class GetForecastTask extends AsyncTask<String, Void, Void> {
        @Override
        protected Void doInBackground(String... searchText) {
            WeatherServiceHelper wsh = WeatherServiceHelper.getInstance();
            wsh.getWeatherService().getForecastByPlaceId(mPlaceId, "ru-ua",
                    WeatherServiceHelper.apiKey, "true")
                    .enqueue(new Callback<WeatherForecast>() {
                        @Override
                        public void onResponse(Call<WeatherForecast> call,
                                               Response<WeatherForecast> response) {
                            final WeatherForecast wf = response.body();
                            viewModel.setListForecasts(wf.getDailyForecasts());
                        }

                        @Override
                        public void onFailure(Call<WeatherForecast> call, Throwable t) {
                            new NetworkErrorDialog().show(getParentFragmentManager(), getTag());
                        }
                    });

            return null;
        }
    }
}
