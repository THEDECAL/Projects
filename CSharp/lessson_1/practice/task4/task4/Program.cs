using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        uint A, B, C;
        static void Main()
        {
            string title = "Подсчёт кол-ва квадратов в прямоугольнике";
            Console.Title = title; //Заголовок окна
            Console.BackgroundColor = ConsoleColor.White; //Фоновый цвет текста
            //Console.ForegroundColor = ConsoleColor.Black; //Цвет текста
            Console.WriteLine(title);
            start:
            Program main = new Program();
            main.input();
            main.search_squares();
            Console.WriteLine("Продолжить?");
            if(main.yesno() == true) goto start;
        }
        bool check_numbers() //Проверка введённых чисел
        {
            if (A == B)
            {
                Console.WriteLine("Это квадрат. Измените длину сторон.");
                return true;
            }
            else if (C > A || C > B)
            {
                Console.WriteLine("Ваш квадрат больше, чем прямоугольник.");
                return true;
            }
            return false;
        }
        string check_num(string number) //Проверка числа
        {
            if (number == "") number = "0";
            foreach (char c in number) if (c < '0' || c > '9') number = "0";
            return number;
        }
        public void input() //Ввод чисел
        {
            Console.WriteLine("Введите три числа для A, B и С, где A и B длины сторон прямоугольника, а C длина одной из сторон квадрата.");

            char letter = 'A';
            uint[] abc = new uint[3];
            for (int i = 0; i < abc.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Введите {letter}: ");
                    string number = check_num(Console.ReadLine());
                    if (number == "0") continue;
                    abc[i] = uint.Parse(number);
                    break;
                }
                letter++;
            }
            A = abc[0]; B = abc[1]; C = abc[2]; //Использую такой способ т.к. enum в с# совсем неудобный
            check_numbers();
        }
        public void search_squares() //Поиск квадратов в прямоугольнике
        {
            uint S_rectangle = A * B; //Площадь прямоугольника
            uint S_square = C * C; //Площадь квадрата
            uint S_inscribed_squares = ((A / C) * (B / C) * S_square); //Площадь вписанных квадратов
            double S_ramainder = (double)S_rectangle - (double)S_inscribed_squares; //Оставшаяся площадь

            Console.WriteLine($"Кол-во вписанных квадратов в прямоугольнике: {S_inscribed_squares / S_square}");
            if(S_ramainder != 0) Console.WriteLine($"Оставшаяся площадь: {S_ramainder}");
        }
        public bool yesno()
        {
            while (true)
            {
                Console.WriteLine("Да/Нет(YyдД/NnНн)");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 'Y': case 'y': case 'Д': case 'д': return true;
                    case 'N': case 'n': case 'Н': case 'н': return false;
                }
            }    
        }
    }
}
