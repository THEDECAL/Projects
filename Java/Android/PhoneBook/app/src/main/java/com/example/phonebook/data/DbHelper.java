package com.example.phonebook.data;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.Build;
import android.util.Log;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.annotation.RequiresApi;

import com.example.phonebook.models.PhoneBookEntry;

import java.util.ArrayList;
import java.util.List;

import lombok.val;
import lombok.var;

public class DbHelper extends SQLiteOpenHelper {
    static private class DB_FIELDS{
        static public final String ID = "id";
        static public final String SNAME = "sname";
        static public final String FNAME = "fname";
        static public final String PHONE_NUMBER = "phone_number";
        static public final String PATH_TO_PHOTO = "path_to_photo";
    }
    static private final int DB_VERSION = 2;
    static private final String DB_NAME = "phone_book.db";
    static private final String DB_TABLE_PHONEBOOK = "tb_phone_book";
    private SQLiteDatabase database;

    public DbHelper(@NonNull Context context) {
        super(context, DB_NAME, null, DB_VERSION);
    }

    public void open(){
        database = getWritableDatabase();
        onCreate(database);
    }

    public void close(){
        if(database != null && database.isOpen())
            database.close();
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL("CREATE TABLE IF NOT EXISTS " + DB_TABLE_PHONEBOOK +
                    "(" +
                        DB_FIELDS.ID + " INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        DB_FIELDS.SNAME + " TEXT NOT NULL, " +
                        DB_FIELDS.FNAME + " TEXT NOT NULL, " +
                        DB_FIELDS.PHONE_NUMBER + " TEXT NOT NULL, " +
                        DB_FIELDS.PATH_TO_PHOTO + " TEXT NOT NULL" +
                    ")");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("DROP TABLE IF EXISTS " + DB_TABLE_PHONEBOOK);
    }

    /**
     * Получение записей телефонной книги изи БД
     * @return Возвращает список записей телефонной книги
     */
    public List<PhoneBookEntry> getEntries(){
        List<PhoneBookEntry> phoneBookEntryList = new ArrayList<>();
        Cursor cursor = database.rawQuery(
                "SELECT * FROM " + DB_TABLE_PHONEBOOK, null);

        if (cursor.moveToFirst()) {
            do {
                phoneBookEntryList.add(new PhoneBookEntry(
                        cursor.getInt(0),    //id
                        cursor.getString(1), //sname
                        cursor.getString(2), //fname
                        cursor.getString(3), //phone number
                        cursor.getString(4)  //path to photo
                ));
            } while (cursor.moveToNext());
        }
        cursor.close();

        return phoneBookEntryList;
    }

    /**
     * Получение записи по ID
     * @param id Принимает идентификатор типа Integer
     * @return Возвращает объект записи телефонной книги
     */
    public PhoneBookEntry getEntryById(@NonNull Integer id){
        PhoneBookEntry entry = null;
        Cursor cursor = database.rawQuery("SELECT * FROM " + DB_TABLE_PHONEBOOK +
                " WHERE " + DB_FIELDS.ID + "='" + String.valueOf(id) + "'", null);

        if (cursor.moveToFirst()) {
            entry = new PhoneBookEntry(
                    cursor.getInt(0),    //id
                    cursor.getString(1), //sname
                    cursor.getString(2), //fname
                    cursor.getString(3), //phone number
                    cursor.getString(4)  //path to photo
            );
        }
        cursor.close();

        return entry;
    }

    /**
     * Добавление, обновление записи телефонной книги в БД
     * @param entry Принмает объект записи телефонной книги
     * @return Возвращает ID добавленной или измененной строки
     */
    public int addUpdateEntry(@NonNull PhoneBookEntry entry){
        var contentValues = new ContentValues();
        contentValues.put(DB_FIELDS.SNAME, entry.getSname());
        contentValues.put(DB_FIELDS.FNAME, entry.getFname());
        contentValues.put(DB_FIELDS.PHONE_NUMBER, entry.getPhoneNumber());
        contentValues.put(DB_FIELDS.PATH_TO_PHOTO, entry.getPathToPhoto());

        var existingEntry = getEntryById(entry.getId());
        if (existingEntry != null) {
            if (!existingEntry.equals(entry)) {
                database.update(DB_TABLE_PHONEBOOK, contentValues,
                        DB_FIELDS.ID + "=" + String.valueOf(entry.getId()), null);
                return entry.getId();
            }
        }
        else {
            database.insert(DB_TABLE_PHONEBOOK, null, contentValues);
            val cursor = database.rawQuery("select last_insert_rowid()", null);
            if(cursor.moveToFirst()){
                return cursor.getInt(0);
            }
        }
        return 0;
    }

    /**
     * Удаление записи телефонной книги из БД
     */
    public void delEntry(int id){
        database.delete(DB_TABLE_PHONEBOOK,
                DB_FIELDS.ID + "=?", new String[]{String.valueOf(id)});
    }
}
