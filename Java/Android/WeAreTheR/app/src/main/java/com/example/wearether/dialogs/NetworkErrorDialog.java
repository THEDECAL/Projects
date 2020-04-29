package com.example.wearether.dialogs;

import android.app.AlertDialog;
import android.app.Dialog;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.DialogFragment;

import lombok.val;

public class NetworkErrorDialog extends DialogFragment {
    @NonNull
    @Override
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {
        return new AlertDialog.Builder(getActivity())
                .setIcon(android.R.drawable.ic_dialog_info)
                .setTitle("Внимание")
                .setMessage("Не могу соединится с сервером.\n" +
                        "Проверьте подключение к Интернету...")
                .setPositiveButton("Ок", null).create();
    }
}