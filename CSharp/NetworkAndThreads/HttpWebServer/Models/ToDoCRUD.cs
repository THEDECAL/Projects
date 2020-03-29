using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebServer.Models
{
    static class ToDoCRUD
    {
        static public void CreateUser(User user)
        {
            if (user != null)
            {
                using (var dbContext = new ToDoDbContext())
                {
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
            }
            else new NullReferenceException();
        }
        static public User GetUser(string email)
        {
            if (email != null && email != "")
                using (var dbContext = new ToDoDbContext())
                    return dbContext.Users.FirstOrDefault(u => u.Email == email);
            throw new NullReferenceException();
        }
        static public User GetUser(int id)
        {
            using (var dbContext = new ToDoDbContext())
                return dbContext.Users.FirstOrDefault(u => u.Id == id);
        }
        static public User GetUserByConfirmCode(string confirmCode)
        {
            if (confirmCode != null && confirmCode != "")
                using (var dbContext = new ToDoDbContext())
                    return dbContext.Users.FirstOrDefault(u => u.ConfirmationCode == confirmCode);
            throw new NullReferenceException();
        }
        static public bool DeleteUser(string email)
        {
            if (email != null && email != "")
            {
                using (var dbContext = new ToDoDbContext())
                {
                    var user = dbContext.Users.FirstOrDefault(u => u.Email == email);
                    if (user != null)
                    {
                        dbContext.Users.Remove(user);
                        dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            else new NullReferenceException();
            return false;
        }
        static public void UpdateUser(User user)
        {
            if (user != null)
            {
                using (var dbContext = new ToDoDbContext())
                {
                    dbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                }
            }
            else new NullReferenceException();
        }
        static public void CreateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                using (var dbContext = new ToDoDbContext())
                {
                    dbContext.Tickets.Add(ticket);
                    dbContext.SaveChanges();
                }
            }
            else new NullReferenceException();
        }
        static public Ticket GetTicket(int id)
        {
            using (var dbContext = new ToDoDbContext())
                return dbContext.Tickets.FirstOrDefault(t => t.Id == id);
        }
        static public List<Ticket> GetAllTickets()
        {
            using (var dbContext = new ToDoDbContext())
                return dbContext.Tickets.ToList();
        }
        static public bool DeleteTicket(int id)
        {
            using (var dbContext = new ToDoDbContext())
            {
                var ticket = dbContext.Tickets.FirstOrDefault(t => t.Id == id);
                if (ticket != null)
                {
                    dbContext.Tickets.Remove(ticket);
                    dbContext.SaveChanges();

                    return true;
                }
            }
            return false;
        }
        static public void UpdateTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                using (var dbContext = new ToDoDbContext())
                {
                    var ticketInDb = dbContext.Tickets.FirstOrDefault(t => t.Id == ticket.Id);
                    if (ticketInDb != null)
                    {
                        ticketInDb.Copy(ticket);
                        //dbContext.Entry(ticket).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
            }
            else new NullReferenceException();
        }
    }
}
