
package com.example.wearether.models.pojo;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class TimeZone {

    @SerializedName("Code")
    @Expose
    public String code;
    @SerializedName("Name")
    @Expose
    public String name;
    @SerializedName("GmtOffset")
    @Expose
    public Double gmtOffset;
    @SerializedName("IsDaylightSaving")
    @Expose
    public Boolean isDaylightSaving;
    @SerializedName("NextOffsetChange")
    @Expose
    public String nextOffsetChange;

}
