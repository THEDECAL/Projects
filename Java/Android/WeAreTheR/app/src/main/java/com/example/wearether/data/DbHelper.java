package com.example.wearether.data;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

import androidx.annotation.NonNull;

import com.example.wearether.models.pojo.Place;
import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.List;

import lombok.val;

public class DbHelper extends SQLiteOpenHelper {
    static private DbHelper instance;

    static private class DB_FIELDS{
        static public final String ID = "id";
        static public final String PLACE_ID = "place_id";
        static public final String JSON_OBJECT = "json_obj";
    }
    static private final int DB_VERSION = 3;
    static private final String DB_NAME = "we_are_the_r.db";
    static private final String DB_TABLE_FAV_PLACES = "tb_favorites_cities";
    private SQLiteDatabase database;

    private DbHelper(@NonNull Context context){
        super(context, DB_NAME, null, DB_VERSION);
    }

    static public DbHelper getInstance(){ return instance; }
    static public DbHelper init(Context context){
        return instance = (instance == null)
                ? new DbHelper(context)
                : instance;
    }

    /**
     * Открытие соединения с БД
     */
    public void open(){
        instance.database = getWritableDatabase();
    }

    /**
     * Закрытие соединения с БД
     */
    public void close(){
        if(instance.database != null && instance.database.isOpen())
            instance.database.close();
    }

    /**
     * Проверка состояния соединения с БД
     */
    public boolean isOpen(){
        return (instance.database != null)
                ? instance.database.isOpen()
                : false;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE IF NOT EXISTS " + DB_TABLE_FAV_PLACES +
                "(" +
                    DB_FIELDS.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    DB_FIELDS.PLACE_ID + " TEXT NOT NULL, " +
                    DB_FIELDS.JSON_OBJECT + " TEXT NOT NULL" +
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
        //if(!isOpen()) open();

        Cursor cursor = null;
        try {
            cursor = instance.database.rawQuery(
                    String.format("SELECT * FROM %s WHERE %s=?",
                    DB_TABLE_FAV_PLACES, DB_FIELDS.PLACE_ID),
                    new String[]{placeId});

            if (cursor.moveToFirst())
                return true;
        }
        catch (Exception ex){}
        finally {
            if(cursor != null)
                cursor.close();
//            if(instance.database != null)
//                instance.database.close();
        }
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
        val listPlaces = new ArrayList<Place>();
        Cursor cursor = null;
        try {
            cursor = instance.database.rawQuery(
                    String.format("SELECT * FROM %s",
                    DB_TABLE_FAV_PLACES),null);

            if (cursor.moveToFirst()){
                do {
                    val jsonObject = cursor.getString(2);
                    listPlaces.add(new Gson().fromJson(jsonObject, Place.class));
                }while(cursor.moveToNext());

                return listPlaces;
            }
        }
        catch (Exception ex){}
        finally {
            if(cursor != null)
                cursor.close();
        }
        return listPlaces;
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
            val id = instance.database.insert(DB_TABLE_FAV_PLACES, null, contentValues);
            Log.d("MY_LOG", "Row inserted result: " + String.valueOf(id));
        }
    }

    /**
     * Удаление места в базе
     * @param placeId Идентификатор места
     */
    public void delCity(@NonNull String placeId){
        val isDel = instance.database.delete(DB_TABLE_FAV_PLACES,
                DB_FIELDS.PLACE_ID + "=?", new String[]{placeId});
        Log.d("MY_LOG", "Row delete result: " + String.valueOf(isDel));
    }
}
