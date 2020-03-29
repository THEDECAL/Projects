package com.example.wearether.ui.weatherByCity;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class WeatherByCityViewModel extends ViewModel {
    private MutableLiveData<String> mText;

    public WeatherByCityViewModel() {
        mText = new MutableLiveData<>();
        mText.setValue("This is weatherbycity fragment");
    }

    public LiveData<String> getText() { return mText; }

    public void setText(String value) {
        mText.setValue(value);
    }
}
