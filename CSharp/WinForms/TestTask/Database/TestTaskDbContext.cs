using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Entities;

namespace TestTask.Database
{
    class TestTaskDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<TransferHistory> TransferHistories { get; set; }

        public TestTaskDbContext() : base("DefaultConnection")
        {

        }
    }
}
