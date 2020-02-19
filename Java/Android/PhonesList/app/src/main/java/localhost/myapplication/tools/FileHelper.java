package localhost.myapplication.tools;

import android.graphics.drawable.Drawable;
import android.util.Log;
import android.view.View;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;

import localhost.myapplication.MainActivity;

public class FileHelper {
    static public Drawable getImageByPath(String path){
        FileInputStream fis = null;
        try {
            fis = new FileInputStream(path);
            return Drawable.createFromStream(fis, null);
        } catch (FileNotFoundException e){
            Log.d(MainActivity.LOG_TAG, e.getMessage());
            return null;
        }
        finally {
            try{
                if(fis != null) fis.close();
            } catch (IOException e){
                Log.d(MainActivity.LOG_TAG, e.getMessage());
                return null;
            }
        }
    }

    static public Drawable getImageInAssets(View view, String imageId){
        InputStream is = null;
        try{
            is = view.getContext().getAssets().open(imageId);
            return Drawable.createFromStream(is, null);
        } catch (IOException e) {
            Log.d(MainActivity.LOG_TAG, e.getMessage());
            e.printStackTrace();
            return null;
        }
        finally {
            try{
                if(is != null) is.close();
            } catch (IOException e) {
                e.printStackTrace();
                Log.d(MainActivity.LOG_TAG, e.getMessage());
                return null;
            }
        }
    }

//    static public Drawable copyFileToAssets(MainActivity view, InputStream is){
//        FileOutputStream fos = new FileOutputStream();
//
//    }
}
