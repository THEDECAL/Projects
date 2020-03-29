using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FoodBucket.Models
{
    [Serializable]
    public class Recipe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name { get; set; } = "";
        private string type { get; set; } = "";
        private string country { get; set; } = "";
        private string description { get; set; } = "";
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged(nameof(Country));
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ObservableCollection<string> PathToImages { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<Ingredient> Ingredients { get; set; } = new ObservableCollection<Ingredient>();
        public Recipe(){}
        public Recipe(Recipe r)
        {
            if(r != null) Copy(r);
        }
        public Recipe Copy(Recipe r)
        {
            Name = r.Name;
            Type = r.Type;
            Country = r.Country;
            Description = r.Description;
            PathToImages = new ObservableCollection<string>();
            foreach (var item in r.PathToImages)
            {
                PathToImages.Add(item);
            }
            Ingredients = new ObservableCollection<Ingredient>();
            foreach (var item in r.Ingredients)
            {
                Ingredients.Add(item);
            }

            return this;
        }
        public void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public override string ToString() => $"{Name}({Type}, {Country})";
    }
    [Serializable]
    public class Ingredient : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name { get; set; } = "";
        private double count { get; set; } = 0;
        private string unit { get; set; } = "";
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public double Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                OnPropertyChanged(nameof(Unit));
            }
        }
        public Ingredient() { }
        public void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        public override string ToString() => $"{Name}({Count} {Unit})";
    }
}
