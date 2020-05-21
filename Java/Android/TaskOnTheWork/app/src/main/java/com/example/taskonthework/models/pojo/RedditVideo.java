
package com.example.taskonthework.models.pojo;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class RedditVideo {

    @SerializedName("fallback_url")
    @Expose
    private String fallbackUrl;
    @SerializedName("height")
    @Expose
    private Integer height;
    @SerializedName("width")
    @Expose
    private Integer width;
    @SerializedName("scrubber_media_url")
    @Expose
    private String scrubberMediaUrl;
    @SerializedName("dash_url")
    @Expose
    private String dashUrl;
    @SerializedName("duration")
    @Expose
    private Integer duration;
    @SerializedName("hls_url")
    @Expose
    private String hlsUrl;
    @SerializedName("is_gif")
    @Expose
    private Boolean isGif;
    @SerializedName("transcoding_status")
    @Expose
    private String transcodingStatus;

    public String getFallbackUrl() {
        return fallbackUrl;
    }

    public void setFallbackUrl(String fallbackUrl) {
        this.fallbackUrl = fallbackUrl;
    }

    public Integer getHeight() {
        return height;
    }

    public void setHeight(Integer height) {
        this.height = height;
    }

    public Integer getWidth() {
        return width;
    }

    public void setWidth(Integer width) {
        this.width = width;
    }

    public String getScrubberMediaUrl() {
        return scrubberMediaUrl;
    }

    public void setScrubberMediaUrl(String scrubberMediaUrl) {
        this.scrubberMediaUrl = scrubberMediaUrl;
    }

    public String getDashUrl() {
        return dashUrl;
    }

    public void setDashUrl(String dashUrl) {
        this.dashUrl = dashUrl;
    }

    public Integer getDuration() {
        return duration;
    }

    public void setDuration(Integer duration) {
        this.duration = duration;
    }

    public String getHlsUrl() {
        return hlsUrl;
    }

    public void setHlsUrl(String hlsUrl) {
        this.hlsUrl = hlsUrl;
    }

    public Boolean getIsGif() {
        return isGif;
    }

    public void setIsGif(Boolean isGif) {
        this.isGif = isGif;
    }

    public String getTranscodingStatus() {
        return transcodingStatus;
    }

    public void setTranscodingStatus(String transcodingStatus) {
        this.transcodingStatus = transcodingStatus;
    }

}
