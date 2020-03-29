using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    enum MENU { ChangeDrive, ShowAll, ShowFolders, ShowFiles, FindFile, RecFindFile, FindFolder, RecFindFolder };
    class Program
    {
        static string CurrentDir { get; set; }
        static List<string> GetAll() => GetFiles().Concat(GetFolders()).ToList<string>();
        static List<string> GetFiles() => Directory.GetFiles(CurrentDir).ToList<string>();
        static List<string> GetFolders() => Directory.GetDirectories(CurrentDir).ToList<string>();
        static List<string> GetDrives() => Directory.GetLogicalDrives().ToList<string>();
        static List<string> CutCD(List<string> list) => list.Select(line => line.Replace(CurrentDir, string.Empty)).ToList<string>();
        static List<string> FindFile(string fileName, bool recursive = false)
        {
            if (recursive)
                return Directory.GetFiles(CurrentDir, fileName, SearchOption.AllDirectories).ToList<string>();
            else
                return CutCD(GetFiles()).Where(file => file == fileName).ToList<string>();
        }
        static List<string> FindDir(string dirName, bool recursive = false)
        {
            if (recursive)
                return Directory.GetDirectories(CurrentDir, dirName, SearchOption.AllDirectories).ToList<string>();
            else
                return CutCD(GetFolders()).Where(dir => dir == dirName).ToList<string>();
        }
        static int Menu(List<string> list, string title, bool BlockSelect = false, bool isBrowsing = false)
        {
            if (list[list.Count - 1] != "[Выход/Назад]") list.Add("[Выход/Назад]");
            int arrow = (BlockSelect) ? arrow = list.Count - 1 : 0;

            for (;;)
            {
                Console.Clear();
                Console.WriteLine($"Текущая дериктория:\n{CurrentDir}\n\n");
                Console.WriteLine(title + ":");

                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine($"{(i == arrow ? ">" : " ")} {list[i]}");
                Console.WriteLine("\n\nНавигация: Стрелка вверх/Стрелка вниз или W/S");

                ConsoleKey key = Console.ReadKey().Key;
                if (!BlockSelect)
                {
                    if (key == ConsoleKey.UpArrow || key == ConsoleKey.W) arrow--;
                    else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S) arrow++;

                    if (arrow < 0) arrow = list.Count - 1;
                    else if (arrow > list.Count - 1) arrow = 0;
                }

                if (key == ConsoleKey.Enter) return arrow;
            }
        }
        static string Message(string text, bool isInput = false)
        {
            Console.Write($"{text}");
            if (!isInput) System.Threading.Thread.Sleep(1500);
            else return Console.ReadLine();
            return null;
        }
        static void Main()
        {
            CurrentDir = Directory.GetCurrentDirectory() + "\\";
            #region Меню
            List<string> menu = new List<string> {
                "Сменить логический диск",
                "Показать всё",
                "Показа папки",
                "Показать файлы",
                "Поиск файла",
                "Рекурсивный поиск файла",
                "Поиск папки",
                "Рекурсивный поиск папки",
            };
            #endregion

            int select = -1;
            for (;;)
            {
                select = Menu(menu, "Меню");
                if (select == menu.Count - 1) return; //Если выбран "Выход"

                switch ((MENU)select)
                {
                    case MENU.ChangeDrive:
                        List<string> listDrives = GetDrives();
                        CurrentDir = listDrives[Menu(listDrives, "Список доступных дисков")];
                        break;
                    case MENU.ShowAll:
                    case MENU.ShowFolders:
                        Func<List<string>> Get = GetAll;
                        if ((MENU)select == MENU.ShowFolders) Get = GetFolders;

                        for (;;)
                        {
                            List<string> listFolders = new List<string> { ".." };
                            listFolders = listFolders.Concat(CutCD(Get())).ToList<string>();
                            int slct = Menu(listFolders, "Файлы текущей директории");

                            string newDir = null;
                            if (slct == 0)
                            {
                                newDir = Directory.GetParent(CurrentDir)?.FullName; //?. - на случай, если нет родительской папки (диск C:\ к примеру)
                                CurrentDir = (newDir != null) ? newDir : CurrentDir;
                            }
                            else if (slct == listFolders.Count - 1) break;
                            else
                            {
                                newDir = CurrentDir + listFolders[slct];
                                FileAttributes fa = File.GetAttributes(newDir);
                                if(File.GetAttributes(newDir) != FileAttributes.Directory) continue;
                                CurrentDir = newDir;
                            }
                        }
                        break;
                    case MENU.ShowFiles:
                        List<string> listFiles = CutCD(GetFiles());
                        if (listFiles.Count == 0) Message("Файлов нет.");
                        else Menu(listFiles, "Список файлов текущей директории", true);
                        break;
                    case MENU.FindFile:
                    case MENU.RecFindFile:
                    case MENU.FindFolder:
                    case MENU.RecFindFolder:
                        string fileName = Message("Введите имя файла: ", true);

                        Func<string, bool, List<string>> Find = FindFile;
                        if ((MENU)select == MENU.FindFile || (MENU)select == MENU.RecFindFile) Find = FindFile;
                        else Find = FindDir;
                        bool mode = ((MENU)select == MENU.FindFile || (MENU)select == MENU.FindFolder) ? false : true;

                        List<string> findResult = CutCD(Find(fileName, mode));
                        if (findResult.Count == 0) Message("Поиск не дал результата/");
                        else Menu(findResult, "Список найденных файлов", true);
                        break;
                }
            }
        }
    }
}
