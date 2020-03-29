package com.example.phonebook;
import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.phonebook.models.PhoneBookEntry;
import com.squareup.picasso.Picasso;

import lombok.NonNull;
import lombok.val;
import lombok.var;

public class EntryManageActivity extends AppCompatActivity {
    static private final int ADD_PHOTO_CODE = 33;
    private TextView tvId;
    private EditText etSname;
    private EditText etFname;
    private EditText etPhoneNumber;
    private ImageView ivPhoto;
    private TextView tvPathToPhoto;
    private Button bAddEdit;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_entry_manage);

        initViews();

        val bundle = getIntent().getExtras();
        if(bundle != null) {
            val entry = (PhoneBookEntry) bundle.getSerializable("entry");
            if(entry != null){
                setEntryToForm(entry);
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                    bAddEdit.setForeground(getResources().getDrawable(android.R.drawable.ic_menu_edit));
                }
            }
        }
    }

    /**
     * Возврат на главный экран
     * @param v Принимает объект View
     */
    public void backToMainActivity(View v){
        startActivity(new Intent(this, MainActivity.class));
    }

    /**
     * Добавление записи
     * @param v Принимает объект View
     */
    public void addEditEntry(View v){
        if(etSname.getText().toString().trim().equals("") &&
                etFname.getText().toString().trim().equals("") &&
                tvPathToPhoto.getText().toString().trim().equals("")){
            Toast.makeText(this, "Заполните хотя-бы одно обязательное поле...", Toast.LENGTH_LONG).show();
        }
        else {
            val intent = new Intent(this, MainActivity.class);
            intent.putExtra("entry", getEntryFromForm());
            startActivity(intent);
        }
    }

    /**
     * Получение записи из формы
     * @return Возвращает объект записи телефонной книги
     */
    public PhoneBookEntry getEntryFromForm(){
        Integer id = null;
        try { id = Integer.parseInt(tvId.getText().toString()); }
        catch(NumberFormatException ex){}

        return new PhoneBookEntry(
                id,
                etSname.getText().toString(),
                etFname.getText().toString(),
                etPhoneNumber.getText().toString(),
                tvPathToPhoto.getText().toString());
    }

    /**
     * Устанавка значений записи на форме
     * @param entry Принимает объект записи телефонной книги
     */
    protected void setEntryToForm(@NonNull PhoneBookEntry entry){
        try {
            tvId.setText(String.valueOf(entry.getId()));
            etSname.setText(entry.getSname());
            etFname.setText(entry.getFname());
            etPhoneNumber.setText(entry.getPhoneNumber());
            tvPathToPhoto.setText(entry.getPathToPhoto());

            Picasso.get().load(Uri.parse(entry.getPathToPhoto())).into(ivPhoto);
            ivPhoto.setScaleType(ImageView.ScaleType.CENTER_CROP);
        } catch(Exception ex){
            ex.getStackTrace();
            Log.d("MY_LOG", ex.getMessage());
        }
    }

    /**
     * Добавление фоторафии на форму
     * @param v Принимаеи объеки View
     */
    public void addPhoto(View v){
        var intent = new Intent(Intent.ACTION_OPEN_DOCUMENT);
        intent.addCategory(Intent.CATEGORY_OPENABLE);
        intent.setType("image/*");
        startActivityForResult(intent, ADD_PHOTO_CODE);
    }

    /**
     * Инициализация элементов
     */
    public void initViews(){
        tvId = findViewById(R.id.tvId);
        etSname = findViewById(R.id.etSName);
        etFname = findViewById(R.id.etFName);
        etPhoneNumber = findViewById(R.id.etPhoneNumber);
        ivPhoto = findViewById(R.id.ivPhoto);
        tvPathToPhoto = findViewById(R.id.tvPathToPhoto);
        bAddEdit = findViewById(R.id.bAddEdit);
    }

    /**
     * Обработка результата добавления фото
     * @param requestCode Код запроса
     * @param resultCode Код результата выполнения
     * @param resultData Результирующие данные
     */
    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent resultData) {
        if(requestCode == ADD_PHOTO_CODE && resultCode == Activity.RESULT_OK){
            if(resultData != null){
                var uri = resultData.getData();

                tvPathToPhoto.setText(uri.toString());
                Picasso.get().load(uri).into(ivPhoto);
                ivPhoto.setScaleType(ImageView.ScaleType.CENTER_CROP);
            }
        }
        super.onActivityResult(requestCode, resultCode, resultData);
    }
}
