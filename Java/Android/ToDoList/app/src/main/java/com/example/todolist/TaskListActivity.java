package com.example.todolist;
import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;

import com.example.todolist.adapters.TaskAdapter;
import com.example.todolist.models.Task;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

public class TaskListActivity extends AppCompatActivity {
    static final private List<Task> taskList = new ArrayList();
    static boolean isTaskListInit = false;
    private ImageButton ibAddTask;
    private RecyclerView rcTasks;
    private ConstraintLayout clTasks;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_task_list);

        initViews();
        initTasks();

        rcTasks.setHasFixedSize(true);
        TaskAdapter taskAdapter = new TaskAdapter(this, taskList);
        rcTasks.setLayoutManager(new LinearLayoutManager(clTasks.getContext()));
        rcTasks.setAdapter(taskAdapter);
        ibAddTask.bringToFront();

        Bundle bundle = getIntent().getExtras();
        if(bundle != null){
            final Task task = (Task)bundle.getSerializable("task");
            final TaskManagerActivity.MODE mode =
                    TaskManagerActivity.MODE.getMode(bundle.getInt("mode"));

            if(task != null ) {
                switch (mode){
                    case ADD:
                        taskList.add(task);
                        taskAdapter.notifyDataSetChanged();
                        break;
                    case EDIT:
                        int index = bundle.getInt("index");
                        Task taskInList = taskList.get(index);
                        taskInList.copy(task);
                        taskAdapter.notifyItemChanged(index);
                        break;
                }
            }
        }
    }

    public void addTask(View view){
        Intent intent = new Intent(this, TaskManagerActivity.class);
        intent.putExtra("mode", TaskManagerActivity.MODE.ADD.getValue());
        startActivity(intent);
    }

    protected void initViews(){
        ibAddTask = findViewById(R.id.ibAddTask);
        rcTasks = findViewById(R.id.rcTasks);
        clTasks = findViewById(R.id.clTasks);
    }

    protected void initTasks(){
        if(!isTaskListInit) {
            final Calendar c = Calendar.getInstance();
            c.add(Calendar.DAY_OF_MONTH, 1);
            taskList.add(new Task("Установить Apache",
                    "Установить Apache и Tomcat для spring`а",
                    "Никита",
                    Task.Prio.VERY_HIGH,
                    new Date(),
                    c.getTime()));
            taskList.add(new Task("Исправить ошибку с раздачей карт",
                    "Изменить направление броска карты",
                    "Никита",
                    Task.Prio.HIGH,
                    new Date(),
                    new Date()));
        }
        isTaskListInit = true;
    }
}
