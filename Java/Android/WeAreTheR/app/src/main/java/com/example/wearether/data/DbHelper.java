package com.example.wearether.data;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import androidx.annotation.NonNull;

import com.example.wearether.models.pojo.Place;
import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.List;

import lombok.val;

public class DbHelper extends SQLiteOpenHelper {
    static private class DB_FIELDS{
        static public final String ID = "id";
        static public final String PLACE_ID = "city_id";
        static public final String JSON_OBJECT = "json_obj";
    }
    static private final int DB_VERSION = 2;
    static private final String DB_NAME = "we_are_the_r.db";
    static private final String DB_TABLE_FAV_PLACES = "tb_favorites_cities";
    private SQLiteDatabase database;

    public DbHelper(@NonNull Context context) {
        super(context, DB_NAME, null, DB_VERSION);
    }

    /**
     * Открытие соединения с БД
     */
    public void open(){
        database = getWritableDatabase();
        onCreate(database);
    }

    /**
     * Закрытие соединения с БД
     */
    public void close(){
        if(database != null && database.isOpen())
            database.close();
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE IF NOT EXISTS " + DB_TABLE_FAV_PLACES +
                "(" +
                    DB_FIELDS.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    DB_FIELDS.PLACE_ID + " TEXT NOT NULL, " +
                    DB_FIELDS.JSON_OBJECT + " TEXT NOT NULL " +
                ")");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + DB_TABLE_FAV_PLACES);
    }

    /**
     * Проверяет место по идентификатору места
     * @param placeId Идентификатор места
     * @return Возвращает true, если такое место в базе есть
     */
    public boolean isExistPlaceId(@NonNull String placeId){
        Cursor cursor = null;
        try {
            cursor = database.rawQuery("SELECT * FROM " + DB_TABLE_FAV_PLACES +
                    " WHERE " + DB_FIELDS.PLACE_ID + "='" + placeId + "'", null);

            if (cursor.moveToFirst())
                return true;
        }
        catch (Exception ex){}
        finally { if(cursor != null) cursor.close(); }
        return false;
    }

//    public Place getPlaceByPlaceId(@NonNull String placeId){
//        Cursor cursor = null;
//        try {
//            cursor = database.rawQuery("SELECT * FROM " + DB_TABLE_FAV_PLACES +
//                    " WHERE " + DB_FIELDS.PLACE_ID + "='" + placeId + "'", null);
//
//            if (cursor.moveToFirst()){
//                val jsonObject = cursor.getString(2);
//                return new Gson().fromJson(jsonObject, Place.class);
//            }
//        }
//        catch (Exception ex){}
//        finally { if(cursor != null) cursor.close(); }
//        return null;
//    }

    /**
     * Получение списка мест
     * @return Возвращает список мест
     */
    public List<Place> getPlaces(){
        Cursor cursor = null;
        try {
            cursor = database.rawQuery("SELECT * FROM " + DB_TABLE_FAV_PLACES,
                    null);

            if (cursor.moveToFirst()){
                val listPlaces = new ArrayList<Place>();
                do {
                    val jsonObject = cursor.getString(2);
                    listPlaces.add(new Gson().fromJson(jsonObject, Place.class));
                }while(cursor.moveToNext());

                return listPlaces;
            }
        }
        catch (Exception ex){}
        finally { if(cursor != null) cursor.close(); }
        return null;
    }

    /**
     * Добавление места в базу
     * @param place Объект места
     */
    public void addCity(@NonNull Place place){
        val contentValues = new ContentValues();
        contentValues.put(DB_FIELDS.PLACE_ID, place.key);
        contentValues.put(DB_FIELDS.JSON_OBJECT, new Gson().toJson(place));

        if (!isExistPlaceId(place.key)) {
            database.insert(DB_TABLE_FAV_PLACES, null, contentValues);
        }
    }

    /**
     * Удаление места в базе
     * @param placeId Идентификатор места
     */
    public void delCity(@NonNull String placeId){
        database.delete(DB_TABLE_FAV_PLACES,
                DB_FIELDS.PLACE_ID + "=?", new String[]{placeId});
    }
}
