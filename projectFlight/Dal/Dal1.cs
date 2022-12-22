using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using projectFlight.Models;


namespace projectFlight.Dal
{
    public class Dal1:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("tblCustomers");
            modelBuilder.Entity<Country>().ToTable("tblCountry");
            modelBuilder.Entity<Flight>().ToTable("tblFlights");
            modelBuilder.Entity<Order>().ToTable("tblOrders");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<Flight> Flights { get; set; }

        public DbSet<Order> Orders { get; set; }


    }
}