package com.example.todolist.models;

import com.example.todolist.R;

import java.io.Serializable;
import java.util.Date;

public class Task implements Serializable {
    public enum Prio{
        VERY_LOW(R.color.VERY_LOW_PRIO),
        LOW(R.color.LOW_PRIO),
        NORMAL(R.color.NORMAL_PRIO),
        HIGH(R.color.HIGH_PRIO),
        VERY_HIGH(R.color.VERY_HIGH_PRIO);
        private int value;

        Prio(Integer color){ this.value = color; }
        public Integer getValue(){ return value; }
        static public Prio getPrio(int value){
            for (Prio p: Prio.values()) {
                if(p.getValue() == value)
                    return p;
            }
            return null;
        }
    }

    private String title;
    private String description;
    private String owner;
    private Date dateOfCreation = new Date();
    private Date startDate;
    private Date endDate;
    private Boolean isActive = true;
    private Prio prio = Prio.NORMAL;

    public Task(String title, String description, String owner, Prio prio, Date startDate, Date endDate){
        this.title = title;
        this.description = description;
        this.owner = owner;
        this.prio = prio;
        this.startDate = startDate;
        this.endDate = endDate;
    }
    /* Геттеры и Сеттеры */
    public String getTitle() { return title; }
    public void setTitle(String title) { this.title = title; }
    public String getDescription() { return description; }
    public void setDescription(String description) { this.description = description; }
    public Boolean getIsActive() { return isActive; }
    public void setIsActive(Boolean state) { this.isActive = state; }
    public Prio getPrio() { return prio; }
    public void setPrio(Prio prio) { this.prio = prio; }
    public Date getDateOfCreation() { return dateOfCreation; }
    public Date getStartDate() { return startDate; }
    public void setStartDate(Date startDate) { this.startDate = startDate; }
    public Date getEndDate() { return endDate; }
    public void setEndDate(Date endDate) { this.endDate = endDate; }
    public String getOwner() { return owner; }
    public void setOwner(String owner) { this.owner = owner; }

    public void copy(Task task){
        this.title = task.getTitle();
        this.description = task.getDescription();
        this.owner = task.getOwner();
        this.prio = task.getPrio();
        this.startDate = task.getStartDate();
        this.endDate = task.getEndDate();
        this.isActive = task.getIsActive();
    }
}
