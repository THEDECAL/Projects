using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebServer.Models
{
    public class PageBuilder
    {
        HtmlDocument _htmlDoc;
        NameValueCollection _queryParams;

        HtmlNode Body { get => _htmlDoc.DocumentNode.SelectSingleNode("//body"); }
        HtmlNode Head { get => _htmlDoc.DocumentNode.SelectSingleNode("//head"); }
        HtmlDocument HtmlDoc { get => _htmlDoc; }
        string SiteAddress { get => Program.SiteAddress; }
        public object Data { get; set; }
        public string HtmlCode
        {
            get
            {
                PageHandler?.Invoke(_queryParams);
                return _htmlDoc.DocumentNode.InnerHtml;
            }
        }
        public string SourcePage { get => _htmlDoc.DocumentNode.InnerHtml; }

        public delegate void PageHanlderDelegate(NameValueCollection @params = null);
        /// <summary>
        /// Делегат отложенной сборки страницы
        /// </summary>
        public delegate PageBuilder PageBuildDelegate(NameValueCollection @params = null);
        /// <summary>
        /// Обработчик событий на странице
        /// </summary>
        public event PageHanlderDelegate PageHandler;
        
        public PageBuilder()
        {
            Init();
        }

        /// <summary>
        /// Инициализация начальных тегов страницы
        /// </summary>
        private void Init()
        {
            _htmlDoc = new HtmlDocument();
            var html = MakeNode("html", outerHtml: @"<!DOCTYPE html>");
            var head = MakeNode("head");
            var body = MakeNode("body", nodeClass: "container");

            _htmlDoc.DocumentNode.AppendChild(html);
            html.AppendChild(head);
            html.AppendChild(body);
        }
        /// Метод очистки сраницы до основных тегов
        /// </summary>
        /// <returns>Возвращает ссылку на текущий класс</returns>
        public PageBuilder Clear()
        {
            Body.RemoveAll();
            Head.RemoveAll();

            return this;
        }
        /// <summary>
        /// Метод добавления парного тега
        /// </summary>
        /// <param name="name">Принимает имя тега</param>
        /// <returns>Возвращает ссылку на новый узел</returns>
        private HtmlNode MakeNode
            (string tagName, Dictionary<string, string> attrs = null,
            string innerHtml = null, string outerHtml = "",
            HtmlNode prntNode = null,
            string nodeClass = null, string nodeId = null)
        {
            if (tagName != null)
            {
                var node = HtmlNode.CreateNode($"{outerHtml}<{tagName}></{tagName}>");
                if(attrs != null) node.Attributes.AddRange(attrs);
                if (innerHtml != null) node.InnerHtml = innerHtml;
                if (prntNode != null) node.SetParent(prntNode);
                if (nodeClass != null) node.AddClass(nodeClass);
                if (nodeId != null) node.Id = nodeId;

                return node;
            }
            else throw new ArgumentNullException();
        }
        /// <summary>
        /// Метод добавления заголовка страницы
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Возвращает ссылку на текущий класс</returns>
        public PageBuilder AddTitle(string title)
        {
            var titleCont = MakeNode("title", innerHtml: title);
            Head.PrependChild(titleCont);

            return this;
        }
        /// <summary>
        /// Метод добавления скрипта на страницу
        /// </summary>
        /// <param name="pathToScript">Принимает путь к скрипту относительно корня сайта</param>
        /// <param name="parentNode">Принимает родительский узел для втсавки</param>
        /// <param name="parentXPath">Принимает XPath для вставки</param>
        /// <returns>Возвращает ссылку на текущий класс</returns>
        public PageBuilder AddScript(string pathToScript, string prntId = null, HtmlNode prntNode = null)
        {
            var scriptNode = MakeNode("script", new Dictionary<string, string>()
            {
                ["type"] = "text/javascript",
                ["src"] = pathToScript
            });

            if (prntId != null)
            {
                var node = _htmlDoc.GetElementbyId(prntId);
                node.AppendChild(scriptNode);
            }
            else if (prntNode != null)
            {
                prntNode.AppendChild(scriptNode);
            }
            else throw new ArgumentException();

            return this;
        }
        /// <summary>
        /// Метод добавления стиля на страницу
        /// </summary>
        /// <param name="pathToScript">Принимает путь к стилю относительно корня сайта</param>
        /// <param name="parentNode">Принимает родительский узел для втсавки</param>
        /// <param name="parentXPath">Принимает XPath для вставки</param>
        /// <returns>Возвращает ссылку на текущий класс</returns>
        public PageBuilder AddStyle(string pathToStyle, string prntId = null, HtmlNode prntNode = null)
        {
            var styleNode = MakeNode("link", new Dictionary<string, string>()
            {
                ["rel"] = "stylesheet",
                ["href"] = pathToStyle
            });

            if (prntId != null)
            {
                var node = _htmlDoc.GetElementbyId(prntId);
                node.AppendChild(styleNode);
            }
            else if (prntNode != null)
            {
                prntNode.AppendChild(styleNode);
            }
            else throw new ArgumentException();

            return this;
        }
        public PageBuilder AddMenu(Dictionary<string, string> menuItems)
        {
            var nav = MakeNode("nav", nodeClass: "navbar navbar-expand-lg navbar-dark bg-dark");
            var a = MakeNode("navbar-brand", attrs:new Dictionary<string, string>() { ["href"] = "#" });
            var button = MakeNode("button", attrs:new Dictionary<string, string>()
            {
                ["type"] = "button",
                ["data-toggle"] = "collapse",
                ["data-target"] = "#navbarNav",
                ["aria-controls"] = "navbarNav",
                ["aria-expanded"] = "false",
                ["aria-label"] = "Toggle navigation"
            },
            innerHtml: "<span class='navbar-toggler-icon'></span>",
            nodeClass: "navbar-toggler");
            var div = MakeNode("div", nodeClass: "collapse navbar-collapse", nodeId: "navbarNav");
            var ul = MakeNode("ul", nodeClass: "navbar-nav");

            nav.AppendChild(a);
            nav.AppendChild(button);
            nav.AppendChild(div);
            div.AppendChild(ul);

            var selectedItem = MakeNode("li", nodeClass: "nav-item active",
                innerHtml: $"<a class='nav-link' href='{menuItems.Keys.First()}'>{menuItems.Values.First()}<span class='sr-only'>(current)</span></a>");
            ul.AppendChild(selectedItem);

            var keyList = menuItems.Keys.ToList();
            for (int i = 1; i < menuItems.Keys.Count; i++)
            {
                var menuItem = MakeNode("li", nodeClass: "nav-item",
                innerHtml: $"<a class='nav-link' href='{keyList[i]}'>{menuItems[keyList[i]]}</a>");
                ul.AppendChild(menuItem);
            }

            Body.PrependChild(nav);

            return this;
        }
        public PageBuilder AddRegistrationForm()
        {
            var form = MakeNode("form", attrs: new Dictionary<string, string>() { ["method"] = "post" }, innerHtml: @"
                    <div class='form-group'>
                        <label for='exampleInputEmail1'>Email*</label>
                        <input type='email' class='form-control' name='email' aria-describedby='emailHelp' placeholder='Введите Email'>
                    </div>
                    <div class='form-group'>
                        <label for='exampleInputPassword1'>Пароль*</label>
                        <input type='password' class='form-control' name='password1' placeholder='Пароль'>
                    </div>
                    <div class='form-group'>
                        <input type='password' class='form-control' name='password2' placeholder='Повторите ввод пароля'>
                    </div>
                    <button type='submit' class='btn btn-primary'>Зарегестрироватся</button>");

            Body.AppendChild(form);

            return this;
        }
        public PageBuilder AddLogInForm()
        {
            var form = MakeNode("form", attrs: new Dictionary<string, string>() { ["method"] = "post" }, innerHtml: @"
                    <div class='form-group'>
                        <label for='exampleInputEmail1'>Email*</label>
                        <input type='email' class='form-control' name='email' aria-describedby='emailHelp' placeholder='Введите Email'>
                    </div>
                    <div class='form-group'>
                        <label for='exampleInputPassword'>Пароль*</label>
                        <input type='password' class='form-control' name='password' placeholder='Пароль'>
                    </div>
                    <button type='submit' class='btn btn-primary'>Войти</button>");

            Body.AppendChild(form);

            return this;
        }
        public PageBuilder AddHeader(string headerText)
        {
            if (headerText != null)
            {
                var h2 = MakeNode("h3", innerHtml:headerText, nodeClass:"m-3");
                Body.PrependChild(h2);
            }
            else throw new NullReferenceException();
            return this;
        }
        public PageBuilder AddDefaultScripts()
        {
            AddStyle(SiteAddress + @"Content\bootstrap.min.css", prntNode: Head);
            //AddStyle(SiteAddress + @"Content\mystyle.css", prntNode: Head);

            AddScript(SiteAddress + @"Scripts\jquery-3.0.0.min.js", prntNode: Body);
            AddScript(SiteAddress + @"Scripts\popper-utils.min.js", prntNode: Body);
            AddScript(SiteAddress + @"Scripts\bootstrap.min.js", prntNode: Body);

            return this;
        }
        public PageBuilder AddTicketsTable(IEnumerable<Ticket> list)
        {
            var addButton = MakeNode("a", attrs: new Dictionary<string, string>() { ["type"] = "button", ["href"] = $"{SiteAddress}add"},
                nodeClass: "btn btn-primary btn-lg btn-block", innerHtml:"Добавить заявку");
            var table = MakeNode("table", nodeClass: "table table-striped table-dark");

            if (list.Count() > 0)
            {
                var thead = MakeNode("thead", innerHtml: @"
                    <tr>
                        <th scope='col'>#</th>
                        <th scope='col'>Заголовок</th>
                        <th scope='col'>Комментарии</th>
                        <th scope='col'>Пользователь</th>
                        <th scope='col'>Действия</th>
                    </tr>");
                var tbody = MakeNode("tbody");
                table.AppendChild(thead);
                table.AppendChild(tbody);

                for (int i = 0; i < list.Count(); i++)
                {
                    var item = list.ElementAt(i);
                    item.User = ToDoCRUD.GetUser(item.UserId);
                    var tr = MakeNode("tr", innerHtml:$"<th scope='row'>{++i}</th>" +
                        $"<td>{item.Title}</td>" +
                        $"<td>{item.Comments}</td>" +
                        $"<td>{item.User.Email}</td>" +
                        @"<td>" +
                        $"<a class='btn btn-success btn-sm' href='{SiteAddress + "edit?id=" + item.Id}'>Изменить</a>" +
                        $"<a class='btn btn-danger btn-sm' href='{SiteAddress + "del?id=" + item.Id}'>Удалить</a>" +
                        @"</td>");
                    tbody.AppendChild(tr);
                }
            }

            Body.AppendChild(addButton);
            Body.AppendChild(table);

            return this;
        }
        public PageBuilder AddTicketAddEdit(Ticket ticket = null)
        {
            ticket = ticket ?? new Ticket() { Id = 0 };
            var buttonName = (ticket.Id == 0) ? "Добавить" : "Изменить";

            var form = MakeNode("form", attrs: new Dictionary<string, string>() { ["method"] = "post" },
                nodeClass:"m-3",
                innerHtml:
                @"<div class='form-group'>" +
                    @"<label for='exampleInputTitle'>Заголовок*</label>" +
                    $"<input class='form-control' name='title' aria-describedby='titleHelp' placeholder='Введите заголовок' value='{ticket.Title}'/>" +
                @"</div>" +
                @"<div>" +
                    @"<label for='exampleInputComments'>Комментарии</label>" +
                    $"<input class='form-control' name='comments' aria-describedby='titleHelp' placeholder='Введите коментарий' value='{ticket.Comments}'/>" +
                @"</div>" +
                $"<input type='hidden' name='id' value='{ticket.Id}'/>" +
                $"<button type='submit' class='btn btn-primary m-2'>{buttonName}</button>");

            Body.AppendChild(form);

            return this;
        }
        public PageBuilder AddParams(NameValueCollection @params)
        {
            @params = @params ?? new NameValueCollection();
            _queryParams = @params;
            return this;
        }
    }
}
