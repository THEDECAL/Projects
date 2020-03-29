package models;
import lombok.AllArgsConstructor;
import lombok.Data;

@lombok.AllArgsConstructor
@lombok.Data
public class Phone {
    String brand;
    String model;
    String imgName;
    Double price;
}
