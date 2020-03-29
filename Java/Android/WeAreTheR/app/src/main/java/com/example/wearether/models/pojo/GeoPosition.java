
package com.example.wearether.models.pojo;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class GeoPosition {

    @SerializedName("Latitude")
    @Expose
    public Double latitude;
    @SerializedName("Longitude")
    @Expose
    public Double longitude;
    @SerializedName("Elevation")
    @Expose
    public Elevation elevation;

}
