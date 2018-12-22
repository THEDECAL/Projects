using ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializConsolApp
{
    class Program
    {
        static string dirName;
        //Сохранение каждого объекта в свой файл в отдельной папке
        static void ApartSerialize(List<PC> list)
        {
            string dirNameTwo = $"{dirName}\\objects";
            if (!Directory.Exists(dirNameTwo)) Directory.CreateDirectory(dirNameTwo);
            foreach (var item in list)
            {
                string fileName = $"{dirNameTwo}\\{item.Brand}.txt";
                using (FileStream fs = new FileStream(fileName, (File.Exists(fileName) ? FileMode.Truncate : FileMode.Create), FileAccess.Write))
                    new BinaryFormatter().Serialize(fs, item);
            }
        }
        //Сохранение списка объектов в один файл
        static void ListSerialize(List<PC> list)
        {
            
            string fileName = $"{dirName}\\listSerial.txt";
            using (FileStream fs = new FileStream(fileName, (File.Exists(fileName) ? FileMode.Truncate : FileMode.Create), FileAccess.Write))
                new BinaryFormatter().Serialize(fs, list);
        }
        static void Main()
        {
            dirName = "C:\\PC_list";
            if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);

            List<PC> list = new List<PC>{
                new PC("MSI", 3900, 16, 1000),
                new PC("Dell", 3200, 6, 500),
                new PC("Toshiba", 2800, 4),
                new PC("Lenovo"),
                new PC("Fujitsu", 2900, 2, 800)
            };
            ApartSerialize(list);
            ListSerialize(list);
        }
    }
}
