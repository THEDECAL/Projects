package com.example.wearether.ui.home;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import com.example.wearether.models.pojo.Place;
import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.List;

import lombok.val;

public class HomeViewModel extends ViewModel {
    private MutableLiveData<String> mText;
    private MutableLiveData<List<Place>> mPlacesList;

    public HomeViewModel() {
        mText = new MutableLiveData<>();
        mPlacesList = new MutableLiveData<>(new ArrayList<>());
    }

    public LiveData<String> getText() {
        return mText;
    }

    public void setText(String text) {
        mText.setValue(text);
    }

    public void setPlacesList(List<Place> placesList) {
        mPlacesList.setValue(placesList);
    }

    public LiveData<List<Place>> getLivePlacesList() { return mPlacesList; }
}