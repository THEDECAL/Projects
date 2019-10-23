using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShipsAndThreads
{
    public enum CargoType { Bread, Banana, Clothes };
    public enum Capacity { _10 = 10, _50 = 50, _100 = 100 };
    [Synchronization()]
    public class Ship
    {
        static string[] _cargoNames = null;
        public string Name { get; private set; } = "";
        public Capacity Capacity { get; private set; }
        public CargoType Cargo { get; private set; }
        //public int Congestion { get; set; }
        //public bool IsFullCongestion { get => (Congestion == (int)Capacity); }
        public Ship() { }
        public Ship(string name, Capacity capacity, CargoType cargo)
        {
            Name = name;
            Capacity = capacity;
            Cargo = cargo;

            if (_cargoNames == null)
                _cargoNames = new string[] { "Хлеб", "Бананы", "Одежда"};
        }
        public override string ToString() => (Name == "") ? "Пусто" : $"{Name} ({_cargoNames[(int)Cargo]} {(int)Capacity})";
    }
}
