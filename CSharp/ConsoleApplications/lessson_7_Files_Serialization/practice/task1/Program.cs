using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace task1
{
    enum MENU { CREATE, OPEN, WRITE, READ, DELETE, EXIT };
    class Data
    {
        public double[,] DoubleArray { get; set; }
        public int[,] IntArray { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string PName { get; set; }
        public DateTime Birth { get; set; }
        public DateTime CreateDate { get; set; }
        public Data() {}
        public Data(string fName, string sName, string pName, DateTime birth)
        {
            FName = fName;
            SName = sName;
            PName = pName;
            Birth = birth;

            Random rnd = new Random();
            DoubleArray = new double[rnd.Next(2, 5), rnd.Next(2, 5)];
            IntArray = new int[rnd.Next(2, 5), rnd.Next(2, 5)];

            for (int i = 0; i < DoubleArray.GetLength(0); i++)
                for (int j = 0; j < DoubleArray.GetLength(1); j++)
                    DoubleArray[i, j] = Math.Round((rnd.Next(10) + rnd.NextDouble()),1);

            for (int i = 0; i < IntArray.GetLength(0); i++)
                for (int j = 0; j < IntArray.GetLength(1); j++)
                    IntArray[i, j] = rnd.Next(10);
        }
        public override string ToString()
        {
            StringBuilder allData = new StringBuilder();
            allData.Append($"Имя: {FName}\nФамилия: {SName}\nОтчество:{PName}\n");
            allData.Append($"Дата рождения: {Birth.ToString("dd/MM/yyyy")}\n");
            allData.Append($"Размер массива дробных чисел: {DoubleArray.GetLength(0)} строк, {DoubleArray.GetLength(1)} столбцов\n");
            int cnt = 1;
            foreach (var item in DoubleArray)
            {
                allData.Append($"{item.ToString()} ");
                if (cnt % DoubleArray.GetLength(1) == 0) allData.Append('\n');
                cnt++;
            }
            allData.Append($"Размер массива целых чисел: {IntArray.GetLength(0)} строк, {IntArray.GetLength(1)} столбцов\n");
            cnt = 1;
            foreach (var item in IntArray)
            {
                allData.Append($"{item.ToString()} ");
                if (cnt % IntArray.GetLength(1) == 0) allData.Append('\n');
                cnt++;
            }
            allData.Append($"Дата создания: {CreateDate.ToString("dd/MM/yyyy")}");

            return allData.ToString();
        }
    }
    class Program
    {
        static readonly string fileName = "Day17.txt";
        static bool WriteFile(string fName, string sName, string pName, DateTime birth)
        {
            try
            {
                Data dataObj = new Data(fName, sName, pName, birth);
                using (StreamWriter wStream = new StreamWriter(fileName))
                {
                    wStream.WriteLine($"{fName} {sName} {pName} {birth.ToString("dd.MM.yyyy")}");
                    wStream.WriteLine($"{dataObj.DoubleArray.GetLength(0)} {dataObj.DoubleArray.GetLength(1)}");
                    int cnt = 1;
                    foreach (double item in dataObj.DoubleArray)
                    {
                        wStream.Write(item.ToString() + ' ');
                        if (cnt % dataObj.DoubleArray.GetLength(1) == 0) wStream.WriteLine();
                        cnt++;
                    }
                    wStream.WriteLine($"{dataObj.IntArray.GetLength(0)} {dataObj.IntArray.GetLength(1)}");
                    cnt = 1;
                    foreach (int item in dataObj.IntArray)
                    {
                        wStream.Write(item.ToString() + ' ');
                        if (cnt % dataObj.IntArray.GetLength(1) == 0) wStream.WriteLine();
                        cnt++;
                    }
                    wStream.WriteLine($"{DateTime.Today.ToString("dd.MM.yyyy")}");
                }
                return true;
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            return false;
        }
        static Data ReadFile()
        {
            try
            {
                if (File.Exists(fileName))
                {
                    Data dataObj = new Data();
                    using (StreamReader rStream = new StreamReader(fileName))
                    {
                        //ФИО и дата рождения
                        string[] buffer = rStream.ReadLine().Split();
                        dataObj.FName = buffer[0];
                        dataObj.SName = buffer[1];
                        dataObj.PName = buffer[2];
                        dataObj.Birth = Convert.ToDateTime(buffer[3]);

                        //Массив с дробными числами
                        buffer = rStream.ReadLine().Split();
                        int rows = Convert.ToInt32(buffer[0]), cols = Convert.ToInt32(buffer[1]);
                        dataObj.DoubleArray = new double[rows, cols];
                        for (int i = 0; i < rows; i++)
                        {
                            buffer = rStream.ReadLine().Split();
                            for (int j = 0; j < cols; j++)
                            {
                                dataObj.DoubleArray[i, j] = Convert.ToDouble(buffer[j]);
                            }
                        }

                        //Массив с целыми числами
                        buffer = rStream.ReadLine().Split();
                        rows = Convert.ToInt32(buffer[0]); cols = Convert.ToInt32(buffer[1]);
                        dataObj.IntArray = new int[rows, cols];
                        for (int i = 0; i < rows; i++)
                        {
                            buffer = rStream.ReadLine().Split();
                            for (int j = 0; j < cols; j++)
                            {
                                dataObj.IntArray[i, j] = Convert.ToInt32(buffer[j]);
                            }
                        }

                        //Дата создания
                        dataObj.CreateDate = Convert.ToDateTime(rStream.ReadLine());
                    }
                    return dataObj;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            return null;
        }
        static void Main()
        {
            Data dataObj = null;

            string[] menu = {
                $"Создать файл {fileName}",
                $"Открыть файл {fileName}",
                $"Записать файл {fileName}",
                $"Прочитать файл {fileName}",
                $"Удалить файл {fileName}",
                "Выход"
            };

            int arrow = 0;
            for (;;)
            {
                Console.Clear();
                if (arrow < (int)MENU.CREATE) arrow = (int)MENU.EXIT;
                else if (arrow > (int)MENU.EXIT) arrow = (int)MENU.CREATE;

                for (int i = 0; i < menu.Length; i++)
                    Console.WriteLine($"{(arrow == i ? ">" : " " )} {menu[i]}");

                ConsoleKey key =  Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W) arrow--;
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S) arrow++;
                else if (key == ConsoleKey.Enter)
                {
                    switch ((MENU)arrow)
                    {
                        case MENU.CREATE:
                            if (File.Exists(fileName))
                                Console.WriteLine("Файл уже создан.");
                            else
                            {
                                using (FileStream fs = File.Create(fileName)) { } ;
                                Console.WriteLine("Файл успешно создан.");
                            }
                            Thread.Sleep(1500);
                            break;
                        case MENU.OPEN:
                            if (File.Exists(fileName))
                            {
                                if (new FileInfo(fileName).Length != 0)
                                {
                                    dataObj = ReadFile();
                                    Console.WriteLine("Файл успешно открыт.");
                                }
                                else Console.WriteLine("Файл пуст.");
                            }
                            else Console.WriteLine("Файл не создан.");
                            Thread.Sleep(1500);
                            break;
                        case MENU.WRITE:
                            if (File.Exists(fileName))
                            {
                                DateTime date = new DateTime();
                                string fName = null, sName = null, pName = null;

                                Console.Write("Введите имя:"); fName = Console.ReadLine().Replace(' ', '_');
                                Console.Write("Введите фамилию:"); sName = Console.ReadLine().Replace(' ', '_');
                                Console.Write("Введите отчетво:"); pName = Console.ReadLine().Replace(' ', '_');
                                Console.Write("Введите дату рождения (дд.мм.гггг):"); date = Convert.ToDateTime(Console.ReadLine());

                                if (WriteFile(fName, sName, pName, date)) Console.WriteLine("Файл успешно записан.");
                                else Console.WriteLine("Файл не удалось записать.");
                            }
                            else Console.WriteLine("Файл не создан.");
                            Thread.Sleep(1500);
                            break;
                        case MENU.READ:
                            if (dataObj != null)
                            {
                                Console.WriteLine(dataObj);
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Файл не открыт.");
                                Thread.Sleep(1500);
                            }
                            break;
                        case MENU.DELETE:
                            if (File.Exists(fileName))
                            {
                                File.Delete(fileName);
                                Console.WriteLine("Файл успешно удалён.");
                            }
                            else Console.WriteLine("Файл не создан.");
                            Thread.Sleep(1500);
                            break;
                        case MENU.EXIT:
                            return;
                    }
                }
            }
        }
    }
}
