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

        private Integer color;

        Prio(Integer color){ this.color = color; }
        public Integer getColor(){ return color; }
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
}
