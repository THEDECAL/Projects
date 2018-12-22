using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace task1
{
    enum menu { DicMode, Add, Del, Find, Show, Exit};
    enum dicMode { rusEng, engRus };
    abstract class Dict
    {
        protected Dictionary<string, List<string>> dictionary;
        public Dict()
        {
            dictionary = new Dictionary<string, List<string>>();
        }
        public bool AddWord(string word, string[] translate) //Добавить новое слово в словарь
        {
            if (word != null && translate != null && Check(word.ToLower()))
            {
                if (!dictionary.ContainsKey(word))
                {
                    List<string> temp = new List<string>();
                    foreach (string item in translate)
                        temp.Add(item.ToLower());
                    dictionary.Add(word.ToLower(), temp);
                    return true;
                }
            }
            return false;
        }
        public bool DelWord(string word) //Удалить слово из словаря
        {
            if (dictionary.ContainsKey(word.ToLower()))
            {
                dictionary.Remove(word.ToLower());
                return true;
            }
            return false;
        }
        public List<string> Find(string word) //Поиск слова в словаре
        {
            foreach (string item in dictionary.Keys)
            {
                if (item == word.ToLower()) return dictionary[item];
            }
            return null;
        }
        public void Show() //Показ всех слов словаря
        {
            foreach (string item in dictionary.Keys)
            {
                WriteLine(item);
                foreach (string i in dictionary[item])
                    WriteLine($"\t {i}");
            }
        }
        abstract public bool Check(string word); //Проверка на ввод языка
    }
    class RusEng : Dict
    {
        public override bool Check(string word)
        {
            foreach (char item in word)
            {
                if (item < 'а' || item > 'я')
                    return false;
            }
            return true;
        }
    }
    class EngRus : Dict
    {
        public override bool Check(string word)
        {
            foreach (char item in word)
            {
                if (item < 'a' || item > 'z')
                    return false;
            }
            return true;
        }
    }
    class Program
    {
        delegate bool delAdd(string word, string[] translate);
        delegate bool delDel(string word);
        delegate List<string> delFind(string word);
        static void Main()
        {
            try
            {
                RusEng RE = new RusEng();
                EngRus ER = new EngRus();
                RE.AddWord("замок",new string[]{ "castle", "lock"});
                RE.AddWord("рука", new string[] { "hand", "arm" });
                RE.AddWord("ложь", new string[] { "lie", "falsehood" });

                ER.AddWord("castle", new string[] { "замок","дворец" });
                ER.AddWord("hand", new string[] { "рука", "стрелка" });
                ER.AddWord("lie", new string[] { "ложь", "обман" });
                delAdd AddWord = RE.AddWord;
                delDel DelWord = RE.DelWord;
                delFind Find = RE.Find;
                Action Show = RE.Show;

                string[] MENU =
                {
                        "Русский - Английский",
                        "Добавить слово в словарь",
                        "Удалить слово из словаря",
                        "Перевести слово",
                        "Показать словарь",
                        "Выход"
                };
                dicMode dm = dicMode.rusEng;
                int arrow = 0;
                for (;;)
                {
                    Clear();

                    if (arrow < (int)menu.DicMode) arrow = (int)menu.Exit;
                    else if (arrow > (int)menu.Exit) arrow = (int)menu.DicMode;

                    for (int i = 0; i < MENU.Count(); i++)
                        WriteLine($"{(arrow == i ? ">>": "  ")} {MENU[i]}");

                    ConsoleKey button = ReadKey().Key;
                    if (button == ConsoleKey.UpArrow) arrow--;
                    else if (button == ConsoleKey.DownArrow) arrow++;
                    else if (button == ConsoleKey.Enter)
                    {
                        #region switch
                        switch ((menu)arrow)
                        {
                            case menu.DicMode:
                                if (dm == dicMode.rusEng)
                                {
                                    dm = dicMode.engRus;
                                    MENU[(int)menu.DicMode] = "Английский - Русский";
                                    AddWord = ER.AddWord;
                                    DelWord = ER.DelWord;
                                    Find = ER.Find;
                                    Show = ER.Show;
                                }
                                else
                                {
                                    dm = dicMode.rusEng;
                                    MENU[(int)menu.DicMode] = "Русский - Английский";
                                    AddWord = RE.AddWord;
                                    DelWord = RE.DelWord;
                                    Find = RE.Find;
                                    Show = RE.Show;
                                }
                                break;
                            case menu.Add:
                                Write("Введите слово: ");
                                string word = ReadLine();
                                string[] delimiters = { " ", "," };
                                Write("Введите перевод (вводите слова через пробел или запятую): ");
                                string[] translate = ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                                if (AddWord(word, translate)) WriteLine("Слово добавлено.");
                                else WriteLine("Язык слова не соответсвует языку словаря.");
                                Thread.Sleep(2000);
                                break;
                            case menu.Del:
                                Write("Введите слово: ");
                                if (DelWord(ReadLine())) WriteLine("Слово удалено.");
                                else WriteLine("Слово не найдено.");
                                Thread.Sleep(2000);
                                break;
                            case menu.Find:
                                Write("Введите слово: ");
                                word = ReadLine();
                                List<string> list = Find(word);
                                if (list != null)
                                {
                                    foreach (string item in list)
                                        WriteLine(item);
                                    WriteLine("Нажмите любую кнопку для продолжения.");
                                    ReadKey();
                                }
                                else
                                {
                                    WriteLine("Слово не найдено.");
                                    Thread.Sleep(2000);
                                }
                                break;
                            case menu.Show:
                                Show();
                                WriteLine("Нажмите любую кнопку для продолжения.");
                                ReadKey();
                                break;
                            case menu.Exit:
                                return;
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ОШИБКА. {ex.Message}.");
            }
        }
    }
}
