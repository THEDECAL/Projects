package com.example.todolist;
import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.TimePicker;

import com.example.todolist.models.Task;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

public class TaskManagerActivity extends AppCompatActivity implements View.OnClickListener
{
    final private SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
    final private SimpleDateFormat timeFormat = new SimpleDateFormat("HH:mm");
    final private SimpleDateFormat dateTimeFormat = new SimpleDateFormat("dd.MM.yyyy HH:mm");
    public enum MODE{
        ADD(0), SHOW(1), EDIT(2);
        private int value;

        MODE(int value){ this.value = value; }
        public int getValue(){ return value; }
        static public MODE getMode(int value){
            for (MODE m: MODE.values()) {
                if(m.getValue() == value)
                    return m;
            }
            return null;
        }
    };

    private EditText etTitle, etDesc, etOwner;
    private RadioGroup rgPrio;
    private TextView tvStartTime, tvStartDate;
    private TextView tvEndTime, tvEndDate;
    private Button bSelectStartTime, bSelectStartDate;
    private Button bSelectEndTime, bSelectEndDate;
    private ImageButton ibBack, ibAddEditTask;
    private RadioButton rbVeryLow, rbLow, rbNormal, rbHigh, rbVeryHigh;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_task_manager);

        initViews();
        initForm();

        ibBack.setOnClickListener(this);
        bSelectStartDate.setOnClickListener(this);
        bSelectStartTime.setOnClickListener(this);
        bSelectEndDate.setOnClickListener(this);
        bSelectEndTime.setOnClickListener(this);
        ibAddEditTask.setOnClickListener(this);
    }

    /**
     * Инициализация элементов управления
     */
    protected void initViews(){
        etTitle = findViewById(R.id.etTitle);
        etDesc = findViewById(R.id.etDesc);
        etOwner = findViewById(R.id.etOwner);
        rgPrio = findViewById(R.id.rgPrio);
        tvStartTime = findViewById(R.id.tvStartTime);
        tvStartDate = findViewById(R.id.tvStartDate);
        tvEndTime = findViewById(R.id.tvEndTime);
        tvEndDate = findViewById(R.id.tvEndDate);
        bSelectStartTime = findViewById(R.id.bSelectStartTime);
        bSelectStartDate = findViewById(R.id.bSelectStartDate);
        bSelectEndTime = findViewById(R.id.bSelectEndTime);
        bSelectEndDate = findViewById(R.id.bSelectEndDate);
        ibAddEditTask = findViewById(R.id.ibAddEditTask);
        ibBack = findViewById(R.id.ibBack);
        rbVeryLow = findViewById(R.id.rbVeryLow);
        rbLow = findViewById(R.id.rbLow);
        rbNormal = findViewById(R.id.rbNormal);
        rbHigh = findViewById(R.id.rbHigh);
        rbVeryHigh = findViewById(R.id.rbVeryHigh);
    }

    /**
     * Инифиализация формы задания
     */
    protected void initForm(){
        Bundle bundle = getIntent().getExtras();
        MODE mode = MODE.getMode(bundle.getInt("mode"));

        switch (mode) {
            case ADD:
                //Изменяем иконку
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                    ibAddEditTask.setForeground(getResources().getDrawable(android.R.drawable.ic_menu_add));
                }

                final Calendar cEnd = Calendar.getInstance();
                cEnd.add(Calendar.DAY_OF_MONTH, 1);
                setValuesOnForm("", "", "", Task.Prio.NORMAL,
                        new Date(), cEnd.getTime());
                break;
            case SHOW:
            case EDIT:
                if (mode == MODE.SHOW) {
                    editOnOff(false);
                }
                else if (mode == MODE.EDIT) {
                    //Изменяем иконку
                    if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                        ibAddEditTask.setForeground(getResources().getDrawable(android.R.drawable.ic_menu_edit));
                    }
                }

                Task task = (Task) bundle.getSerializable("task");
                setValuesOnForm(task.getTitle(), task.getDescription(), task.getOwner(), task.getPrio(),
                        task.getStartDate(), task.getEndDate());
                break;
        }
    }

    /**
     * Заполняет форму значениями
     */
    protected void setValuesOnForm(String title, String desc, String owner, Task.Prio prio, Date startDate, Date endDate){
        etTitle.setText(title);
        etDesc.setText(desc);
        etOwner.setText(owner);
        tvStartTime.setText(timeFormat.format(startDate));
        tvStartDate.setText(dateFormat.format(startDate));
        tvEndTime.setText(timeFormat.format(endDate));
        tvEndDate.setText(dateFormat.format(endDate));

        switch(prio){
            case VERY_LOW: rgPrio.check(R.id.rbVeryLow); break;
            case LOW: rgPrio.check(R.id.rbLow); break;
            case NORMAL: rgPrio.check(R.id.rbNormal); break;
            case HIGH: rgPrio.check(R.id.rbHigh); break;
            case VERY_HIGH: rgPrio.check(R.id.rbVeryHigh); break;
        }
    }

    /**
     * Включает или выключает элементы управления
     * @param isEnable
     */
    protected void editOnOff(Boolean isEnable){
        etTitle.setEnabled(isEnable);
        etDesc.setEnabled(isEnable);
        etOwner.setEnabled(isEnable);
        rgPrio.setEnabled(isEnable);
        bSelectStartDate.setEnabled(isEnable);
        bSelectStartTime.setEnabled(isEnable);
        bSelectEndDate.setEnabled(isEnable);
        bSelectEndTime.setEnabled(isEnable);
        ibAddEditTask.setVisibility((isEnable)?View.VISIBLE:View.INVISIBLE);
        rbVeryLow.setEnabled(isEnable);
        rbLow.setEnabled(isEnable);
        rbNormal.setEnabled(isEnable);
        rbHigh.setEnabled(isEnable);
        rbVeryHigh.setEnabled(isEnable);
    }

    @Override
    public void onClick(final View v) {
        if(v == bSelectStartDate || v == bSelectEndDate){
            final Calendar c = Calendar.getInstance();
            DatePickerDialog dpd = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
                @Override
                public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                    try {
                        Date date = dateFormat.parse(String.valueOf(dayOfMonth) + '.'
                                + String.valueOf(month) + '.'
                                + String.valueOf(year));

                        if(v == bSelectStartDate)
                            tvStartDate.setText(dateFormat.format(date));
                        else if(v == bSelectEndDate)
                            tvEndDate.setText(dateFormat.format(date));
                    } catch (ParseException e) { }
                }
            }, c.get(Calendar.YEAR), c.get(Calendar.MONTH), c.get(Calendar.DAY_OF_MONTH));
            dpd.show();
        }
        else if(v == bSelectStartTime || v == bSelectEndTime){
            final Calendar c = Calendar.getInstance();
            TimePickerDialog tpd = new TimePickerDialog(this, new TimePickerDialog.OnTimeSetListener() {
                @Override
                public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
                    try {
                        Date time = timeFormat.parse(String.valueOf(hourOfDay) + ':'
                                + String.valueOf(minute));

                        if(v == bSelectStartTime)
                            tvStartTime.setText(timeFormat.format(time));
                        else if(v == bSelectEndTime)
                            tvEndTime.setText(timeFormat.format(time));
                    } catch (ParseException e) {}
                }
            }, c.get(Calendar.HOUR_OF_DAY), c.get(Calendar.MINUTE) , true);
            tpd.show();
        }
        else if(v == ibAddEditTask){
            try {
                final Bundle bundle = getIntent().getExtras();
                final MODE mode = MODE.getMode(bundle.getInt("mode"));
                Intent intent = null;
                Task task = null;
                final String title = etTitle.getText().toString().trim();
                final String desc = etDesc.getText().toString().trim();
                final String owner = etOwner.getText().toString().trim();
                final Date startDate = dateTimeFormat.parse(tvStartDate.getText().toString() + ' ' + tvStartTime.getText().toString());
                final Date endDate = dateTimeFormat.parse(tvEndDate.getText().toString() + ' ' + tvEndTime.getText().toString());
                final RadioButton rb = findViewById(rgPrio.getCheckedRadioButtonId());
//                Task.Prio prio = Task.Prio.getPrio(rb.getButtonTintList().getDefaultColor());
                Task.Prio prio = Task.Prio.NORMAL;

                switch (rgPrio.getCheckedRadioButtonId()) {
                    case R.id.rbVeryLow:
                        prio = Task.Prio.VERY_LOW;
                        break;
                    case R.id.rbLow:
                        prio = Task.Prio.LOW;
                        break;
                    case R.id.rbNormal:
                        prio = Task.Prio.NORMAL;
                        break;
                    case R.id.rbHigh:
                        prio = Task.Prio.HIGH;
                        break;
                    case R.id.rbVeryHigh:
                        prio = Task.Prio.VERY_HIGH;
                        break;
                }

                intent = new Intent(this, TaskListActivity.class);
                task = new Task(title, desc, owner, prio, startDate, endDate);
                intent.putExtra("mode", bundle.getInt("mode"));
                intent.putExtra("task", task);
                if(mode == MODE.EDIT)
                    intent.putExtra("index", bundle.getInt("index"));
                startActivity(intent);
            } catch (Exception e) { Log.d("MY_LOG", e.getMessage()); }
        }
        else if(v == ibBack){
            startActivity(new Intent(this, TaskListActivity.class));
        }
    }
}
