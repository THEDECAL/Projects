using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace practice
{
    enum CarType { Car, SportCar, Truck, Bus };
    class Car
    {
        public CarType Type { get; private set; }
        public string Name { get; private set; }
        public int Speed { get; private set; }
        public int CurrSpeed { get; private set; }
        public int PassedDistance { get; private set; }
        public bool isFinish { get; set; }
        public Car(CarType type,string name, int speed)
        {
            Type = type;
            Name = name;
            Speed = speed;
            PassedDistance = 0;
        }
        public override string ToString()
        {
            return $"{TypeToString()} {Name} приодолел {PassedDistance}м со скоростью {CurrSpeed}м/c";
        }
        public int RSpeed() //Функция генерации случайной скорости
        {
            Random rSpeed = new Random();
            Thread.Sleep(10);
            int maxSpeed = Speed;
            int minSpeed = maxSpeed / 100 * 80; //80% минимальная скорость
            return rSpeed.Next(minSpeed,maxSpeed);
        }
        public int RunOneStep() //Запуск одного шага передвижения
        {
            return PassedDistance+=(CurrSpeed=RSpeed());
        }
        public string TypeToString()
        {
            switch (Type)
            {
                case CarType.Car:
                    return "Автомобиль";
                case CarType.SportCar:
                    return "Спорткар";
                case CarType.Truck:
                    return "Грузовик";
                case CarType.Bus:
                    return "Автобус";
                default:
                    return "Машина";
            }
        } //Преобразование типа транспорта в строку
    }
    class Game
    {
        int amFinished;
        public int CommonDistance { get; private set; }
        Func<int> RunAll;
        Car[] Cars = new Car[0];
        public Game(int commonDistance)
        {
            amFinished = 0;
            CommonDistance = commonDistance;
        }
        public Game(int commonDistance, Car[] cars):this(commonDistance)
        {
            foreach (var item in cars) AddCar(item);
        }
        public void AddCar(Car car)
        {
            Array.Resize(ref Cars, Cars.Length + 1);
            Cars[Cars.Length - 1] = car;
            RunAll += Cars[Cars.Length - 1].RunOneStep;
        }
        public void Start()
        {
            if (Cars.Length != 0)
            {
                while(amFinished <= Cars.Length - 1)
                {
                    foreach (Func<int> item in RunAll.GetInvocationList())
                    {
                        Car temp = (Car)item.Target;
                        if (item() >= CommonDistance && temp.isFinish == false)
                        {
                            temp.isFinish = true;
                            Console.WriteLine($"{temp} и финишировал ({++amFinished}-е место)");
                        }
                        if (temp.isFinish == false) Console.WriteLine(temp);
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Game game = new Game(500, new Car[] {
                new Car(CarType.Car, "Tayota", 170),
                new Car(CarType.SportCar, "Lamborgini", 200),
                new Car(CarType.Truck, "MAN", 150),
                new Car(CarType.Bus, "Икарус", 140)
            });

            game.Start();
        }
    }
}
