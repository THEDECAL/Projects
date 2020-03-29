package com.example.wearether.ui.favorites;

import android.content.Context;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.wearether.R;
import com.example.wearether.data.DbHelper;

public class FavoritesFragment extends Fragment {
    static private DbHelper dbHelper;

    private LayoutInflater inflater;
    private View parentView;

    static public DbHelper getDbHelper(){ return dbHelper; }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        dbHelper = new DbHelper(getContext());
        dbHelper.open();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        this.inflater = inflater;
        parentView = inflater.inflate(R.layout.fragment_favorites, container, false);

        return parentView;
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        if(dbHelper != null)
            dbHelper.close();
    }
}
