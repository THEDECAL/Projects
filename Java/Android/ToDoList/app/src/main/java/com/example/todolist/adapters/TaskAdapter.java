package com.example.todolist.adapters;
import android.content.Context;
import android.content.Intent;
import android.content.res.ColorStateList;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.ImageButton;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;
import com.example.todolist.R;
import com.example.todolist.TaskManagerActivity;
import com.example.todolist.models.Task;

import java.util.Date;
import java.util.List;

public class TaskAdapter extends RecyclerView.Adapter<TaskAdapter.TaskViewHolder> {
    private LayoutInflater inflater;
    private List<Task> taskList;

    public static class TaskViewHolder extends RecyclerView.ViewHolder {
        public TextView tvItemTitle;
        public CheckBox cbComplete;
        public View vColorPrio;
        public ImageButton ibDel, ibShow;
        public ConstraintLayout clTask;

        public TaskViewHolder(@NonNull View v) {
            super(v);

            tvItemTitle = v.findViewById(R.id.tvItemTitle);
            cbComplete = v.findViewById(R.id.cbComplete);
            vColorPrio = v.findViewById(R.id.vColorPrio);
            ibDel = v.findViewById(R.id.ibDel);
            ibShow = v.findViewById(R.id.ibShow);
            clTask = v.findViewById(R.id.clTask);
        }
    }

    public TaskAdapter(Context context, List<Task> taskList){
        this.taskList = taskList;
        inflater = LayoutInflater.from(context);
    }

    @NonNull
    @Override
    public TaskViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = inflater.inflate(R.layout.task_item, parent, false);
        return new TaskViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull TaskViewHolder holder, final int position) {
        Task task = taskList.get(position);
        holder.tvItemTitle.setText(task.getTitle());
        holder.cbComplete.setChecked(!task.getIsActive());
        int color = inflater.getContext().getResources().getColor(task.getPrio().getValue());
        holder.vColorPrio.setBackgroundColor(color);
        holder.ibDel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                taskList.remove(position);
                notifyItemRemoved(position);
            }
        });
        holder.ibShow.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(inflater.getContext(), TaskManagerActivity.class);
                intent.putExtra("mode", TaskManagerActivity.MODE.SHOW.getValue());
                intent.putExtra("task", taskList.get(position));
                inflater.getContext().startActivity(intent);
            }
        });
        holder.clTask.setOnLongClickListener(new View.OnLongClickListener() {
            @Override
            public boolean onLongClick(View v) {
                Intent intent = new Intent(inflater.getContext(), TaskManagerActivity.class);
                intent.putExtra("mode", TaskManagerActivity.MODE.EDIT.getValue());
                intent.putExtra("task", taskList.get(position));
                intent.putExtra("index", position);
                inflater.getContext().startActivity(intent);
                return false;
            }
        });
        holder.cbComplete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                CheckBox cb = (CheckBox)v;
                Task task = taskList.get(position);
                task.setIsActive(cb.isChecked());
            }
        });
        //Если задание просрочено не показывать чекбокс
        if(task.getEndDate().compareTo(new Date()) < 0) {
            holder.cbComplete.setVisibility(View.INVISIBLE);
        }
    }

    @Override
    public int getItemCount() { return taskList.size(); }
}
