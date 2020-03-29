package com.example.wearether.retrofit;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class WeatherServiceHelper {
    static public final String weatherSiteUrl = "http://dataservice.accuweather.com";
    static public final String apiKey = "vtpYNknXzxA1tBZX3DpGYZUdLAeO9AE0";

    static private WeatherServiceHelper instance;
    static private Retrofit retrofit;
    static private WeatherService weatherService;

    private WeatherServiceHelper(){
        retrofit = new Retrofit.Builder()
                .baseUrl(weatherSiteUrl)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        weatherService = retrofit.create(WeatherService.class);
    }

    static public WeatherServiceHelper getInstance(){
        return (instance == null) ? new WeatherServiceHelper() : instance;
    }

    public WeatherService getWeatherService(){ return weatherService; }
}
