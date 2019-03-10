using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using static System.Threading.Thread;

namespace smartfon_catalog
{
    static class Downloader
    {
        /// <summary>
        /// Строка соединения
        /// </summary>
        //static  string cs = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        //static  string cs = System.Configuration.ConfigurationManager.ConnectionStrings["geekpc"].ConnectionString;
        //static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["two"].ConnectionString;
        /// <summary>
        /// Контекст БД
        /// </summary>
        //static DataContext dc = new DataContext(cs);
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
        static public List<Smartfone> GetSmartfones() => SQLDbContext.DbContext.Smartfones.Include("Brand").ToList();//dc.GetTable<Smartfone>().ToList();
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
        static public byte[] ImageToBytes(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        /// <summary>
        /// Метод загрузки телефонов в БД с сайта ROZETKA
        /// </summary>
        static public void DownloadPhones()
        {
            string siteRef = "https://rozetka.com.ua/mobile-phones/c80003/preset=smartfon;seller=rozetka;view=tile";
            try
            {
                HtmlNode root = GetPage(siteRef).DocumentNode;
                //Загрузка кол-ва страниц телефонов
                int pageCount = 3;
                //int pageCount = Convert.ToInt32(root.SelectNodes("//*[@id='navigation_block']/ul/li").Last().Id.Replace("page", ""));
                Form1.PBar.SetMaximum(pageCount * 32);
            
                for (int i = 1; i <= pageCount; i++)
                {
                    //var listPhones = new List<Smartfone>();
                    //Table<Smartfone> phones = dc.GetTable<Smartfone>();
                    HtmlNode page = GetPage(siteRef + $";page={i}").DocumentNode;
                    string xpath = "//*[@id='catalog_goods_block']/div/div[@class='g-i-tile g-i-tile-catalog']/div[1]/div[1]/div[1]/div[@class='g-i-tile-i-box-desc']";
                    var phoneNodes = page.SelectNodes(xpath).ToList();

                    foreach (var pn in phoneNodes)
                    {
                        Smartfone phone = new Smartfone();
                        string xPath = "div[1]/div[1]/a/img";
                        var subNode = pn.SelectNodes(xPath).First();
                        string imgRef = subNode.Attributes[0].Value;
                        string phoneRef = subNode.ParentNode.Attributes[0].Value + "characteristics";
                        phone.Image = GetImage(imgRef);
                        var val = Regex.Match(subNode.Attributes[4].Value, @"(\w*)\ (.*)").Groups;
                        //phone.Brand = val[1].Value;
                        phone.Brand = AddBrand(val[1].Value);
                        phone.Name = val[2].Value;
                        HtmlNode phonePage = GetPage(phoneRef).DocumentNode;

                        var chrcNodes = phonePage.SelectNodes("//*[@id='tab_content']/div[1]/div[2]/table/tr");
                        if (chrcNodes != null)
                        {
                            foreach (var cn in chrcNodes)
                            {
                                var node = cn.SelectNodes("td");
                                if (node.Count > 1 && node[0].InnerText != "&nbsp;")
                                {
                                    DefinitionField(node, ref phone);
                                }
                            }
                            SQLDbContext.DbContext.Smartfones.Add(phone);
                            SQLDbContext.DbContext.SaveChanges();
                            Form1.PBar.SetProgress(i);
                            //listPhones.Add(phone);
                        }
                    }
                    //phones.InsertAllOnSubmit(listPhones);
                    //dc.SubmitChanges();
                }
            }
            catch (Exception) { }
        }
        /// <summary>
        /// Метод помещения данных в поля
        /// </summary>
        /// <param name="node">Принимает HTML узел</param>
        /// <param name="phone">Принимает объект телефона</param>
        static void DefinitionField(HtmlNodeCollection node, ref Smartfone phone)
        {
            string title = node[0].InnerText;
            string text = node[1].InnerText.Replace("\n", "");
            string textType2 = node[1].ChildNodes[1].ChildNodes[1].InnerText;

            if (title.Contains("Стандарт связи")) phone.CommStd = text.Replace(")", "); ");
            else if (title.Contains("Диагональ экрана")) phone.ScrDiag = text;
            else if (title.Contains("Разрешение дисплея")) phone.ScrResol = text;
            else if (title.Contains("Тип матрицы")) phone.MatrixType = textType2;
            else if (title.Contains("Количество СИМ-карт")) phone.CntSIMCards = text;
            else if (title.Contains("Размеры СИМ-карты")) phone.SIMType = textType2;
            else if (title.Contains("Оперативная память")) phone.RAM = text;
            else if (title.Contains("Встроенная память")) phone.BMEM = text;
            else if (title.Contains("Формат поддерживаемых карт памяти")) phone.MemCardsType = text;
            else if (title.Contains("Операционная система")) phone.OS = text;
            else if (title.Contains("Количество мегапикселей фронтальной камеры")) phone.QualityFrontalCamera = text;
            else if (title.Contains("Количество мегапикселей основной камеры")) phone.QualityGeneralCamera = text;
            else if (title.Contains("Емкость аккумулятора")) phone.BatteryCapp = text;
            else if (title.Contains("Цвет")) phone.Color = text;
        }
        /// <summary>
        /// Метод который добавляет новый брэнд или возвращает уже существующий для исключения дублирования
        /// </summary>
        /// <param name="name">Принимает имя брэнда</param>
        /// <returns>Возвращает объект брэнда</returns>
        static public Brand AddBrand(string name)
        {
            Brand brand = SQLDbContext.DbContext.Brands.FirstOrDefault(b => b.Name == name);
            if (brand == null)
            {
                brand = new Brand { Name = name };
                SQLDbContext.DbContext.Brands.Add(brand);
                SQLDbContext.DbContext.SaveChanges();
            }

            return SQLDbContext.DbContext.Brands.FirstOrDefault(b => b.Name == name);
        }
    }
}
