using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using week1.Models;
using week1.Models.db.Dao;

namespace week1.Controllers
{
    public class TicketsController : Controller
    {
        static TicketsDao ticketsDao = new TicketsDao();
        public ActionResult Index() => View(ticketsDao.GetAll());
        [HttpGet]
        public ActionResult Add() => View(new Ticket());
        [HttpPost]
        public ActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid) ticketsDao.Save(ticket);
            else return View(ticket);

            return Redirect(Url.Action("Index"));
        }
        [HttpGet]
        public ActionResult Show(int id)
        {
            var ticket = ticketsDao.Get(id);
            if (ticket is null) return HttpNotFound();

            return View(ticket);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ticket = ticketsDao.Get(id);
            if (ticket is null) return HttpNotFound();

            return View(ticket);
        }
        [HttpPost]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid) ticketsDao.Update(ticket);
            else return View(ticket);

            return Redirect(Url.Action("Index"));
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ticketsDao.Delete(id);

            return Redirect(Url.Action("Index"));
        }
        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            var ticket = ticketsDao.Get(id);

            if (ticket != null)
            {
                ticket.Status = !ticket.Status;
                ticketsDao.Update(ticket);
            }

            return Redirect(Url.Action("Index"));
        }
        [HttpPost]
        public ActionResult Search(string type, string text)
        {
            var searchResult = new List<Ticket>();
            searchResult = ticketsDao.GetAll(t => {
                if (text == "") return true;
                var tType = t.GetType();
                var tProp = tType.GetProperty(type);
                var propVal = tProp.GetValue(t);
                bool result = propVal.ToString().ToLower().Contains(text.ToLower());
                
                return result;
            });

            return View("Index", searchResult);
        }
        /// <summary>
        /// Метод получения текста ошибок валидации
        /// </summary>
        /// <param name="errorList">Принимает словарь состояния модели</param>
        /// <returns>Возвращает строку с текстом ошибок валидации</returns>
        public string ErrorMessage(ModelStateDictionary errorList)
        {
            var list = errorList.Where(e => e.Value.Errors.Count > 0).ToList();
            //var propt = typeof(Ticket).GetProperty(list[0].Key);
            //Получение атрибута DisplayName из свойства
            //var attrt = propt.GetCustomAttributes(typeof(DisplayAttribute), true).Single() as DisplayAttribute;

            var errorsText = list.Select(e => e.Value.Errors.Single().ErrorMessage).ToList();

            StringBuilder message = new StringBuilder();
            errorsText.ForEach(e => message.Append(e + "<br>"));

            return message.ToString();
        }
    }
}