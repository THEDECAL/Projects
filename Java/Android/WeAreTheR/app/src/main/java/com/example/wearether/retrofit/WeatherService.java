package com.example.wearether.retrofit;

import com.example.wearether.models.pojo.Place;
import com.example.wearether.models.pojo.WeatherForecast;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;
import retrofit2.http.Query;

/**
 * http://dataservice.accuweather.com/locations/v1/cities/translate.json?q=%D0%A2%D0%B5%D1%80%D0%BD%D0%BE%D0%B2%D0%BA%D0%B0&language=ru-ua&apikey=vtpYNknXzxA1tBZX3DpGYZUdLAeO9AE0
 * http://dataservice.accuweather.com/forecasts/v1/daily/5day/322527?apikey=vtpYNknXzxA1tBZX3DpGYZUdLAeO9AE0&language=ru-ru&deatils=true
 */
public interface WeatherService {
    @GET("locations/v1/cities/translate.json")
    Call<List<Place>> getPlacesByQuery(@Query(value = "q", encoded = true) String query,
                                       @Query("language") String lang,
                                       @Query("apikey") String apiKey);
    @GET("forecasts/v1/daily/5day/{placeid}")
    Call<WeatherForecast> getForecastByPlaceId(@Path("placeid") String placeId,
                                                    @Query("language") String lang,
                                                    @Query("apikey") String apiKey,
                                                    @Query("details") String details);
}
