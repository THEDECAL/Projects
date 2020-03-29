using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatExam1
{
    class Program
    {
        static public Random random;
        static public void Wait()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
        }
        static void Main()
        {
            random = new Random();
            Airplane airplane = new Airplane();
            int penalty = 0; //Штрафные очки
            bool isThousand = false; //true - если тысяча км/ч уже достигнута
            bool isStart = true; //false - если это уже не начало полёта

            airplane.AddDispather(new Dispather("first"));
            airplane.AddDispather(new Dispather("second"));

            try
            {
                for (;;)
                {
                    Console.Clear();
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine("Увеличить скорость - \"стрелка вправо или D\"");
                    Console.WriteLine("Уменьшить скорость - \"стрелка влево или A\"");
                    Console.WriteLine("Поднятся выше - \"стрелка вверх или W\"");
                    Console.WriteLine("Опустится ниже - \"стрелка вниз или S\"");
                    Console.WriteLine("Добавить диспетчера - \"N\", удалить диспетчера - \"R\"");
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine($"Текущая скорость: {airplane.Speed}км/ч, текущая высота: {airplane.Height}м");
                    //Console.WriteLine($"Штрафные очки: {penalty}");
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine("Рекомендации диспетчеров:");
                    Console.WriteLine(airplane.ShowMessages());
                    Console.WriteLine(new string('-', 20));

                    if (airplane.ListDispathers.Count < 2)
                    {
                        Console.WriteLine("Диспетчеров должно быть не меньше двух.");
                        Wait();
                        continue;
                    }

                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.N:
                            airplane.AddDispather();
                            break;
                        case ConsoleKey.R:
                            airplane.RemoveDispather();
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            if (key.Modifiers == ConsoleModifiers.Shift) airplane.SpeedUp(150);
                            else airplane.SpeedUp(50);
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            if (key.Modifiers == ConsoleModifiers.Shift) airplane.SpeedDown(150);
                            else airplane.SpeedDown(50);
                            break;
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            if (key.Modifiers == ConsoleModifiers.Shift) airplane.HeightUp(500);
                            else airplane.HeightUp(250);
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            if (key.Modifiers == ConsoleModifiers.Shift) airplane.HeightDown(500);
                            else airplane.HeightDown(250);
                            break;
                    }
                    if (airplane.Speed >= 1000) isThousand = true;
                    if (airplane.Speed > 0 && airplane.Height > 0) isStart = false;

                    airplane.StartSendIndicators();
                    penalty = airplane.ListDispathers.Sum(d => d.Points);

                    if (penalty >= 1000) throw new InvalidOperationException("Непригоден к полётам.\n");

                    if (airplane.Speed == 0 && airplane.Height == 0)
                    {
                        if (isThousand == true) break;
                        if (isStart == false) throw new InvalidOperationException("Самолёт разбился\n");
                    }
                }
                
                Console.WriteLine("Вы успешно приземлились.");
                Console.WriteLine($"У вас {penalty} штрафных очков.");
                Wait();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                Wait();
            }
            catch (Exception e)
            {
                Wait();
            }
        }
    }
}
