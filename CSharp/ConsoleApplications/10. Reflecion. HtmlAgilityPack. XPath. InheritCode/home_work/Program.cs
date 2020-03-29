using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace home_work
{
    class Film
    {
        public string Name { get; set; } = "-";
        public string Year { get; set; } = "-";
        public string Country { get; set; } = "-";
        public string Genre { get; set; } = "-";
        public string Time { get; set; } = "-";
        public string View { get; set; } = "-";
        public string Starring { get; set; } = "-";
        public string About { get; set; } = "-";
        public override string ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append(("Название: " + Name + "\n"));
            text.Append(("Год: " + Year + "\n"));
            text.Append(("Страна: " + Country + "\n"));
            text.Append(("Жанр: " + Genre + "\n"));
            text.Append(("Время: " + Time + "\n"));
            text.Append(("Просмотр: " + View + "\n"));
            text.Append(("В главных ролях: " + Starring +"\n"));
            text.Append(("Про фильм: " + About + "\n"));

            return text.ToString();
        }
    }
    class Program
    {
        static string siteURL;
        static HtmlDocument GetPage(string URL)
        {
            WebClient client = new WebClient();
            HtmlDocument htmlDoc = new HtmlDocument();
            
            byte[] page = client.DownloadData(URL);
            //Console.WriteLine("Downloaded " + page.Length + " byte.");
            string htmlPage = Encoding.UTF8.GetString(page);
            htmlDoc.LoadHtml(htmlPage);

            return htmlDoc;
        }
        static Dictionary<string, string> Genres()
        {
            //Получение списка жанров фильмов
            HtmlNode root = GetPage(siteURL).DocumentNode;
            HtmlNode genreNode = root.SelectSingleNode("//*[@id='catline']/ul");
            ;

            Dictionary<string, string> genreLinks = new Dictionary<string, string>();

            for (int i = 0; i < genreNode.ChildNodes.Count; i++)
            {
                if (genreNode.ChildNodes[i].Name == "li")
                {
                    string pattern = ".*href=\\\"(?<link>.*)\\\".*";
                    string link = genreNode.ChildNodes[i].OuterHtml;
                    string text = genreNode.ChildNodes[i].InnerText;
                    genreLinks.Add(text, siteURL + Regex.Match(link, pattern).Groups["link"].Value);
                }
            }

            return genreLinks;
        }
        static Dictionary<string, string> Films(string link)
        {
            //Получение списка фильмов
            HtmlNode root = GetPage(link).DocumentNode;
            HtmlNode filmsNode = root.SelectSingleNode("//*[@id='posts']");

            Dictionary<string, string> filmLinks = new Dictionary<string, string>();

            for (int i = 0; i<filmsNode.ChildNodes.Count; i++)
            {
                if (filmsNode.ChildNodes[i].Name == "a")
                {
                    string pattern = @".*\<span\>(?<title>.*)\<\/span\>.*";
                    string text = filmsNode.ChildNodes[i].InnerHtml;
                    string lnk = filmsNode.ChildNodes[i].Attributes[1].DeEntitizeValue;
                    filmLinks.Add(Regex.Match(text, pattern).Groups["title"].Value, lnk);
                }
            }

            return filmLinks;
        }
        static Film CreateFilm(string link)
        {
            Film film = new Film();

            //Получение списка фильмов
            HtmlNode root = GetPage(link).DocumentNode;
            HtmlNode filmNode = root.SelectSingleNode("//*[@id='single']/div[1]");
            HtmlNode descNode = root.SelectSingleNode("//*[@id='single']/div[3]/div[3]");

            foreach (var item in filmNode.ChildNodes)
            {
                if (item.Name == "div")
                {
                    switch (item.ChildNodes[0].InnerText)
                    {
                        case "название": film.Name = item.ChildNodes[1].InnerText; break;
                        case "год": film.Year = item.ChildNodes[1].InnerText; break;
                        case "страна": film.Country = item.ChildNodes[1].InnerText; break;
                        case "жанр": film.Genre = item.ChildNodes[1].InnerText; break;
                        case "время": film.Time = item.ChildNodes[1].InnerText; break;
                        case "просмотр": film.View = item.ChildNodes[1].InnerText; break;
                        case "в главных ролях": film.Starring = item.ChildNodes[1].InnerText; break;
                    }
                }
            }

            film.About = descNode.InnerText;

            return film;
        }
static string menu(string title, Dictionary<string, string> links)
        {
            if (links.Count < 1 || links == null) throw new InvalidOperationException();

            int arrow = 1;
            string Key = null;

            for (;;)
            {
                Console.WriteLine(title + ":");
                if (arrow > links.Count) arrow = 1;
                if (arrow < 1) arrow = links.Count;

                int cnt = 1;
                foreach (string item in links.Keys)
                {
                    Console.WriteLine($"{(cnt == arrow ? ">" : " ")}" + item);
                    if(cnt == arrow) Key = item;
                    cnt++;
                }

                ConsoleKeyInfo pressingkey = Console.ReadKey();
                switch (pressingkey.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow: arrow--; break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow: arrow++; break;
                    case ConsoleKey.Enter: return links[Key];
                }
                Console.Clear();
            }
        }
        static void Main()
        {
            for (;;)
            {
                siteURL = "http://gidonline.in";
                Console.WriteLine("Консольный вариант сайта " + siteURL);

                Console.Clear();
                string genre = menu("Жанры", Genres());

                Console.Clear();
                string film = menu("Фильмы", Films(genre));

                Console.Clear();
                Console.WriteLine(CreateFilm(film));

                Console.WriteLine("Нажмите любую кнопку, чтобы сделать новый выбор или Ctrl + C для выхода.");
                Console.ReadKey();
            }
        }
    }
}
