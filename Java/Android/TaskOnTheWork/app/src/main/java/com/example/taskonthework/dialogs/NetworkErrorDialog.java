package com.example.taskonthework.dialogs;

import android.app.AlertDialog;
import android.app.Dialog;
import android.os.Bundle;

import androidx.fragment.app.DialogFragment;

public class NetworkErrorDialog extends DialogFragment {
    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        return new AlertDialog.Builder(getActivity())
            .setIcon(android.R.drawable.ic_dialog_info)
            .setTitle("Внимание")
            .setMessage("Ошибка при получении новостей.\n" +
                            "Проверьте подключение к Интернету...")
            .setPositiveButton("Ок", null).create();
    }
}