using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static HttpWebServer.Models.PageBuilder;

namespace HttpWebServer.Models
{
    class Site
    {
        static Site _instance;
        public Dictionary<string, PageBuildDelegate> _pages = new Dictionary<string, PageBuildDelegate>();
        readonly string _currDir = Directory.GetCurrentDirectory();
        const string _srcMailAddress = "fortestingfortestingfor@gmail.com";
        const string _srcMailPassword = "5u#[qo8>";
        readonly SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", 587);

        string SiteAddress { get => Program.SiteAddress; }
        public User UserLogIn { get; private set; }

        Site()
        {
            InitPages();
        }

        /// <summary>
        /// Метод получение контента сайта (страницы, файлы, перенапрвления)
        /// </summary>
        /// <param name="request">Принимает объект HTTP-запроса</param>
        /// <param name="response">Принимает объект HTTP-ответа</param>
        /// <param name="queryParams">Принимает словарь GET, POST параметров</param>
        public void GetContent(HttpListenerRequest request,  HttpListenerResponse response, NameValueCollection queryParams = null)
        {
            if (request != null && response != null)
            {
                var url = request.Url.AbsolutePath;
                byte[] data = new byte[0];
                response.ContentType = "text/html";

                var filePath = _currDir + url.Replace('/', '\\');
                if (filePath != _currDir && File.Exists(filePath)) //Ищим в текущей дерриктории файлы
                {
                    data = File.ReadAllBytes(filePath);
                    response.ContentLength64 = data.Length;
                    response.ContentType = GetContentType(Path.GetExtension(filePath));
                }
                else //Если файлов нет, то обрабатываем запрос
                {
                    try
                    {
                        var selectedPage = _pages[url].Invoke(queryParams);
                        data = Encoding.UTF8.GetBytes(selectedPage.HtmlCode);
                    }
                    catch (HttpRedirectException ex) { response.Redirect(SiteAddress + ex.Message); }
                    catch (KeyNotFoundException)
                    {
                        var @params = new NameValueCollection() { ["msg"] = "Ошибка 404, страница не найдена." };
                        data = Encoding.UTF8.GetBytes(_pages["/error"].Invoke(@params).HtmlCode);
                    }
                    catch (MessageException ex)
                    {
                        var @params = new NameValueCollection() { ["msg"] = ex.Message };
                        data = Encoding.UTF8.GetBytes(_pages["/error"].Invoke(@params).HtmlCode);
                    }
                    catch (Exception ex)
                    {
                        var @params = new NameValueCollection() { ["msg"] = "Непредвиденная ошибка" };
                        data = Encoding.UTF8.GetBytes(_pages["/error"].Invoke(@params).HtmlCode);
                    }
                }

                using (var s = response.OutputStream)
                    s.Write(data, 0, data.Length);
            }
            else throw new NullReferenceException();
        }
        private void InitPages()
        {
            //Страница ошибки
            PageBuildDelegate errorPage = (@params) =>
            {
                var page = new PageBuilder()
                    .AddDefaultScripts()
                    .AddTitle("Ошибка")
                    .AddHeader(@params["msg"])
                    .AddMenu(MakeMenu());

                return page;
            };
            AddPage("/error", errorPage);

            //Стартовая страница
            PageBuildDelegate indexPage = (@params) =>
            {
                var list = ToDoCRUD.GetAllTickets();
                var page = new PageBuilder()
                    .AddDefaultScripts()
                    .AddTitle("Главная страница")
                    .AddHeader($"Список заявок ({list.Count()} шт.)")
                    .AddMenu(MakeMenu())
                    .AddTicketsTable(list);

                return page;
            };
            AddPage("/", indexPage);
            AddPage("/index", indexPage);

            //Страница регистрации пользователей
            PageBuildDelegate reginPage = (@params) =>
            {
                var page = new PageBuilder()
                    .AddParams(@params)
                    .AddDefaultScripts()
                    .AddTitle("Регестрация")
                    .AddMenu(MakeMenu())
                    .AddRegistrationForm();
                page.PageHandler += Regin;

                return page;
            };
            AddPage("/regin", reginPage);

            //Страница входа пользователей
            PageBuildDelegate loginPage = (@params) =>
            {
                var page = new PageBuilder()
                    .AddParams(@params)
                    .AddDefaultScripts()
                    .AddTitle("Вход")
                    .AddMenu(MakeMenu())
                    .AddLogInForm();
                page.PageHandler += LogIn;

                return page;
            };
            AddPage("/login", loginPage);

            //Страница выхода пользователей
            PageBuildDelegate logoutPage = (@params) =>
            {
                var page = new PageBuilder();
                page.PageHandler += LogOut;

                return page;
            };
            AddPage("/logout", logoutPage);

            //Страница подтверждения регестрации
            PageBuildDelegate confirmPage = (@params) =>
            {
                var page = new PageBuilder()
                    .AddParams(@params);
                page.PageHandler += RegConfirm;

                return page;
            };
            AddPage("/confirm", confirmPage);

            //Страница добавления или изменения заявки
            PageBuildDelegate addPage = (@params) =>
            {
                if (UserLogIn is null)
                    throw new MessageException("Войдите для добавления заявок.");

                var page = new PageBuilder()
                    .AddParams(@params)
                    .AddDefaultScripts()
                    .AddTitle("Добавление заявки")
                    .AddHeader("Добавление заявки")
                    .AddMenu(MakeMenu())
                    .AddTicketAddEdit();
                page.PageHandler += AddEditTicket;

                return page;
            };
            AddPage("/add", addPage);

            //Страница изменения заявки
            PageBuildDelegate editPage = (@params) =>
            {
                if (UserLogIn is null)
                    throw new MessageException("Войдите для изменения заявок.");

                var ticket = ToDoCRUD.GetTicket(Convert.ToInt32(@params["id"]));

                var page = new PageBuilder()
                    .AddParams(@params)
                    .AddDefaultScripts()
                    .AddTitle("Изменение заявки")
                    .AddHeader("Изменение заявки")
                    .AddMenu(MakeMenu())
                    .AddTicketAddEdit(ticket);
                page.PageHandler += AddEditTicket;

                return page;
            };
            AddPage("/edit", editPage);

            //Страница удаления заявки
            PageBuildDelegate delPage = (@params) =>
            {
                if (UserLogIn is null)
                    throw new MessageException("Войдите для удаления заявок.");

                var page = new PageBuilder()
                    .AddParams(@params);
                page.PageHandler += DelTicket;

                return page;
            };
            AddPage("/del", delPage);
        }
        /// <summary>
        /// Метод создания словаря меню
        /// </summary>
        /// <returns>Возвращает словарь, где key - ссылка, value - название</returns>
        private Dictionary<string, string> MakeMenu()
        {
            var menu = new Dictionary<string, string>()
            {
                [SiteAddress + "index"] = "Главная",
                [SiteAddress + "regin"] = "Регистрация"
            };

            if (UserLogIn == null) menu.Add("login", "Вход");
            else menu.Add("logout", $"Выход ({UserLogIn?.Email})");

            return menu;
        }
        /// <summary>
        /// Метод регестрации пользователя
        /// </summary>
        /// <param name="params">Принимает словарь параметров</param>
        private void Regin(NameValueCollection @params)
        {
            if (@params != null && @params.Count > 0)
            {
                var email = @params["email"].Trim();
                var password1 = @params["password1"].Trim();
                var password2 = @params["password1"].Trim();

                if (password1 == password2 &&
                    email != "" && password1 != "")
                {
                    if (ToDoCRUD.GetUser(email) == null)
                    {
                        var user = new User();
                        user.Email = email;
                        user.Password = password1;
                        user.ConfirmationCode = Guid.NewGuid().ToString();

                        ToDoCRUD.CreateUser(user);
                        SendMailConfirmation(user.ConfirmationCode, user.Email);

                        throw new HttpRedirectException("index");
                    }
                    else throw new MessageException("Такой Email уже существует.");
                }
                else throw new MessageException("Обязательные поля не заполнены.");
            }
        }
        /// <summary>
        /// Метод входа пользователя
        /// </summary>
        /// <param name="params">Принимает словарь параметров</param>
        private void LogIn(NameValueCollection @params)
        {
            if (@params != null && @params.Count > 0)
            {
                var email = @params["email"].Trim();
                var password = @params["password"].Trim();

                if (email != "" && password != "")
                {
                    var user = new User();
                    user.Email = email;
                    user.Password = password;
                    var userInBD = ToDoCRUD.GetUser(email);

                    if (userInBD != null && userInBD.Equals(user))
                    {
                        if (userInBD.IsEmailConfirmed)
                        {
                            UserLogIn = user;
                            throw new HttpRedirectException("index");
                        }
                        else throw new MessageException("Ваш Email не подтверждён.");
                    }
                }
                else throw new MessageException("Обязательные поля не заполнены.");
            }
        }
        /// <summary>
        /// Метод выхода пользователя
        /// </summary>
        /// <param name="params">Принимает словарь параметров</param>
        private void LogOut(NameValueCollection @params)
        {
            UserLogIn = null;
            throw new HttpRedirectException("index");
        }
        /// <summary>
        /// Метод подтверждения регестрации пользователя
        /// </summary>
        /// <param name="params">Принимает словарь параметров</param>
        private void RegConfirm(NameValueCollection @params)
        {
            var confirmCode = @params["code"].Trim();

            if (confirmCode != "")
            {
                var userInDB = ToDoCRUD.GetUserByConfirmCode(confirmCode);
                if (userInDB.ConfirmationCode == confirmCode)
                {
                    userInDB.IsEmailConfirmed = true;
                    ToDoCRUD.UpdateUser(userInDB);

                    throw new MessageException($"Почта {userInDB.Email} подтверждена.");
                }
            }
            throw new HttpRedirectException("index");
        }
        /// <summary>
        /// Метод добавления или изменения заявки
        /// </summary>
        /// <param name="params">Принимает словарь параметров</param>
        private void AddEditTicket(NameValueCollection @params)
        {
            if (@params != null && @params.Count > 1)
            {
                var id = Convert.ToInt32(@params["id"].Trim());
                var title = @params["title"].Trim();
                var comments = @params["comments"].Trim();

                if (title != "")
                {
                    var ticket = (id != 0) ? ToDoCRUD.GetTicket(id) : new Ticket();

                    if (ticket != null)
                    {
                        ticket.Title = title;
                        ticket.Comments = comments;
                        ticket.User = UserLogIn;

                        if (id != 0)
                            ToDoCRUD.UpdateTicket(ticket);
                        else
                            ToDoCRUD.CreateTicket(ticket);

                        throw new HttpRedirectException("index");
                    }
                    else throw new NullReferenceException();
                }
                else throw new MessageException("Не заполнены обязательыне поля.");
            }
        }
        /// <summary>
        /// Метод удаления заявки
        /// </summary>
        /// <param name="params">Принимает словарь параметров</param>
        private void DelTicket(NameValueCollection @params)
        {
            if (@params != null && @params.Count > 0)
            {
                var id = Convert.ToInt32(@params["id"]);

                if (ToDoCRUD.DeleteTicket(id))
                    throw new HttpRedirectException("index");
                else
                    throw new Exception();
            }
        }
        /// <summary>
        /// Метод добалвения страницы в словарь
        /// </summary>
        /// <param name="ref">Принимает ссылку на страницу</param>
        /// <param name="pageBuild">Принимает строителя страницы</param>
        private void AddPage(string @ref, PageBuildDelegate pageBuild)
        {
            if (!_pages.ContainsKey(@ref)) _pages.Add(@ref, pageBuild);
        }
        /// <summary>
        /// Метод отправки письма для подтверждения почты
        /// </summary>
        /// <param name="confirmationCode"></param>
        private void SendMailConfirmation(string confirmationCode, string email)
        {
            if (confirmationCode != null && email != null)
            {
                var srcMailAddress = new MailAddress(_srcMailAddress);
                var dstMailAddress = new MailAddress(email);
                var @ref = $"<a href='{SiteAddress}confirm?code={confirmationCode}'>этой ссылке</a>";
                var mailText = new PageBuilder()
                    .AddHeader($"Перейдите по {@ref}, чтобы активировать свою учётную запись.");

                var msg = new MailMessage(srcMailAddress, dstMailAddress);
                msg.Subject = "Активация учётной записи";
                msg.Body = mailText.HtmlCode;
                msg.IsBodyHtml = true;

                _smtpClient.Credentials = new NetworkCredential(_srcMailAddress, _srcMailPassword);
                _smtpClient.EnableSsl = true;
                _smtpClient.Send(msg);
            }
            else throw new NullReferenceException();
        }
        /// <summary>
        /// Метод получения ContentType HTTP ответа
        /// </summary>
        /// <param name="extension">Принимает расширение файла</param>
        /// <returns>Возвращает ContentType</returns>
        private string GetContentType(string extension)
        {
            switch (extension)
            {
                case (".css"): case (".map"): return "text/css";
                case (".js"): return "text/javascript";
                case (".jpg"): case ("jpeg"): return "text/jpeg";
                case (".png"): return "text/png";
                case (".svg"): return "text/svg";
                case (".gif"): return "text/gif";
                default: return "text/html";
            }
        }
        /// <summary>
        /// Метод получения единственного экземпляра класса
        /// </summary>
        /// <returns>Возвращает объект класса</returns>
        static public Site Get() => _instance = _instance ?? new Site();
    }
}