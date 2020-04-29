
package com.example.wearether.models.pojo;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.text.DecimalFormat;

import lombok.val;

public class Temperature {
    @SerializedName("Minimum")
    @Expose
    private Minimum minimum;
    @SerializedName("Maximum")
    @Expose
    private Maximum maximum;

    public Minimum getMinimum() {
        return minimum;
    }

    public void setMinimum(Minimum minimum) {
        this.minimum = minimum;
    }

    public Maximum getMaximum() {
        return maximum;
    }

    public void setMaximum(Maximum maximum) {
        this.maximum = maximum;
    }

    public String getMinCelsius(){
        val tFormat = new DecimalFormat("##0.0");
        return tFormat.format(toCelsius(minimum.getValue())) + " °C";
    }

    public String getMaxCelsius(){
        val tFormat = new DecimalFormat("##0.0");
        return tFormat.format(toCelsius(maximum.getValue())) + " °C";
    }

    public Double toCelsius(Double farengate){ return (farengate - 32) * 5 / 9; }
}
