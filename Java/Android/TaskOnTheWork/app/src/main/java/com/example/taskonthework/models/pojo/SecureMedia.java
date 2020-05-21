
package com.example.taskonthework.models.pojo;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class SecureMedia {

    @SerializedName("reddit_video")
    @Expose
    private RedditVideo redditVideo;

    public RedditVideo getRedditVideo() {
        return redditVideo;
    }

    public void setRedditVideo(RedditVideo redditVideo) {
        this.redditVideo = redditVideo;
    }

}
