package com.example.todolist;
import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ImageButton;

import com.example.todolist.adapters.TaskAdapter;
import com.example.todolist.models.Task;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class TaskListActivity extends AppCompatActivity {
    final private List<Task> taskList = new ArrayList();
    private ImageButton ibAddTask;
    private RecyclerView rcTasks;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getSupportActionBar().hide();
        setContentView(R.layout.activity_task_list);

        initViews();
        initTasks();

        rcTasks.setHasFixedSize(true);
        //rcTasks.setLayoutManager(new LinearLayoutManager(this));
        rcTasks.setAdapter(new TaskAdapter(this, taskList));

        Bundle bundle = getIntent().getExtras();
        if(bundle != null){
            final Task task = (Task)bundle.getSerializable("task");

            if(task != null) {
                taskList.add(task);
                Log.d("MY_LOG", "Task #" + (taskList.indexOf(task) + 1) + " added");
            }
        }
    }

    public void addTask(View view){
        startActivity(new Intent(this, TaskManagerActivity.class));
    }

    protected void initViews(){
        ibAddTask = findViewById(R.id.ibAddTask);
        rcTasks = findViewById(R.id.rcTasks);
    }

    protected void initTasks(){
        taskList.add(new Task("Исправить ошибку с раздачей карт",
                "Изменить направление броска карты",
                "Никита" ,
                Task.Prio.HIGH,
                new Date(),
                new Date()));
    }
}
