package com.example.phonebook;
import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.database.sqlite.SQLiteDatabase;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;

import com.example.phonebook.adapters.PhoneBookAdapter;
import com.example.phonebook.data.DbHelper;
import com.example.phonebook.models.PhoneBookEntry;
import com.example.phonebook.models.PhoneBookManageMode;

import java.util.ArrayList;
import java.util.List;

import lombok.val;
import lombok.var;

public class MainActivity extends AppCompatActivity {
    static private List<PhoneBookEntry> listEntries;
    private DbHelper dbHelper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_main);

        dbHelper = new DbHelper(this);
        dbHelper.open();

        //Настройка RecyclerView
        listEntries = new ArrayList<>(dbHelper.getEntries());
        var phoneBookAdapter = new PhoneBookAdapter(this, listEntries);
        ConstraintLayout clPhoneBook = findViewById(R.id.clPhoneBook);
        RecyclerView rvPhoneBook = findViewById(R.id.rvPhoneBook);

        rvPhoneBook.setHasFixedSize(true);
        rvPhoneBook.setLayoutManager(new LinearLayoutManager(clPhoneBook.getContext()));
        rvPhoneBook.setAdapter(phoneBookAdapter);

        //Получение записи для добавления или обнавления
        val bundle = getIntent().getExtras();
        if(bundle != null){
            val entry = (PhoneBookEntry) bundle.getSerializable("entry");

            if(entry != null){
                int id = dbHelper.addUpdateEntry(entry);

                //var existEntry = listEntries.stream().filter((e) -> e.getId().equals(entry.getId())).findFirst().orElse(null);
                if(entry.getId() != 0) { //Если такой id найднен изменяем запись
                    for (var en : listEntries) {
                        if (entry.getId() == en.getId()) {
                            if (!entry.equals(en))
                                en.copy(entry);
                            break;
                        }
                    }
                }
                else { //Если нет добавляем запись
                    entry.setId(id);
                    listEntries.add(entry);
                }
                phoneBookAdapter.notifyDataSetChanged();
            }
        }
    }

    /**
     * Метод для добавления записи в телефонную книгу
     * @param v Принимает объект View
     */
    public void addPhoneBookEntry(View v){
        Intent intent = new Intent(this, EntryManageActivity.class);
        intent.putExtra("mode", PhoneBookManageMode.ADD.getValue());
        startActivity(intent);
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        if(dbHelper != null)
            dbHelper.close();
    }
}
