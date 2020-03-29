package Shop.Models;

public class Product {
    private String name;
    private Double price;

    public Product(String name, Double price) {
        if(name != null && price != null) {
            this.name = name;
            this.price = price;
        }
        else throw new NullPointerException();
    }
    public String getName() {
        return name;
    }

    public Double getPrice() {
        return price;
    }


    @Override
    public String toString() {
        return name + "(" + price + " грн)";
    }
}