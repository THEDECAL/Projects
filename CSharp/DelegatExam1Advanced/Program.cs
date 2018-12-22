using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatExam1Advanced
{
    class Program
    {
        static public readonly Random random = new Random();
        //static public readonly Notifer notifer;
        //static public readonly FileMaster fileMaster;
        static Program()
        {
            Notifer.o = Notifer.Reference;
            FileMaster.FileName = "PilotsDB.bin";
            FileMaster.ReadFromFile();
        }
        static public void Wait()
        {
            Console.WriteLine(Notifer.o[mc.PRESS_ANY_KEY]);
            Console.ReadKey();
        }
        static void Main()
        {
            //Airplane airplane = Airplane.airplane;
            int penalty = 0; //Штрафные очки
            bool isThousand = false; //true - если тысяча км/ч уже достигнута
            bool isStart = true; //false - если это уже не начало полёта
            bool isSuccessFinish = false;  //false - если приземлился

            Airplane.AddDispather(new Dispather("first"));
            Airplane.AddDispather(new Dispather("second"));

            try
            {
                for (;;)
                {
                    Console.Clear();
                    Console.WriteLine(new string('=', 30));
                    Console.WriteLine("Увеличить скорость - \"← | D\"");
                    Console.WriteLine("Уменьшить скорость - \"→ | A\"");
                    Console.WriteLine("Поднятся выше - \"↑ | W\"");
                    Console.WriteLine("Опустится ниже - \"↓ | S\"");
                    Console.WriteLine("Добавить диспетчера - \"N\", удалить диспетчера - \"R\"");
                    Console.WriteLine("Изменить имя игрока - \"C\", посмотреть статистику игроков - \"V\"");
                    Console.WriteLine(new string('=', 30));
                    Console.WriteLine(Airplane.o);
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine("Рекомендации диспетчеров:");
                    Console.WriteLine(Airplane.ShowMessages());
                    Console.WriteLine(new string('-', 30));

                    if (Airplane.CheckDispathers() == false) { Wait(); continue; }

                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.C:
                            Airplane.Pilot.ChangeName();
                            break;
                        case ConsoleKey.V:
                            Console.WriteLine(Airplane.Pilot.Flights);
                            break;
                        case ConsoleKey.N:
                            Airplane.AddDispather();
                            break;
                        case ConsoleKey.R:
                            Airplane.RemoveDispather();
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            if (key.Modifiers == ConsoleModifiers.Shift) Airplane.SpeedUp(150);
                            else Airplane.SpeedUp(50);
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            if (key.Modifiers == ConsoleModifiers.Shift) Airplane.SpeedDown(150);
                            else Airplane.SpeedDown(50);
                            break;
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            if (key.Modifiers == ConsoleModifiers.Shift) Airplane.HeightUp(500);
                            else Airplane.HeightUp(250);
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            if (key.Modifiers == ConsoleModifiers.Shift) Airplane.HeightDown(500);
                            else Airplane.HeightDown(250);
                            break;
                    }
                    if (Airplane.Speed >= 1000) isThousand = true;
                    if (Airplane.Speed > 0 && Airplane.Height > 0) isStart = false;

                    Airplane.StartSendIndicators();
                    penalty = Airplane.ListDispathers.Sum(d => d.Points);

                    if (penalty >= 1000) throw new InvalidOperationException(Notifer.o[mc.CATH_ERR_UNUS]);

                    if (Airplane.Speed == 0 && Airplane.Height == 0)
                    {
                        if (isThousand == true) break;
                        if (isStart == false) throw new InvalidOperationException(Notifer.o[mc.CATH_ERR_AIRDESTR]);
                    }
                }
                isSuccessFinish = true;

                Console.WriteLine(Notifer.o[mc.SUCC_LAND]);
                Console.WriteLine($"У вас {penalty} штрафных очков.");
                Wait();
            }
            catch (InvalidOperationException text)
            {
                Console.WriteLine(text);
                Wait();
            }
            finally
            {
                FileMaster.WriteToFile();
                Airplane.Pilot.AddResultFlights(isSuccessFinish, penalty);
                Wait();
            }
            Wait();
        }
    }
}
