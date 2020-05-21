package com.example.taskonthework.tools;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.widget.ImageView;

import java.io.InputStream;
import java.net.URL;

/**
 * Класс для асинхронной загрузки изображений
 */
public class GetImageTask extends AsyncTask<String,Void, Bitmap> {
    ImageView imageView;

    public GetImageTask(ImageView imageView){
        this.imageView = imageView;
    }

    protected Bitmap doInBackground(String...urls){
        Bitmap image = null;
        try{
            final String urlImage = urls[0];
            final URL url = new URL(urlImage);
            final InputStream is = url.openStream();
            image = BitmapFactory.decodeStream(is);
        }catch(Exception e){
            e.printStackTrace();
        }

        return image;
    }

    protected void onPostExecute(Bitmap image){
        this.imageView.setImageBitmap(image);
    }
}
