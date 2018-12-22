using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatExam1Advanced
{
    class Pilot
    {
        public Dictionary<DateTime, Tuple<bool, int>> Flights { get; private set; }
        public string Name { get; private set; }
        public Pilot(string name = "Empty")
        {
            Name = name;
            Flights = new Dictionary<DateTime, Tuple<bool, int>>();
            AddResultFlights();
        }
        public void ChangeName()
        {
            Console.Write($"Введите имя пилота: ");
            Name = Console.ReadLine();
        }
        public void AddResultFlights(bool Result = false, int amPoints = 0)
        {
            Tuple<bool, int> tuple = new Tuple<bool, int>(Result, amPoints);
            if (Result == false && amPoints == 0) Flights.Add(DateTime.Now, tuple);
            else Flights[Flights.ElementAt(Flights.Count - 1).Key] = tuple;
        }
        public override string ToString()
        {
            StringBuilder flights = new StringBuilder();
            flights.Append(new string('=', 30) + "\n");
            flights.Append($"Имя игрока: {Name},");
            flights.Append($" Посажено: {Flights.Sum(f => (f.Value.Item1 == false)?0:1)}раз, ");
            flights.Append($" Неудач: {Flights.Sum(f => (f.Value.Item1 == true)?0:1)}\n");
            flights.Append(new string('=', 30) + "\n");

            foreach (var item in Flights.Keys)
            {
                flights.Append(item + $": Штрафных очков: {Flights[item].Item2}, ");
                flights.Append($"Посажен: { (Flights[item].Item1 == false ? "Да" : "Нет")}\n");
            }
            flights.Append(new string('=', 30) + "\n");


            return flights.ToString();
        }
    }
}
