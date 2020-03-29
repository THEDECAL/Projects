package com.example.wearether.ui.home;
import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import com.example.wearether.models.pojo.Place;

import java.util.List;

public class HomeViewModel extends ViewModel {
    private MutableLiveData<String> mText;
    private MutableLiveData<List<Place>> mPlacesList;

    public HomeViewModel() {
        mText = new MutableLiveData<>();
        mPlacesList = new MutableLiveData<>();
    }

    public LiveData<String> getText() {
        return mText;
    }

    public void setText(String text) {
        mText.setValue(text);
    }

    public void setPlacesList(List<Place> placesList) {
        //mPlacesList.getValue().clear();
        mPlacesList.setValue(placesList);
    }

    public LiveData<List<Place>> getPlacesList() {
        mPlacesList.setValue(HomeFragment.getPlacesList());
        return mPlacesList;
    }
}