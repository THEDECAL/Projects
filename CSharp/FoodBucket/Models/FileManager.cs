using FlowDocumentConverter;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Documents;
using System.Xml.Serialization;
using Spire.Pdf;
using System.Threading.Tasks;
using System.Threading;

namespace FoodBucket.Models
{
    class FileManager
    {
        static XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Recipe>));
        readonly static string pathToFileRecipes = "recipes.xml";
        public static ObservableCollection<Recipe> LoadRecipes()
        {
            try
            {
                if (File.Exists(pathToFileRecipes))
                {
                    using (FileStream fs = new FileStream(pathToFileRecipes, FileMode.Open, FileAccess.Read))
                    {
                        return serializer.Deserialize(fs) as ObservableCollection<Recipe>;
                    }
                }
            }
            catch (Exception) { }
            return new ObservableCollection<Recipe>();
        }
        public static void SaveRecipes(ObservableCollection<Recipe> list)
        {
            try
            {
                //Делаем резервную копию старого файла
                //if (File.Exists(pathToFileRecipes)) File.Move(pathToFileRecipes, $"./{DateTime.Now.ToString("MM.dd.yyyy HH:mm:ss")}_{pathToFileRecipes}");

                using (FileStream fs = new FileStream(pathToFileRecipes, FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(fs, list);
                }
            }
            catch (Exception){ }
        }
        public static void SaveToPDF(FlowDocument fd, string filename)
        {
            if (fd != null && filename != null)
            {
                try
                {
                    var arrayBytes = PdfConverter.ConvertDoc(fd);
                    using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(arrayBytes, 0, arrayBytes.Length);
                    }
                }
                catch (Exception) { }
            }
        }
        public static void SaveToDOC(FlowDocument fd, string filename)
        {
            if (fd != null && filename != null)
            {
                try
                {
                    var arrayBytes = PdfConverter.ConvertDoc(fd);
                    string pdfFilename = $"{filename}.pdf";
                    using (FileStream fs = new FileStream(pdfFilename, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(arrayBytes, 0, arrayBytes.Length);
                    }

                    PdfDocument pdf = new PdfDocument();
                    pdf.LoadFromFile(pdfFilename);
                    pdf.SaveToFile(filename, FileFormat.DOC);
                    File.Delete(pdfFilename);
                }
                catch (Exception) { }
            }
        }
    }
}
