
package com.example.taskonthework.models.pojo;

import java.util.List;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class AllAwarding {

    @SerializedName("giver_coin_reward")
    @Expose
    private Integer giverCoinReward;
    @SerializedName("subreddit_id")
    @Expose
    private Object subredditId;
    @SerializedName("is_new")
    @Expose
    private Boolean isNew;
    @SerializedName("days_of_drip_extension")
    @Expose
    private Integer daysOfDripExtension;
    @SerializedName("coin_price")
    @Expose
    private Integer coinPrice;
    @SerializedName("id")
    @Expose
    private String id;
    @SerializedName("penny_donate")
    @Expose
    private Integer pennyDonate;
    @SerializedName("coin_reward")
    @Expose
    private Integer coinReward;
    @SerializedName("icon_url")
    @Expose
    private String iconUrl;
    @SerializedName("days_of_premium")
    @Expose
    private Integer daysOfPremium;
    @SerializedName("icon_height")
    @Expose
    private Integer iconHeight;
    @SerializedName("resized_icons")
    @Expose
    private List<ResizedIcon> resizedIcons = null;
    @SerializedName("icon_width")
    @Expose
    private Integer iconWidth;
    @SerializedName("start_date")
    @Expose
    private Object startDate;
    @SerializedName("is_enabled")
    @Expose
    private Boolean isEnabled;
    @SerializedName("description")
    @Expose
    private String description;
    @SerializedName("end_date")
    @Expose
    private Object endDate;
    @SerializedName("subreddit_coin_reward")
    @Expose
    private Integer subredditCoinReward;
    @SerializedName("count")
    @Expose
    private Integer count;
    @SerializedName("name")
    @Expose
    private String name;
    @SerializedName("icon_format")
    @Expose
    private String iconFormat;
    @SerializedName("award_sub_type")
    @Expose
    private String awardSubType;
    @SerializedName("penny_price")
    @Expose
    private Integer pennyPrice;
    @SerializedName("award_type")
    @Expose
    private String awardType;

    public Integer getGiverCoinReward() {
        return giverCoinReward;
    }

    public void setGiverCoinReward(Integer giverCoinReward) {
        this.giverCoinReward = giverCoinReward;
    }

    public Object getSubredditId() {
        return subredditId;
    }

    public void setSubredditId(Object subredditId) {
        this.subredditId = subredditId;
    }

    public Boolean getIsNew() {
        return isNew;
    }

    public void setIsNew(Boolean isNew) {
        this.isNew = isNew;
    }

    public Integer getDaysOfDripExtension() {
        return daysOfDripExtension;
    }

    public void setDaysOfDripExtension(Integer daysOfDripExtension) {
        this.daysOfDripExtension = daysOfDripExtension;
    }

    public Integer getCoinPrice() {
        return coinPrice;
    }

    public void setCoinPrice(Integer coinPrice) {
        this.coinPrice = coinPrice;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Integer getPennyDonate() {
        return pennyDonate;
    }

    public void setPennyDonate(Integer pennyDonate) {
        this.pennyDonate = pennyDonate;
    }

    public Integer getCoinReward() {
        return coinReward;
    }

    public void setCoinReward(Integer coinReward) {
        this.coinReward = coinReward;
    }

    public String getIconUrl() {
        return iconUrl;
    }

    public void setIconUrl(String iconUrl) {
        this.iconUrl = iconUrl;
    }

    public Integer getDaysOfPremium() {
        return daysOfPremium;
    }

    public void setDaysOfPremium(Integer daysOfPremium) {
        this.daysOfPremium = daysOfPremium;
    }

    public Integer getIconHeight() {
        return iconHeight;
    }

    public void setIconHeight(Integer iconHeight) {
        this.iconHeight = iconHeight;
    }

    public List<ResizedIcon> getResizedIcons() {
        return resizedIcons;
    }

    public void setResizedIcons(List<ResizedIcon> resizedIcons) {
        this.resizedIcons = resizedIcons;
    }

    public Integer getIconWidth() {
        return iconWidth;
    }

    public void setIconWidth(Integer iconWidth) {
        this.iconWidth = iconWidth;
    }

    public Object getStartDate() {
        return startDate;
    }

    public void setStartDate(Object startDate) {
        this.startDate = startDate;
    }

    public Boolean getIsEnabled() {
        return isEnabled;
    }

    public void setIsEnabled(Boolean isEnabled) {
        this.isEnabled = isEnabled;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Object getEndDate() {
        return endDate;
    }

    public void setEndDate(Object endDate) {
        this.endDate = endDate;
    }

    public Integer getSubredditCoinReward() {
        return subredditCoinReward;
    }

    public void setSubredditCoinReward(Integer subredditCoinReward) {
        this.subredditCoinReward = subredditCoinReward;
    }

    public Integer getCount() {
        return count;
    }

    public void setCount(Integer count) {
        this.count = count;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getIconFormat() {
        return iconFormat;
    }

    public void setIconFormat(String iconFormat) {
        this.iconFormat = iconFormat;
    }

    public String getAwardSubType() {
        return awardSubType;
    }

    public void setAwardSubType(String awardSubType) {
        this.awardSubType = awardSubType;
    }

    public Integer getPennyPrice() {
        return pennyPrice;
    }

    public void setPennyPrice(Integer pennyPrice) {
        this.pennyPrice = pennyPrice;
    }

    public String getAwardType() {
        return awardType;
    }

    public void setAwardType(String awardType) {
        this.awardType = awardType;
    }

}
