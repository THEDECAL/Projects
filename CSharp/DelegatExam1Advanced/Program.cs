using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DelegatExam1Advanced.FileMaster;
using static DelegatExam1Advanced.Notifer;
using static DelegatExam1Advanced.Airplane;

namespace DelegatExam1Advanced
{
    class Program
    {
        public static readonly Random random = new Random();
        static public void Wait()
        {
            Console.WriteLine(notifer[mc.PRESS_ANY_KEY]);
            Console.ReadKey();
        }
        static void Main()
        {
            fileMaster.FileName = "PilotsDB.bin";
            List<Pilot> stat = fileMaster.ReadFromFile();
            stat.Sort();

            int penalty = 0; //Штрафные очки
            bool isThousand = false; //true - если тысяча км/ч уже достигнута
            bool isStart = true; //false - если это уже не начало полёта
            bool isSuccessFinish = false;  //false - если приземлился

            airplane.AddDispather(new Dispather("first"));
            airplane.AddDispather(new Dispather("second"));

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
                    Console.WriteLine("Изменить имя пилота - \"C\", посмотреть статистику игроков - \"V\"");
                    Console.WriteLine(new string('=', 30));
                    Console.WriteLine(airplane);
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine("Рекомендации диспетчеров:");
                    Console.WriteLine(airplane.ShowMessages());
                    Console.WriteLine(new string('-', 30));
                    
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (!airplane.CheckDispathers() && key.Key != ConsoleKey.N) { Wait(); continue; }
                    switch (key.Key)
                    {
                        case ConsoleKey.C:
                            airplane.Pilot.ChangeName();
                            break;
                        case ConsoleKey.V:
                            foreach (var item in stat)
                                Console.WriteLine(item);
                            Wait();
                            break;
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

                    if (penalty >= 1000) throw new InvalidOperationException(notifer[mc.CATH_ERR_UNUS]);

                    if (airplane.Speed == 0 && airplane.Height == 0)
                    {
                        if (isThousand == true) break;
                        if (isStart == false) throw new InvalidOperationException(notifer[mc.CATH_ERR_AIRDESTR]);
                    }
                }
                isSuccessFinish = true;

                Console.WriteLine(notifer[mc.SUCC_LAND]);
                Console.WriteLine($"У вас {penalty} штрафных очков.");
            }
            catch (InvalidOperationException e) { Console.WriteLine(e); }
            catch (Exception e) { Console.WriteLine(e); }
            finally
            {
                airplane.Pilot.AddResultFlights(new Tuple<bool,int>(isSuccessFinish, penalty));//(isSuccessFinish, penalty);
            }
            Console.ReadLine();
        }
    }
}
