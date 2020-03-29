package localhost.myapplication.models;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

public class Phone {
    private String brand;
    private String model;
    private Double price;

    public Phone(){}
    public Phone(String brand, String model, Double price){
        this.brand = brand;
        this.model = model;
        this.price = price;
    }

    public String getBrand() { return brand; }
    public void setBrand(String brand) { this.brand = brand; }
    public String getModel() { return model; }
    public void setModel(String model) { this.model = model; }
    public Double getPrice() { return price; }
    public void setPrice(Double price) { this.price = price; }

    @Override
    public boolean equals(@Nullable Object obj) {
        Phone p = (Phone)obj;
        return p.getBrand() == this.getBrand() &&
                p.getModel() == this.getModel() &&
                p.getPrice() == this.getPrice();
    }

    @NonNull
    @Override
    protected Object clone() throws CloneNotSupportedException {
        return new Phone(this.brand, this.model, this.price);
    }
}
