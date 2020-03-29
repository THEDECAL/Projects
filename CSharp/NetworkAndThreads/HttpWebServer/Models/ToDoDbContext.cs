using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebServer.Models
{
    public class ToDoDbContext : DbContext
    {
        static ToDoDbContext()
        {
            Database.SetInitializer<ToDoDbContext>(new ToDoDbInitializer());
        }
        public ToDoDbContext() : base("default") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set;  }
    }

    public class ToDoDbInitializer : CreateDatabaseIfNotExists<ToDoDbContext>
    {
        protected override void Seed(ToDoDbContext context)
        {
            context.Users.Add(new User() { Email="thedecal1@gmail.com", Password="123", IsEmailConfirmed = true });
            base.Seed(context);
        }
    }
}
