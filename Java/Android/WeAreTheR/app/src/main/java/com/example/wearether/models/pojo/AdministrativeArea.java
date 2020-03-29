
package com.example.wearether.models.pojo;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class AdministrativeArea {

    @SerializedName("ID")
    @Expose
    public String iD;
    @SerializedName("LocalizedName")
    @Expose
    public String localizedName;
    @SerializedName("EnglishName")
    @Expose
    public String englishName;
    @SerializedName("Level")
    @Expose
    public Integer level;
    @SerializedName("LocalizedType")
    @Expose
    public String localizedType;
    @SerializedName("EnglishType")
    @Expose
    public String englishType;
    @SerializedName("CountryID")
    @Expose
    public String countryID;

}
