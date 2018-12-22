using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace DelegatExam1Advanced
{
    class FileMaster//: SingletonTemplate<FileMaster>
    {
        static public string FileName { get; set; }
        static FileStream fStream;
        static List<Pilot> ListPilots { get; set; }
        //static public FileMaster o;
        //static FileMaster()
        //{
        //    ReadFromFile();
        //}
        static public void ReadFromFile()
        {
            if((fStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite)) != null)
            {
                ListPilots.Add(new BinaryFormatter().Deserialize(fStream) as Pilot);
                fStream.Close();
            }
            else throw new FileNotFoundException(Notifer.o[mc.ERR_READ]);
        }
        static public void WriteToFile()
        {
            if ((fStream = new FileStream(FileName, FileMode.Truncate, FileAccess.Write)) != null)
            {
                new BinaryFormatter().Serialize(fStream, ListPilots);
                fStream.Close();
            }
            else throw new FileNotFoundException(Notifer.o[mc.ERR_WRITE]);
        }
        public Pilot this[int index]
        {
            get { return ListPilots.ElementAtOrDefault(index); }
        }
        ~FileMaster()
        {
            WriteToFile();
            if (fStream != null) fStream.Close();
        }
    }
}
