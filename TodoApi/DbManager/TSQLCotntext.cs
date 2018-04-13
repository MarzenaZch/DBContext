using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApi
{
    class TSQLContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-LDF80HU;Database=TSQL2012;Trusted_Connection=True");
        }
      public DbSet<Product> Products {get; set;}
       public DbSet<Category> Category{ get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
    }
}
