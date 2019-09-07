using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using week3_chat.Models;
using Microsoft.AspNet.Identity;

namespace week3_chat.Hubs
{
    public class ChatHub : Hub
    {
        static List<ChatUser> users = new List<ChatUser>();
        static List<ChatGroup> groups = new List<ChatGroup>() { new ChatGroup() { Name = "Основная" } };

        public void HubSendToGroup(string groupId, string textMessage)
        {
            var userName = HttpContext.Current.User.Identity.Name;
            var user = users.FirstOrDefault(u => u.Name == userName);
            var group = groups.FirstOrDefault(g => g.Id == groupId);

            if (user != null && group != null)
            {
                var message = new ChatMessage()
                {
                    Owner = user,
                    Text = textMessage,
                    Date = DateTime.Now
                };

                group.Messages.Add(message);
                Clients.All.createMessage(group.Id, message);
            }
            else Clients.Caller.errorMessage("Непредвиденная ошибка...");
        }

        public void HubCreateGroup(string groupName, string userId)
        {
            groupName = Regex.Replace(groupName, "<.*?>", "").Trim(); //Удаляем html тэги

            var groupOwner = users.FirstOrDefault(u => u.Id == userId);

            if (groupOwner != null && groupName != "")
            {
                groupName = char.ToUpper(groupName[0]) + groupName.Substring(1).ToLower(); //Делаем первую букву заглавной остальные строчные
                var newGroup = new ChatGroup() { Name = groupName, Owners = new List<ChatUser>() { groupOwner } };
                groups.Add(newGroup);
                Clients.All.createGroup(new { Owners = newGroup.Owners, newGroup.Id, newGroup.Name });
            }
            else Clients.Caller.errorMessage("Не верный формат имени группы...");
        }
        public void HubCreatePrivateGroup(string srcUserName, string dstUserName) {
            var srcUser = users.FirstOrDefault(u => u.Name == srcUserName);
            var dstUser = users.FirstOrDefault(u => u.Name == dstUserName);

            if (srcUser != null && dstUser != null) {
                var owners = new List<ChatUser>() { srcUser, dstUser };
                var newGroupId = Guid.NewGuid().ToString();
                var srcGroup = new ChatGroup() { Id = newGroupId, Name = dstUser.Name, Owners = owners };
                var dstGroup = new ChatGroup() { Id = newGroupId, Name = srcUser.Name, Owners = owners };

                groups.Add(srcGroup);

                Clients.Caller.createGroup(srcGroup);
                Clients.Client(dstUser.ConnectionId).createGroup(dstGroup);
            }
        }

        public void HubRemoveGroup(string groupId)
        {
            var userName = HttpContext.Current.User.Identity.Name;
            var user = users.FirstOrDefault(u => u.Name == userName);
            var group = groups.FirstOrDefault(g => g.Id == groupId);
            var isOwner = group.Owners.Any(o => o.Id == user.Id);

            if (user != null && group != null && isOwner)
            {
                groups.Remove(group);
                Clients.All.removeGroup(groupId);
            }
        }

        public void HubGetMessagesByGroup(string groupId)
        {
            var group = groups.FirstOrDefault(g => g.Id == groupId);

            if (group != null)
            {
                Clients.Caller.createMessages(group.Id, group.Messages);
            }
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
        public override Task OnConnected()
        {   
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string userName = HttpContext.Current.User.Identity.Name;
                var connectionId = Context.ConnectionId;
                var userId = HttpContext.Current.User.Identity.GetUserId();

                if (!users.Any(u => u.ConnectionId == connectionId))
                {
                    var user = users.FirstOrDefault(u => u.Name == userName);
                    if (user != null)
                    {
                        user.ConnectionId = connectionId;
                        Clients.All.removeUser(userName);
                    }
                    else
                    {
                        user = new ChatUser { Id = userId, ConnectionId = connectionId, Name = userName };
                        users.Add(user);
                        Clients.Others.createEnterNotification(userName);
                    }

                    var groupObjects = groups.Select(g => new { g.Owners, g.Id, g.Name,  }).ToList();
                    var userNames = users.Select(u => u.Name).ToList();
                    Clients.Caller.onConnected(user, userNames, groupObjects, groups[0].Messages);
                    Clients.Others.createUser(userName);
                }
            }

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var currentConnectedUser = users.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);

            if (currentConnectedUser != null)
            {
                users.Remove(currentConnectedUser);

                var id = Context.ConnectionId;
                Clients.Others.onDisconnected(currentConnectedUser.Name);
                Clients.Others.createExitNotification(currentConnectedUser.Name);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}