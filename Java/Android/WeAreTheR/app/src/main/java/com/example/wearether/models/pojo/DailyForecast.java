
package com.example.wearether.models.pojo;

import java.sql.Date;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.format.DateTimeFormatter;
import java.util.List;
import java.util.Locale;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import lombok.val;

public class DailyForecast {

    @SerializedName("Date")
    @Expose
    private String date;
    @SerializedName("EpochDate")
    @Expose
    private Integer epochDate;
    @SerializedName("Temperature")
    @Expose
    private Temperature temperature;
    @SerializedName("Day")
    @Expose
    private Day day;
    @SerializedName("Night")
    @Expose
    private Night night;
    @SerializedName("Sources")
    @Expose
    private List<String> sources = null;
    @SerializedName("MobileLink")
    @Expose
    private String mobileLink;
    @SerializedName("Link")
    @Expose
    private String link;

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public Integer getEpochDate() {
        return epochDate;
    }

    public void setEpochDate(Integer epochDate) {
        this.epochDate = epochDate;
    }

    public Temperature getTemperature() {
        return temperature;
    }

    public void setTemperature(Temperature temperature) {
        this.temperature = temperature;
    }

    public Day getDay() {
        return day;
    }

    public void setDay(Day day) {
        this.day = day;
    }

    public Night getNight() {
        return night;
    }

    public void setNight(Night night) {
        this.night = night;
    }

    public List<String> getSources() {
        return sources;
    }

    public void setSources(List<String> sources) {
        this.sources = sources;
    }

    public String getMobileLink() {
        return mobileLink;
    }

    public void setMobileLink(String mobileLink) {
        this.mobileLink = mobileLink;
    }

    public String getLink() {
        return link;
    }

    public void setLink(String link) {
        this.link = link;
    }

    public String getWeekDay(){
        try {
            val inputFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ssZ");
            val outputFormat = new SimpleDateFormat("E",  new Locale("ru"));
            val d = inputFormat.parse(date);
            return outputFormat.format(d).toUpperCase();
        } catch (ParseException e) {}

        return "";
    }

    public String getMonthDay(){
        try {
            val inputFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ssZ");
            val outputFormat = new SimpleDateFormat("d MMMM", new Locale("ru"));
            val d = inputFormat.parse(date);
            return outputFormat.format(d).toUpperCase();
        } catch (ParseException e) {}

        return "";
    }
}
