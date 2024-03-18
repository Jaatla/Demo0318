using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string myConnectionString = "Server=127.0.0.1;User ID=root;  Password=;Database=Demo03018";
            optionsBuilder.UseMySql(myConnectionString,ServerVersion.AutoDetect(myConnectionString));           
        }

        public DbSet<Alkalmazott> Alkalmazott { get; set; }

    }
}
