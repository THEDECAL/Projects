using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace tamagotchi
{

    class Program
    {
        class Tamogotchi
        {
            string name; //Имя
            SortedList<int, Func<bool>> events; //Список событий
            public Tamogotchi(string name)
            {
                this.name = name;
                events = new SortedList<int, Func<bool>>();
                EventsInit();
            }
            private event Func<bool> Events
            {
                add
                {
                    events.Add(events.Count,value);
                }
                remove
                {
                    events.RemoveAt(events.IndexOfValue(value));
                }
            }
            private void EventsInit()
            {
                Events += Eat;
                Events += Walk;
                Events += Sleep;
                Events += Play;
            }
            public bool Eat()
            {
                Show();
                bool result = ShowQuestion($"{name} хочет кушать", $"Покормить {name}?");
                if (result)
                {
                    Console.CursorLeft = 28 / 2;
                    Console.WriteLine("\bЯ ем.");
                    Thread.Sleep(2000);
                    Show();
                }
                return result;
            }
            public bool Walk()
            {
                Show();
                bool result = ShowQuestion($"{name} хочет гулять", $"Выгулять {name}?");
                if (result)
                {
                    Console.CursorLeft = 28 / 2;
                    Console.WriteLine("\bЯ гуляю.");
                    Thread.Sleep(2000);
                    Show();
                }
                return result;
            }
            public bool Sleep()
            {
                Show();
                bool result = ShowQuestion($"{name} хочет спать", $"Уложить спать {name}?");
                if (result)
                {
                    Console.CursorLeft = 28 / 2;
                    Console.WriteLine("\bЯ сплю.");
                    Thread.Sleep(4000);
                    Show();
                }
                return result;
            }
            public bool Play()
            {
                Show();
                bool result = ShowQuestion($"{name} хочет играть", $"Поиграть с {name}?");
                if (result)
                {
                    Console.CursorLeft = 28 / 2;
                    Console.WriteLine("\bЯ играю.");
                    Thread.Sleep(2000);
                    Show();
                }
                return result;
            }
            public bool Treat()
            {
                Show();
                bool result = ShowQuestion($"{name} заболел", $"Лечить {name}?");
                if (result)
                {
                    Console.CursorLeft = 28 / 2;
                    Console.WriteLine("\bЯ болею.");
                    Thread.Sleep(2000);
                    Show();
                }
                return result;
            }
            public bool Dead()
            {

                Console.Clear();
                Console.WriteLine(@"              __");
                Console.WriteLine(@"  R.I.P.     /'{>");
                Console.WriteLine(@"         ____) (____");
                Console.WriteLine(@"       //'--;   ;--'\\");
                Console.WriteLine(@"      ///////\_/\\\\\\\");
                Console.WriteLine(@"             m m");

                DialogResult result = MessageBox.Show($"{name} умер.", "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK) return true;
                return false;
            }
            public void Show()
            {
                Console.Clear();
                Console.WriteLine(@"              __");
                Console.WriteLine(@"             /'{>");
                Console.WriteLine(@"         ____) (____");
                Console.WriteLine(@"       //'--;   ;--'\\");
                Console.WriteLine(@"      ///////\_/\\\\\\\");
                Console.WriteLine(@"             m m");
            }
            public bool ShowQuestion(string title, string text)
            {
                DialogResult result = MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) return true;
                return false;
            }
            public void Run()
            {
                Func<bool> RunMethod = null;
                bool isGameOver = false;
                int cntFailure = 0; //Счётчик отказов на просьбу
                System.Timers.Timer Dead = new System.Timers.Timer(60 * 1000);
                Dead.Elapsed += (object o, System.Timers.ElapsedEventArgs e) => { isGameOver = this.Dead(); }; //Добавление события смерти после одной минуты
                Dead.Start();

                Show();
                while (!isGameOver)
                {
                    int AnswerWait = 0; //Переменная для ожидания ответа
                    Random random = new Random();
                    int rtime = random.Next(2, 6) * 1000; //Генерация случайного интервала запуска
                    System.Timers.Timer t = new System.Timers.Timer(rtime);
                    t.AutoReset = false; //Запрещаем повторный запуск

                    for (;;) //Исключение повторения просьбы
                    {
                        Func<bool> temp = events[random.Next(0, events.Count)]; //Выбор случайного метода из списка вызовов
                        if (RunMethod != temp) //Выясняем повторялся ли метод
                        {
                            RunMethod = temp;
                            break;
                        }
                    }
                    t.Elapsed += (object o, System.Timers.ElapsedEventArgs e) => { //Добавление события к таймеру 
                        if (cntFailure < 3) //Если отказов было меньше трёх
                        {
                            AnswerWait = (RunMethod() == true) ? 1 : 2;
                            if (AnswerWait != 1) cntFailure++;
                        }
                        else
                        {
                            AnswerWait = (Treat() == true) ? 1 : 2;
                            if (AnswerWait != 1)
                            {
                                AnswerWait = 0;
                                isGameOver = this.Dead();
                            }
                            else cntFailure = 0;
                        }
                    };
                    t.Start();
                    for (;;) //Ждать пока не ответят
                    {
                        if (AnswerWait != 0 || isGameOver) break;
                        Thread.Sleep(500);
                    }
                }
                if(!isGameOver) Console.ReadLine();
            }
        }
        static void Main()
        {
            Console.Title = "Тамагочи";
            Console.WindowHeight = 14;
            Console.WindowWidth = 28;
            Tamogotchi TMGT = new Tamogotchi("Ваня");
            TMGT.Run();
        }
    }
}
