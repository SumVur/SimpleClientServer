using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerDal.Models;

namespace ServerDal
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SystemInfo> SystemInfos { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SystemInfo;Trusted_Connection=True;");
        }
    }
}
