
package com.example.wearether.models.pojo;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class Elevation {

    @SerializedName("Metric")
    @Expose
    public Metric metric;
    @SerializedName("Imperial")
    @Expose
    public Imperial imperial;

}
