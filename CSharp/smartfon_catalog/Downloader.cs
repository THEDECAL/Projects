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
        static public HtmlDocument GetPage(string URL)
        {
            WebClient client = new WebClient();
            HtmlDocument htmlDoc = new HtmlDocument();

            byte[] page = client.DownloadData(URL);
            string htmlPage = Encoding.UTF8.GetString(page);
            htmlDoc.LoadHtml(htmlPage);

            return htmlDoc;
        }
        static public byte[] GetImage(string URL)
        {
            WebClient client = new WebClient();
            return client.DownloadData(URL);
        }
        static public Image BytesToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray, 0, byteArray.Length))
            {
                return Image.FromStream(ms, true);
            }
        }
        static public void GetPhones()
        {
            //string cs = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["geekpc"].ConnectionString;
            string siteRef = "https://rozetka.com.ua/mobile-phones/c80003/preset=smartfon;seller=rozetka;view=tile";
            ;
            try
            {
                HtmlNode root = Downloader.GetPage(siteRef).DocumentNode;
                //int pageCount = Convert.ToInt32(root.SelectNodes("//*[@id='navigation_block']/ul/li").Last().Id.Replace("page", ""));
            
                //for (int i = 1; i <= pageCount; i++)
                for (int i = 1; i <= 2; i++)
                {
                    DataContext dc = new DataContext(cs);
                    var listPhones = new List<Smartfone>();
                    Table<Smartfone> phones = dc.GetTable<Smartfone>();
                    HtmlNode page = Downloader.GetPage(siteRef + $";page={i}").DocumentNode;
                    string xpath = "//*[@id='catalog_goods_block']/div/div[@class='g-i-tile g-i-tile-catalog']/div[1]/div[1]/div[1]/div[@class='g-i-tile-i-box-desc']";
                    var phoneNodes = page.SelectNodes(xpath).ToList();
                    ;
                    foreach (var pn in phoneNodes)
                    {
                        Smartfone phone = new Smartfone();
                        string xPath = "div[1]/div[1]/a/img";
                        var subNode = pn.SelectNodes(xPath).First();
                        string imgRef = subNode.Attributes[0].Value;
                        string phoneRef = subNode.ParentNode.Attributes[0].Value + "characteristics";
                        phone.Image = Downloader.GetImage(imgRef);
                        var val = Regex.Match(subNode.Attributes[4].Value, @"(\w*)\ (.*)").Groups;
                        phone.Brand = val[1].Value;
                        phone.Name = val[2].Value;
                        HtmlNode phonePage = Downloader.GetPage(phoneRef).DocumentNode;

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

                            listPhones.Add(phone);
                        }
                    }
                    phones.InsertAllOnSubmit(listPhones);
                    dc.SubmitChanges();
                }
            }
            catch (Exception) { }
        }
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
    }
}
