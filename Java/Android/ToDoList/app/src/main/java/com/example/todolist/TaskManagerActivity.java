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
    public enum MODE{ SHOW };

    private EditText etTitle, etDesc, etOwner;
    private RadioGroup rgPrio;
    private TextView tvStartTime, tvStartDate;
    private TextView tvEndTime, tvEndDate;
    private Button bSelectStartTime, bSelectStartDate;
    private Button bSelectEndTime, bSelectEndDate;
    private ImageButton ibBack, ibAddEditTask;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_task_manager);

        initViews();
        initForm();

        Bundle bundle = getIntent().getExtras();
        ibBack.setOnClickListener(this);

        if(bundle != null){
            MODE mode = MODE.values()[bundle.getInt("mode")];
            if(mode == MODE.SHOW)
                editOnOff(false);
        }
        else{
            bSelectStartDate.setOnClickListener(this);
            bSelectStartTime.setOnClickListener(this);
            bSelectEndDate.setOnClickListener(this);
            bSelectEndTime.setOnClickListener(this);
            ibAddEditTask.setOnClickListener(this);
        }
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
    }

    /**
     * Инифиализация формы задания
     */
    protected void initForm(){
        Bundle extras = getIntent().getExtras();

        //Если это добавление
        if(extras == null) {
            //Изменяем иконку
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                ibAddEditTask.setForeground(getResources().getDrawable(android.R.drawable.ic_menu_add));
            }

            final Calendar c = Calendar.getInstance();
            tvStartDate.setText(dateFormat.format(c.getTime()));
            c.add(Calendar.DATE, 1);
            tvEndDate.setText(dateFormat.format(c.getTime()));
            tvStartTime.setText(timeFormat.format(c.getTime()));
            tvEndTime.setText(timeFormat.format(c.getTime()));
        }
        //Если это изменение
        else{
            //Изменяем иконку
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                ibAddEditTask.setForeground(getResources().getDrawable(android.R.drawable.ic_menu_edit));
            }
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
                Bundle bundle = getIntent().getExtras();
                Intent intent = null;
                Task task = null;
                String title = etTitle.getText().toString().trim();
                String desc = etDesc.getText().toString().trim();
                String owner = etOwner.getText().toString().trim();
                Date startDate = dateTimeFormat.parse(tvStartDate.getText().toString() + ' ' + tvStartTime.getText().toString());
                Date endDate = dateTimeFormat.parse(tvEndDate.getText().toString() + ' ' + tvEndTime.getText().toString());
                RadioButton rb = findViewById(rgPrio.getCheckedRadioButtonId());
//                Task.Prio prio = Task.Prio.values()[rb.getButtonTintList().getDefaultColor()];
                Task.Prio prio = Task.Prio.NORMAL;

                switch (rgPrio.getCheckedRadioButtonId()) {
                    case R.id.rbVeryLow:
                        prio = Task.Prio.VERY_LOW;
                        break;
                    case R.id.rbLow:
                        prio = Task.Prio.LOW;
                        break;
                    case R.id.rbNornal:
                        prio = Task.Prio.NORMAL;
                        break;
                    case R.id.rbHigh:
                        prio = Task.Prio.HIGH;
                        break;
                    case R.id.rbVeryHigh:
                        prio = Task.Prio.VERY_HIGH;
                        break;
                }

                //Если это добавление
                if(bundle == null) {
                    task = new Task(title, desc, owner, prio, startDate, endDate);
                    intent = new Intent(this, TaskListActivity.class);
                    intent.putExtra("task", task);
                }
                //Если это изменение
                else{
                     task = (Task)bundle.getSerializable("task");
                     if(task != null){
                         task.setTitle(title);
                         task.setDescription(desc);
                         task.setOwner(owner);
                         task.setPrio(prio);
                         task.setStartDate(startDate);
                         task.setEndDate(endDate);
                     }
                }

                startActivity(intent);
            } catch (Exception e) { Log.d("MY_LOG", e.getMessage()); }
        }
        else if(v == ibBack){
            startActivity(new Intent(this, TaskListActivity.class));
        }
    }
}
