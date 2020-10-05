using System;
using System.Collections.Generic;
using System.Text;
using BikeServiceMenager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BikeServiceMenager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<ServiceOrder> ServiceOrders {get; set; }
        public DbSet<ServiceAction> ServiceActions { get; set; }
    }
}
