using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace smartfon_catalog
{
    class SQLDbContext : DbContext
    {
        static public readonly SQLDbContext DbContext = new SQLDbContext();
        static SQLDbContext() { Database.SetInitializer(new SQLDbInitializer()); }
        SQLDbContext() : base("name=default") { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Smartfone> Smartfones { get; set; }
    }

    class SQLDbInitializer : DropCreateDatabaseIfModelChanges<SQLDbContext>
    {
        protected override void Seed(SQLDbContext context = null)
        {
            if (context == null) context = SQLDbContext.DbContext;
            Downloader.GetSmartfones();
        }
    }
}
