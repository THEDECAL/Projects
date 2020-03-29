package com.example.wearether;

import android.os.Bundle;
import android.view.Menu;

import com.example.wearether.databinding.ActivityMainBinding;
import com.example.wearether.models.pojo.Place;

import androidx.appcompat.widget.SearchView;
import androidx.databinding.DataBindingUtil;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import java.util.ArrayList;
import java.util.List;

import lombok.val;

public class MainActivity extends AppCompatActivity {
    static private final List<Place> placesList = new ArrayList<>();
    private AppBarConfiguration mAppBarConfiguration;
    private ActivityMainBinding activityMainBinding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        activityMainBinding = DataBindingUtil.setContentView(this, R.layout.activity_main);

        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        mAppBarConfiguration = new AppBarConfiguration.Builder(
                R.id.nav_home, R.id.nav_favorites)
                .setDrawerLayout(activityMainBinding.drawerLayout)
                .build();
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment);
        NavigationUI.setupActionBarWithNavController(this, navController, mAppBarConfiguration);
        NavigationUI.setupWithNavController(activityMainBinding.navView, navController);

        SearchView svSearchPlace = svSearchPlace = findViewById(R.id.svSearchPlace);
        svSearchPlace.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                val bundle = new Bundle();
                bundle.putString("SearchText", query);
                navController.navigate(R.id.nav_home, bundle);

                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) { return false; }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onSupportNavigateUp() {
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment);
        return NavigationUI.navigateUp(navController, mAppBarConfiguration)
                || super.onSupportNavigateUp();
    }
}
