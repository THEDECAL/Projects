using ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DeserializConsolApp
{
    class Program
    {
        static string dirName;
        //Десериализация отдельный объектов в файлах
        static List<PC> ApartDeserialize()
        {
            List<PC> listTemp = new List<PC>();
            string dirNameTwo = $"{dirName}\\objects";
            string[] listFiles = Directory.GetFiles(dirNameTwo);
            foreach (var item in listFiles)
            {
                using (FileStream fs = new FileStream(item, FileMode.Open, FileAccess.Read))
                {
                    PC pc;
                    pc = new BinaryFormatter().Deserialize(fs) as PC;
                    listTemp.Add(pc);
                }
            }

            return listTemp;
        }
        //Десериализация списка объектов
        static List<PC> ListDeserialize()
        {
            List<PC> temp;
            string fileName = $"{dirName}\\listSerial.txt";
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                temp = new BinaryFormatter().Deserialize(fs) as List<PC>;

            return temp;
        }
        static void Main()
        {
            dirName = "C:\\PC_list";
            List<PC> apartList = ApartDeserialize();
            List<PC> list = ListDeserialize();

            foreach (var item in apartList)
                Console.WriteLine(item);

            Console.WriteLine("-----");

            foreach (var item in list)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}
