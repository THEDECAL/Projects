using System;

namespace Ukraine
{
    class Kiev
    {
        public string name { get; private set; } = "Kiev";
        public uint population { get; private set; } = 2934522;
    }
}
namespace Russia
{
    class Moscow
    {
        public string name { get; private set; } = "Moscow";
        public uint population { get; private set; } = 12506468;
    }
}
namespace USA
{
    class Washington
    {
        public string name { get; private set; } = "Washington";
        public uint population { get; private set; } = 601723;
    }
}

namespace task10
{
    class Program
    {
        static void Main()
        {
            Ukraine.Kiev city1 = new Ukraine.Kiev();
            Russia.Moscow city2 = new Russia.Moscow();
            USA.Washington city3 = new USA.Washington();

            Console.Write($"Город в котором население больше всех данных городов: ");
            Console.WriteLine($"{(city1.population > city2.population ? city1.name : city2.population > city3.population ? city2.name : city3.name)}");
        }
    }
}
