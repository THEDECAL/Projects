package com.example.wearether.ui.forecasts;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;
import com.example.wearether.models.pojo.DailyForecast;
import java.util.ArrayList;
import java.util.List;

public class ForecastsViewModel extends ViewModel {
    private MutableLiveData<String> mText;
    private MutableLiveData<List<DailyForecast>> mforecastsList;

    public ForecastsViewModel() {
        mText = new MutableLiveData<>();
        mforecastsList = new MutableLiveData<>(new ArrayList<>());
    }

    public LiveData<String> getText() { return mText; }

    public void setText(String value) {
        mText.setValue(value);
    }

    public LiveData<List<DailyForecast>> getLiveListForecasts(){ return mforecastsList; }

    public void setListForecasts(List<DailyForecast> listForecasts){
        mforecastsList.setValue(listForecasts);
    }
}
