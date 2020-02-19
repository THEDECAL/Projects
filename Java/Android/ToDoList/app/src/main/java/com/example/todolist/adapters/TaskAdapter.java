package com.example.todolist.adapters;
import android.content.Context;
import android.content.Intent;
import android.content.res.ColorStateList;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.ImageButton;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.recyclerview.widget.RecyclerView;
import com.example.todolist.R;
import com.example.todolist.TaskManagerActivity;
import com.example.todolist.models.Task;
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
    public TaskAdapter.TaskViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = inflater.inflate(R.layout.task_item, parent, false);
        return new TaskViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull TaskAdapter.TaskViewHolder holder, final int position) {
        Task task = taskList.get(position);
        holder.tvItemTitle.setText(task.getTitle());
        holder.cbComplete.setChecked(task.getIsActive());
        holder.vColorPrio.setBackgroundColor(task.getPrio().getColor());
        holder.ibDel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) { taskList.remove(position); }
        });
        holder.ibShow.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(inflater.getContext(), TaskManagerActivity.class);
                intent.putExtra("mode", TaskManagerActivity.MODE.SHOW);
                intent.putExtra("task", taskList.get(position));
                inflater.getContext().startActivity(intent);
            }
        });
        holder.clTask.setOnLongClickListener(new View.OnLongClickListener() {
            @Override
            public boolean onLongClick(View v) {
                Intent intent = new Intent(inflater.getContext(), TaskManagerActivity.class);
                intent.putExtra("task", taskList.get(position));
                inflater.getContext().startActivity(intent);
                return false;
            }
        });

        //Если задание просрочено
        if(task.getStartDate().compareTo(task.getEndDate()) >= 0) {
            holder.cbComplete.setEnabled(false);
            holder.cbComplete.setButtonTintList(new ColorStateList(
                    new int[][]{new int[]{android.R.attr.state_pressed}},
                    new int[]{inflater.getContext().getResources().getColor(R.color.EXPIRE_COLOR)}
            ));
        }
        Log.d("MY_LOG", "onBindViewHolder() runned");
    }

    @Override
    public int getItemCount() { return taskList.size(); }
}
