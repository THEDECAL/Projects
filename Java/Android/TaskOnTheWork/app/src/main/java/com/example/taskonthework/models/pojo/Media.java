
package com.example.taskonthework.models.pojo;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Media {

    @SerializedName("reddit_video")
    @Expose
    private RedditVideo_ redditVideo;

    public RedditVideo_ getRedditVideo() {
        return redditVideo;
    }

    public void setRedditVideo(RedditVideo_ redditVideo) {
        this.redditVideo = redditVideo;
    }

}
