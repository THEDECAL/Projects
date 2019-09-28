using System.Web.Mvc;

namespace week3_chat.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}