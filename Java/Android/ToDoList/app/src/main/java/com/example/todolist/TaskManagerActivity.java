package com.example.todolist;
import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.app.Fragment;
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

import lombok.var;

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
    private SetDateTimeFragment startDateTime;
    private SetDateTimeFragment endDateTime;
    private ImageButton ibBack, ibAddEditTask;
    private RadioButton rbVeryLow, rbLow, rbNormal, rbHigh, rbVeryHigh;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_task_manager);

        initViews();
        initFragments();
        initForm();

        ibBack.setOnClickListener(this);
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
        ibAddEditTask = findViewById(R.id.ibAddEditTask);
        ibBack = findViewById(R.id.ibBack);
        rbVeryLow = findViewById(R.id.rbVeryLow);
        rbLow = findViewById(R.id.rbLow);
        rbNormal = findViewById(R.id.rbNormal);
        rbHigh = findViewById(R.id.rbHigh);
        rbVeryHigh = findViewById(R.id.rbVeryHigh);
    }

    /**
     * Инициализация фрагментов
     */
    protected void initFragments(){
        startDateTime = (SetDateTimeFragment) getFragmentManager().
                findFragmentById(R.id.fSetStartDateTime);
        startDateTime.setTitle("Начало задания");
        endDateTime = (SetDateTimeFragment) getFragmentManager().
                findFragmentById(R.id.fSetEndDateTime);
        endDateTime.setTitle("Конец задания");
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
        startDateTime.setDate(startDate);
        endDateTime.setDate(endDate);

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
    protected void editOnOff(boolean isEnable){
        etTitle.setEnabled(isEnable);
        etDesc.setEnabled(isEnable);
        etOwner.setEnabled(isEnable);
        rgPrio.setEnabled(isEnable);
        startDateTime.onOffButtons(isEnable);
        endDateTime.onOffButtons(isEnable);
        ibAddEditTask.setVisibility((isEnable)?View.VISIBLE:View.INVISIBLE);
        rbVeryLow.setEnabled(isEnable);
        rbLow.setEnabled(isEnable);
        rbNormal.setEnabled(isEnable);
        rbHigh.setEnabled(isEnable);
        rbVeryHigh.setEnabled(isEnable);
    }

    @Override
    public void onClick(final View v) {
        if(v == ibAddEditTask){
            try {
                final Bundle bundle = getIntent().getExtras();
                final MODE mode = MODE.getMode(bundle.getInt("mode"));
                Intent intent = null;
                Task task = null;
                final String title = etTitle.getText().toString().trim();
                final String desc = etDesc.getText().toString().trim();
                final String owner = etOwner.getText().toString().trim();
                final Date startDate = startDateTime.getDate();
                final Date endDate = endDateTime.getDate();
                final RadioButton rb = findViewById(rgPrio.getCheckedRadioButtonId());
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
