package com.example.todolist;
import android.app.DatePickerDialog;
import android.app.Fragment;
import android.app.TimePickerDialog;
import android.os.Bundle;
import androidx.annotation.NonNull;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.TextView;
import android.widget.TimePicker;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

public class SetDateTimeFragment extends Fragment implements View.OnClickListener{
    final private SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
    final private SimpleDateFormat timeFormat = new SimpleDateFormat("HH:mm");
    final private SimpleDateFormat dateTimeFormat = new SimpleDateFormat("dd.MM.yyyy HH:mm");
    private View parentView;
    private LayoutInflater inflater;
    private TextView tvTime, tvDate;
    private Button bSelectTime, bSelectDate;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        this.inflater = inflater;
        this.parentView = inflater.inflate(R.layout.fragment_set_date_time, container, false);
        initViews();
        setDate(new Date());

        bSelectTime.setOnClickListener(this);
        bSelectDate.setOnClickListener(this);

        return this.parentView;
    }

    public void setTitle(@NonNull String title){
        TextView tv = parentView.findViewById(R.id.tvTitle);
        if(tv != null)
            tv.setText(title);
    }

    public void onOffButtons(boolean isEnable){
        bSelectTime.setEnabled(isEnable);
        bSelectDate.setEnabled(isEnable);
    }

    public Date getDate(){
        try {
            return dateTimeFormat.parse(
                    tvDate.getText().toString() + ' ' +
                            tvTime.getText().toString());
        } catch (ParseException e) {
            e.printStackTrace();
            return null;
        }
    }

    public void setDate(@NonNull Date date){
        tvTime.setText(timeFormat.format(date));
        tvDate.setText(dateFormat.format(date));
    }

    private void initViews(){
        tvTime = parentView.findViewById(R.id.tvTime);
        tvDate = parentView.findViewById(R.id.tvDate);
        bSelectTime = parentView.findViewById(R.id.bSelectTime);
        bSelectDate = parentView.findViewById(R.id.bSelectDate);
    }

    @Override
    public void onClick(View v) {
        if(v == bSelectTime){
            final Calendar c = Calendar.getInstance();
            TimePickerDialog tpd = new TimePickerDialog(inflater.getContext(), new TimePickerDialog.OnTimeSetListener() {
                @Override
                public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
                    try {
                        Date time = timeFormat.parse(String.valueOf(hourOfDay) + ':'
                                + String.valueOf(minute));

                        tvTime.setText(timeFormat.format(time));
                    } catch (ParseException e) {}
                }
            }, c.get(Calendar.HOUR_OF_DAY), c.get(Calendar.MINUTE) , true);
            tpd.show();
        }
        else if(v == bSelectDate){
            final Calendar c = Calendar.getInstance();
            DatePickerDialog dpd = new DatePickerDialog(inflater.getContext(), new DatePickerDialog.OnDateSetListener() {
                @Override
                public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                    try {
                        Date date = dateFormat.parse(String.valueOf(dayOfMonth) + '.'
                                + String.valueOf(month) + '.'
                                + String.valueOf(year));

                            tvDate.setText(dateFormat.format(date));
                    } catch (ParseException e) { }
                }
            }, c.get(Calendar.YEAR), c.get(Calendar.MONTH), c.get(Calendar.DAY_OF_MONTH));
            dpd.show();
        }
    }
}
