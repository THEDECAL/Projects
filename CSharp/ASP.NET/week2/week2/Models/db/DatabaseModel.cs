using System.Data.Entity;
using System.Configuration;

namespace week2.Models.db
{
    public partial class DatabaseModel : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DatabaseModel() : base("name=DefaultConnection")
        {
            string mode = ConfigurationManager.AppSettings["InitMode"];

            switch (mode)
            {
                case "DropCreateDatabaseIfModelChanges":
                    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DatabaseModel>());
                    break;
                case "DropCreateDatabaseAlways":
                    Database.SetInitializer(new DropCreateDatabaseAlways<DatabaseModel>());
                    break;
                case "CreateDatabaseIfNotExists":
                default:
                    Database.SetInitializer(new CreateDatabaseIfNotExists<DatabaseModel>());
                    break;
            }
        }
        protected override void OnModelCreating(DbModelBuilder dbmb)
        {
            dbmb.Entity<Ticket>()
                .Property(e => e.Title)
                .IsUnicode(false);

            dbmb.Entity<Ticket>()
                .Property(e => e.Description)
                .IsUnicode(false);

            dbmb.Entity<Ticket>()
                .Property(e => e.CreateDate);

            dbmb.Entity<Ticket>()
                .Property(e => e.EndDate);
        }
    }
}