using System;
using System.Text;

namespace task2
{
    abstract class Article
    {
        public string Name { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public Article() { }
        public Article(string name, double width, double height, double weight)
        {
            Name = name;
            Width = width;
            Height = height;
            Weight = weight;
        }
    }
    class DomesticChemical : Article
    {
        public DateTime DateOfManufacture { get; set; }
        public uint DaysShelfLife { get; set; }
        string[] _surfactant;
        public DomesticChemical() { _surfactant = new string[0]; }
        public DomesticChemical(
            DateTime dateOfManufacture,
            uint daysShelfLife,
            string[] surfactant)
        {
            _surfactant = surfactant;
            DateOfManufacture = dateOfManufacture;
            DaysShelfLife = daysShelfLife;
        }
    }
    class Food : Article
    {
        public DateTime DateOfManufacture { get; set; }
        public uint DaysShelfLife { get; set; }
        double _calories;
        double _proteins;
        double _fats;
        double _carbohydrates;
        public Food() { }
        public Food(
            DateTime dateOfManufacture,
            uint daysShelfLife,
            double calories,
            double proteins,
            double fats,
            double carbohydrates)
        {
            DateOfManufacture = dateOfManufacture;
            DaysShelfLife = daysShelfLife;
            _calories = calories;
            _proteins = proteins;
            _fats = fats;
            _carbohydrates = carbohydrates;
        }
    }
    class Reception //Получение товара
    {
        public Article _Article { get; set; }
        public uint Amount { get; set; }
        public DateTime Date { get; set; }
    }
    class Sales : Reception //Реализация товара
    {

    }
    class WriteOff : Reception //Списание товара
    {

    }
    class Transferred : Reception //Передача товара
    {

    }
    //class UnitStock
    //{
    //    Article article;
    //    public uint CurrAmount { get; set; }
    //    DateTime dateOfDelivery;
    //}
    //class Stock
    //{
    //    public UnitStock[] stock;
    //}
    class Program
    {
        static void Main()
        {
            
        }
    }
}
