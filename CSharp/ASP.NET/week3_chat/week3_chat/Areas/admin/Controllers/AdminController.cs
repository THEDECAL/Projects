using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using week3_chat.Hubs;
using week3_chat.Models;

namespace week3_chat.Areas.admin.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult UserBlocker()
        {
            List<ChatUser> users;
            using (var dbContext = new ApplicationDbContext())
            {
                users = dbContext.Users.Select(u => new ChatUser{ Id = u.Id, Name = u.UserName, isBlocked = u.IsBlockedInChat }).ToList();
            }

            return View(users);
        }
        public ActionResult ChangeBlockStatus(string id)
        {
            if (id != null && id != "")
            {
                using (var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
                {
                    var currUser = userManager.FindById(id);

                    if (currUser != null)
                    {
                        var user = ChatHub.Users.FirstOrDefault(u => u.Id == id);
                        var chatHub = GlobalHost.ConnectionManager?.GetHubContext<ChatHub>();

                        currUser.IsBlockedInChat = !currUser.IsBlockedInChat;
                        userManager.Update(currUser);

                        if (user != null && chatHub != null)
                        {
                            if (currUser.IsBlockedInChat)
                            {
                                chatHub.Clients.All.createBlockedNotification(user.Name);
                                chatHub.Clients.AllExcept(user.ConnectionId).removeUser(user.Name);
                                chatHub.Clients.Client(user.ConnectionId).blockUser();
                            }
                            else
                            {
                                var groupObjects = ChatHub.Groups.Select(g => new { g.Owners, g.Id, g.Name, }).ToList();
                                var userNames = ChatHub.Users.Where(u => !u.isBlocked).Select(u => u.Name).ToList();

                                chatHub.Clients.AllExcept(user.ConnectionId).createEnterNotification(user.Name);
                                chatHub.Clients.Client(user.ConnectionId).onConnected(user, userNames, groupObjects, ChatHub.Groups[0].Messages);
                                chatHub.Clients.AllExcept(user.ConnectionId).createUser(user.Name);
                            }
                        }
                    }
                }
            }
            return Redirect(Url.Action("UserBlocker"));
        }
    }
}