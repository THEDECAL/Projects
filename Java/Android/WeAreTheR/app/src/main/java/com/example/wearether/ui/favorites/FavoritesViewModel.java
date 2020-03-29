package com.example.wearether.ui.favorites;

import android.content.Context;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import com.example.wearether.data.DbHelper;
import com.example.wearether.models.pojo.Place;
import java.util.List;

import lombok.val;

public class FavoritesViewModel extends ViewModel {
        private MutableLiveData<String> mText;
        private MutableLiveData<List<Place>> mListPlaces;

        public FavoritesViewModel() {
            mText = new MutableLiveData<>();
            mListPlaces = new MutableLiveData<>();
        }

        public LiveData<String> getText() { return mText; }

        public void setText(String value) {
            mText.setValue(value);
        }

        public LiveData<List<Place>> getListPlaces(){
            val dbHelper = FavoritesFragment.getDbHelper();
            mListPlaces.setValue(dbHelper.getPlaces());

            return mListPlaces;
        }
}
