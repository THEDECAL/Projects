using System;
using System.Collections.Generic;
using System.Linq;

namespace week2.Models.db.Dao
{
    public class TicketsDao : IDao<Ticket>
    {
        DatabaseModel dbConnection;
        public bool Delete(int id)
        {
            using (dbConnection = new DatabaseModel())
            {
                var ticket = dbConnection.Tickets
                    .Where(t => t.IsDelete == false)
                    .FirstOrDefault(t => t.Id == id);

                if (ticket is null) return false;

                ticket.IsDelete = true;

                return (dbConnection.SaveChanges() > 0) ? true : false;
            }
        }

        public Ticket Get(int id)
        {
            using (dbConnection = new DatabaseModel())
            {
                var ticket = dbConnection.Tickets
                .Where(t => t.IsDelete == false)
                .FirstOrDefault(t => t.Id == id);

                return ticket;
            }
        }

        public List<Ticket> GetAll(Func<Ticket, bool> predicate = null)
        {
            using (dbConnection = new DatabaseModel())
            {
                if (predicate is null) return dbConnection.Tickets.AsNoTracking()
                    .Where(t => t.IsDelete == false)
                    .ToList();

                return dbConnection.Tickets.AsNoTracking()
                    .Where(predicate)
                    .Where(t => t.IsDelete == false)
                    .ToList();
            }
        }

        public bool Save(Ticket ticket)
        {
            using (dbConnection = new DatabaseModel())
            {
                if (ticket is null) throw new NullReferenceException();

                dbConnection.Tickets.Add(ticket);
                return (dbConnection.SaveChanges() > 0) ? true : false;
            }
        }

        public bool Update(Ticket ticket)
        {
            using (dbConnection = new DatabaseModel())
            {
                if (ticket is null) throw new NullReferenceException();

                var ticketInDb = dbConnection.Tickets.FirstOrDefault(t => t.Id == ticket.Id && t.IsDelete == false);

                if (ticketInDb is null) throw new NullReferenceException();

                ticketInDb.Title = ticket.Title;
                ticketInDb.Description = ticket.Description;
                ticketInDb.Priority = ticket.Priority;
                ticketInDb.EndDate = ticket.EndDate;
                ticketInDb.Status = ticket.Status;

                return (dbConnection.SaveChanges() > 0) ? true : false;
            }
        }
    }
}