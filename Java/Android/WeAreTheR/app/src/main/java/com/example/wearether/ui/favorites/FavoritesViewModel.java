package com.example.wearether.ui.favorites;

import android.content.Context;
import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;
import com.example.wearether.data.DbHelper;
import com.example.wearether.models.pojo.Place;
import java.util.ArrayList;
import java.util.List;
import lombok.val;

public class FavoritesViewModel extends ViewModel {
    private MutableLiveData<String> mText;
    private MutableLiveData<List<Place>> mListPlaces;

    public FavoritesViewModel() {
        mText = new MutableLiveData<>();
        mListPlaces = new MutableLiveData<>(new ArrayList<>());
    }

    public LiveData<String> getText() { return mText; }

    public void setText(String value) { mText.setValue(value); }

    public void setPlacesList(List<Place> listPlaces){ mListPlaces.setValue(listPlaces); }

    public LiveData<List<Place>> getLivePlacesList(){ return mListPlaces; }
}
