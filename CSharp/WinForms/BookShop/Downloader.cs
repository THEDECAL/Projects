using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
namespace BookShop
{
    static class Downloader
    {
        /// <summary>
        /// Метод загрузки страницы
        /// </summary>
        /// <param name="URL">URL адрес</param>
        /// <returns>Возвращает HTML документ</returns>
        static public HtmlDocument GetPage(string URL)
        {
            WebClient client = new WebClient();
            HtmlDocument htmlDoc = new HtmlDocument();

            byte[] page = client.DownloadData(URL);
            string htmlPage = Encoding.UTF8.GetString(page);
            htmlDoc.LoadHtml(htmlPage);

            return htmlDoc;
        }
        /// <summary>
        /// Метод загрузки изображения
        /// </summary>
        /// <param name="URL">URL адрес</param>
        /// <returns>Массив байт</returns>
        static public byte[] GetImage(string URL)
        {
            WebClient client = new WebClient();
            return client.DownloadData(URL);
        }
        /// <summary>
        /// Метод преобразования массива байт в изображение
        /// </summary>
        /// <param name="byteArray">Принимает массив байт</param>
        /// <returns>Возвращает изображение</returns>
        static public Image BytesToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray, 0, byteArray.Length))
            {
                return Image.FromStream(ms, true);
            }
        }
        /// <summary>
        /// Метод преобразования изображения в массив байт
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        static public byte[] ImageToBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// Метод парсинга сайта книг
        /// </summary>
        static public void BookParsing()
        {
            string[] refs = new string[]
            {
                "https://www.yakaboo.ua/knigi/hudozhestvennaja-literatura/detektiv.html",
                "https://www.yakaboo.ua/knigi/hudozhestvennaja-literatura/fantastika-fjentezi.html",
                "https://www.yakaboo.ua/knigi/hudozhestvennaja-literatura/boevik.html",
                "https://www.yakaboo.ua/knigi/komp-juternaja-literatura/programmirovanie.html"
            };
            string[] genres = new string[]{ "Детектив", "Фантастика/Фэнтэзи" ,"Боевик" ,"Программирование"};
            try
            {

                List<Book> books = new List<Book>();
                for (int i = 0; i < refs.Count(); i++)
                {
                    HtmlNode root = GetPage(refs[i]).DocumentNode;

                    //Form1.PBar.SetMaximum(pageCount * 32);
                    string xPath = "//*[@id='products']/ul/li";
                    var bookNodes = root.SelectNodes(xPath);

                    foreach (var bookNode in bookNodes)
                    {
                        Book book = new Book();

                        //Жанр
                        book.Genre =  SQLDbConntext.CheckUniqGenre(genres[i]);

                        //Изображение
                        xPath = "div/div[1]/a";
                        HtmlNode node = bookNode.SelectSingleNode(xPath);
                        string imageRef = node.Element("img").Attributes[1].Value;
                        book.Image = GetImage(imageRef);
                        string bookDescRef = node.Attributes[0].Value;

                        //Цены
                        xPath = "div/div[3]/div[1]/table/tr[last()]/td/div[1]/div/span/span/span";
                        string txtPrice = bookNode.SelectSingleNode(xPath).InnerText;
                        txtPrice = Regex.Match(txtPrice, @"(\d*)").Value;
                        double price = Convert.ToDouble(txtPrice);
                        book.CostPrice = book.GetCostPrice();
                        book.Price = price;
                        
                        //Название
                        xPath = "div/div[3]/div[1]/table/tr[1]/td/a/div[1]";
                        string txtName = bookNode.SelectSingleNode(xPath).InnerText;
                        book.Name = txtName.Trim();
                        
                        //Автор
                        xPath = "div/div[3]/div[1]/table/tr[2]/td/div";
                        string txtAuthor = bookNode.SelectSingleNode(xPath).InnerText;
                        book.Author = SQLDbConntext.CheckUniqAuthor(txtAuthor.Trim());
                        
                        //Издательство, год, страницы
                        root = GetPage(bookDescRef).DocumentNode;
                        xPath = "/html/body/div[@class='wrapper']/div[@class='main-container case']/div[@class='container']";
                        xPath += "/div[@class='main row']/div[@class='span12']/article/div/section/div[@class='product-shop f-left']";
                        xPath += "/div[@class='product-attributes product-attributes_short']/table/tbody/tr";
                        var nodes = root.SelectNodes(xPath);
                        foreach (var descNode in nodes)
                        {
                            string field = descNode.ChildNodes[1].InnerText;
                            string val = descNode.ChildNodes[3].InnerText.Trim();

                            if (field == "Издательство")
                                book.Publisher = SQLDbConntext.CheckUniqPublisher(val);
                            else if (field == "Год издания")
                                book.Year = Convert.ToInt32(val);
                            else if (field == "Количество страниц")
                                book.Pages = Convert.ToInt32(val);
                        }
                        //books.Add(book);
                        SQLDbConntext.DbContext.Books.Add(book);
                        SQLDbConntext.DbContext.SaveChanges();
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
