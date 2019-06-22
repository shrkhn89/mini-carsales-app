using Microsoft.EntityFrameworkCore;
using SA_CarSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA_CarSales.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        public DbSet<VehicleSpecificationsMaster> VehicleSpecificationsMaster { get; set; }

        public DbSet<VehicleSpecifications> VehicleSpecifications { get; set; }

    }
}
