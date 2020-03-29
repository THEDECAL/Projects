using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using week2.Models;
using week2.Models.db.Dao;

namespace week2.Controllers
{
    public class TicketsController : Controller
    {
        static TicketsDao ticketsDao = new TicketsDao();
        public ActionResult Index() => View(ticketsDao.GetAll());
        [HttpGet]
        public ActionResult Add()
        {
            if (User.Identity.IsAuthenticated)
                View(new Ticket());
            
            return new HttpUnauthorizedResult();
        }
        [HttpPost]
        public ActionResult Add(Ticket ticket)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid) ticketsDao.Save(ticket);
                else return View(ticket);

                return Redirect(Url.Action("Index"));
            }

            return new HttpUnauthorizedResult();
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
            if (User.Identity.IsAuthenticated)
            {
                var ticket = ticketsDao.Get(id);
                if (ticket is null) return HttpNotFound();

                return View(ticket);
            }

            return new HttpUnauthorizedResult();
        }
        [HttpPost]
        public ActionResult Edit(Ticket ticket)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid) ticketsDao.Update(ticket);
                else return View(ticket);

                return Redirect(Url.Action("Index"));
            }

            return new HttpUnauthorizedResult();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ticketsDao.Delete(id);

                return Redirect(Url.Action("Index"));
            }

            return new HttpUnauthorizedResult();
        }
        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var ticket = ticketsDao.Get(id);

                if (ticket != null)
                {
                    ticket.Status = !ticket.Status;
                    ticketsDao.Update(ticket);
                }

                return Redirect(Url.Action("Index"));
            }

            return new HttpUnauthorizedResult();
        }
        [HttpPost]
        public ActionResult _ShowSearchTickets(string type, string text)
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

            return PartialView(searchResult);
        }
    }
}