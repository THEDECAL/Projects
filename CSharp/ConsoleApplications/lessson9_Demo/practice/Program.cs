using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    public class Car
    {
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Выберает все машины из списка по стоимости больше заданой
        /// </summary>
        /// <param name="list">
        /// Список машин
        /// </param>
        /// <param name="price">
        /// Стоимость
        /// </param>
        /// <returns>
        /// Список выбранных машин
        /// </returns>
        public static List<Car> ListCarOverPrice(List<Car> list, decimal price)
        {
            return list.Where(car => car.Price > price).ToList<Car>();
        }
        /// <summary>
        /// Выберает машины из списка по заданному цвету
        /// </summary>
        /// <param name="list">
        /// Список машин
        /// </param>
        /// <param name="color">
        /// Цвет
        /// </param>
        /// <returns>
        /// Список выбранных машин
        /// </returns>
        public static List<Car> ListByColor(List<Car> list, string color)
        {
            return list.Where(car => car.Color == color).ToList<Car>();
        }
        /// <summary>
        /// Выберает машины из списка по заданной стоимости и марке
        /// </summary>
        /// <param name="list">
        /// Список машин
        /// </param>
        /// <param name="tuple">
        /// Кортеж где:
        /// Item1 - Стоимость
        /// Item2 - Марка
        /// </param>
        /// <returns>
        /// Список выбранных машин
        /// </returns>
        public static List<Car> ListByPriceAndBrand(List<Car> list, Tuple<decimal, string> tuple)
        {
            return list.Where(car => car.Price == tuple.Item1 && car.Brand == tuple.Item2).ToList<Car>();
        }
        /// <summary>
        /// Сумма стоимости машин из списка
        /// </summary>
        /// <param name="list">
        /// Список машин
        /// </param>
        /// <returns>
        /// Сумма цен
        /// </returns>
        public static decimal SumCarPrice(List<Car> list)
        {
            return list.Sum(car => car.Price);
        }
        /// <summary>
        /// Количество машин по заданному цвету
        /// </summary>
        /// <param name="list">
        /// Список машин
        /// </param>
        /// <param name="color">
        /// Цвет
        /// </param>
        /// <returns>
        /// Количество машин
        /// </returns>
        public static int AmountCarByColor(List<Car> list, string color)
        {
            return list.Where(car => car.Color == color).Count();
        }
        /// <summary>
        /// Выберает все машины из списка по стоимости ниже заданной
        /// </summary>
        /// <param name="list">
        /// Список машин
        /// </param>
        /// <param name="price">
        /// Цена
        /// </param>
        /// <returns>
        /// Анонимный объект с полями марки и модели машины
        /// </returns>
        public static List<string> ListCarBelowPrice(List<Car> list, decimal price)
        {
            return list.Where(car => car.Price < price).Select(car => $"{car.Brand} {car.Model}").ToList<string>();
        }
        /// <summary>
        /// Количество машин из списка по цвету и диапазону стоимости
        /// </summary>
        /// <param name="list">
        /// Список машин
        /// </param>
        /// <param name="rangePrice">
        /// Кортеж диапазона цен где:
        /// Item1 - от стоимости
        /// Item2 - до стоимости
        /// </param>
        /// <param name="colors">
        /// Список цветов
        /// </param>
        /// <returns>
        /// Словарь где:
        /// TKey - Цвет
        /// TValue - Количество машин
        /// </returns>
        public static Dictionary<string, int> AmountCarByColorAndRangePrice(List<Car> list, Tuple<decimal,decimal> rangePrice, List<string> colors)
        {
            Dictionary<string, int> amountCarByColor = new Dictionary<string, int>();
            //Список машин из диапазона цен
            List<Car> listByRangePrice = list.Where(car => car.Price >= rangePrice.Item1 && car.Price < rangePrice.Item2 ).ToList<Car>();

            foreach (var color in colors)
            {
                //Количество машин по цвету
                int amCars = listByRangePrice.Where(car => car.Color == color).Count();
                amountCarByColor.Add(color, amCars);
            }

            return amountCarByColor;
        }
        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();

            temp.Append("Цвет: " + Color + '\n');
            temp.Append("Марка: " + Brand + '\n');
            temp.Append("Модель: " + Model + '\n');
            temp.Append("Цена: " + Price + '\n');

            return temp.ToString();
        }
    }
    class Program
    {
        static void Main()
        {
            string[] carColors = new string[]{ "Красный", "Зелёный", "Чёрный", "Коричневый", "Жёлтый", "Белый" };
            string[] carBrands = new string[] { "BMW", "Wolksvagen", "Mercedes", "Lada", "Tayota", "Mitsubishi" };
            Random r = new Random();
            List<Car> listCars = new List<Car>();

            //Генерируем 36 машин
            for (int i = 0; i < 36; i++)
            {
                listCars.Add(new Car
                {
                    Color = carColors[r.Next(0, carColors.Length)],
                    Brand = carBrands[r.Next(0, carBrands.Length)],
                    Model = new string((char)r.Next(65, 91 + 1), 3) + '-' + r.Next(10),
                    Price = (r.Next(1, 16) * 1000)
                });
            }

            //Список машин
            foreach (var item in listCars)
                Console.WriteLine(item);

            //1.Выбрать все машины у которых цена больше 10_000
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("1. Выбрать все машины у которых цена больше 10_000");
            Console.WriteLine(new string('-',20));
            foreach (Car car in Car.ListCarOverPrice(listCars, 10000))
                Console.WriteLine(car);

            //2.Выбрать все машины красного цвета
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("2. Выбрать все машины красного цвета");
            Console.WriteLine(new string('-', 20));
            foreach (Car car in Car.ListByColor(listCars, "Красный"))
                Console.WriteLine(car);

            //3.Выбрать все машины по заданной цене и марке машины
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("3. Выбрать все машины по заданной цене и марке машины");
            Console.WriteLine(new string('-', 20));
            foreach (Car car in Car.ListByPriceAndBrand(listCars,Tuple.Create((decimal)10000, "Mercedes")))
                Console.WriteLine(car);

            //4.Вывести сумму стоимости всех машин
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("4. Вывести сумму стоимости всех машин");
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(Car.SumCarPrice(listCars));

            //5.Вывести сколько машин красного цвета
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("5. Вывести сколько машин красного цвета");
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(Car.AmountCarByColor(listCars, "Красный"));

            //6.Выбрать все дешевые машины(цена < 5_000) и при помощи проекция выбрать только марку и модель машин
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("6. Выбрать все дешевые машины(цена < 5_000) и при помощи проекция выбрать только марку и модель машин");
            Console.WriteLine(new string('-', 20));
            foreach (string car in Car.ListCarBelowPrice(listCars, (decimal)5000))
                Console.WriteLine(car);


            //7.Выбрать все машины(по цене) в диапазоне заданным пользователем и посчитайте сколько машин красного, черного цвета
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("7. Выбрать все машины(по цене) в диапазоне заданным пользователем и посчитайте сколько машин красного, черного цвета");
            Console.WriteLine(new string('-', 20));
            Dictionary<string,int> dicAmColors = Car.AmountCarByColorAndRangePrice(listCars, Tuple.Create((decimal)1000, (decimal)10000), new List<string> { "Красный", "Чёрный" });
            foreach (var key in dicAmColors.Keys)
                Console.WriteLine($"{key}: {dicAmColors[key]}");

            Console.ReadKey();
        }
    }
}
