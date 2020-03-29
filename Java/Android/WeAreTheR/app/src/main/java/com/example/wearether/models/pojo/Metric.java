
package com.example.wearether.models.pojo;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class Metric {

    @SerializedName("Value")
    @Expose
    public Double value;
    @SerializedName("Unit")
    @Expose
    public String unit;
    @SerializedName("UnitType")
    @Expose
    public Integer unitType;

}
