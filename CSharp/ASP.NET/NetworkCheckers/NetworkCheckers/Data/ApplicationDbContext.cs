using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetworkCheckers.Models;

namespace NetworkCheckers.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Game> Games { get; set; }
        static public ApplicationDbContext DbContext
        {
            get => new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=GEEK-PC;Initial Catalog=OnlineCheckersDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
