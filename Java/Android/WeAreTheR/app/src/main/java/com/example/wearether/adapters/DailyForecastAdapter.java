package com.example.wearether.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.databinding.DataBindingUtil;
import androidx.recyclerview.widget.RecyclerView;

import com.example.wearether.R;
import com.example.wearether.databinding.DailyForecastBinding;
import com.example.wearether.databinding.PlaceItemBinding;
import com.example.wearether.models.pojo.DailyForecast;
import com.example.wearether.models.pojo.Place;
import com.squareup.picasso.Picasso;

import java.util.List;

import lombok.val;

public class DailyForecastAdapter extends RecyclerView.Adapter<DailyForecastAdapter.ForecastHolder> {
    static public class ForecastHolder extends RecyclerView.ViewHolder{
        DailyForecastBinding binding;

        public ForecastHolder(DailyForecastBinding binding){
            super(binding.getRoot());
            this.binding = binding;
        }

        public void bind(DailyForecast forecast){
            binding.setModel(forecast);
            binding.executePendingBindings();
        }
    }
    static private List<DailyForecast> forecastList;
    private LayoutInflater inflater;


    public DailyForecastAdapter(Context context, List<DailyForecast> forecastList){
        inflater = LayoutInflater.from(context);
        setForecastsList(forecastList);
    }

    public void setForecastsList(List<DailyForecast> forecastList) {
        this.forecastList = forecastList;
        notifyDataSetChanged();
    }

    @NonNull
    @Override
    public ForecastHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        DailyForecastBinding binding = DataBindingUtil.inflate(inflater,
                R.layout.daily_forecast, parent, false);
        return new DailyForecastAdapter.ForecastHolder(binding);
    }

    @Override
    public void onBindViewHolder(@NonNull ForecastHolder holder, int position) {
        val forecast = forecastList.get(position);
        val refPreFix = "http://apidev.accuweather.com/developers/Media/Default/WeatherIcons/";//33-s.png";
        val refPostFix = "-s.png";
        val dayPathImage = refPreFix + ((forecast.getDay().getIcon() < 10)
                ? "0" + String.valueOf(forecast.getDay().getIcon())
                : String.valueOf(forecast.getDay().getIcon())) + refPostFix;
        val nightPathImage = refPreFix + ((forecast.getNight().getIcon() < 10)
                ? "0" + String.valueOf(forecast.getNight().getIcon())
                : String.valueOf(forecast.getNight().getIcon())) + refPostFix;
        holder.bind(forecast);

        Picasso.get().load(dayPathImage).resize(240,240)
                .centerCrop().into(holder.binding.ivDay);
        Picasso.get().load(nightPathImage).resize(240,240)
                .centerCrop().into(holder.binding.ivNight);
    }

    @Override
    public int getItemCount() { return forecastList.size(); }
}
