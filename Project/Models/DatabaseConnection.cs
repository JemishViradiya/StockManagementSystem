using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class DatabaseConnection:DbContext
    {
        public DatabaseConnection(DbContextOptions<DatabaseConnection> options) : base(options)
        {

        }
        public DbSet<Customer> customers { get; set; }
        
        public DbSet<Stock> stocks { get; set; }

        public DbSet<Fevourite> fevourites { get; set; }
  
        public DbSet<Payment> payments { get; set; }
        public DbSet<Order> orders { get; set; }
        
        public DbSet<Portfolio> portfolios { get; set; }
        public DbSet<Address> addresses { get; set; }



    }
}
