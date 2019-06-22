using SA_CarSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA_CarSales.Data
{
    public class CarSalesSeedData
    {

        private ApplicationDbContext _context;
        public CarSalesSeedData(ApplicationDbContext context)
        {
            this._context = context;

        }
        public void DevEnvSeedData()
        {
            SetupCarVehicleType();            
            _context.SaveChanges();
        }

        private void SetupCarVehicleType()
        {
            if (!_context.VehicleTypes.Any())
            {
                var seedVehicleType = new VehicleType();
                seedVehicleType.VehicleTypeId = Guid.NewGuid();
                seedVehicleType.Name = "Car";
                seedVehicleType.VehicleSpecificationsMasters = new List<VehicleSpecificationsMaster>() {
                new VehicleSpecificationsMaster
                {

                    Id = Guid.NewGuid(),
                    Definitions = "CarVariant",
                    LstVehicleSpecifications = new List<VehicleSpecifications>() {
                new VehicleSpecifications
                {
                    Id = Guid.NewGuid(),
                    Value = "Sedan"
                },
                new VehicleSpecifications
                {
                    Id = Guid.NewGuid(),
                    Value = "SUV"
                },
                new VehicleSpecifications
                {
                    Id = Guid.NewGuid(),
                    Value = "Hatchback"
                }
                    }

            }


        };

                _context.VehicleTypes.Add(seedVehicleType);
                _context.VehicleSpecificationsMaster.Add(seedVehicleType.VehicleSpecificationsMasters.FirstOrDefault());
                
                foreach (var specs in seedVehicleType.VehicleSpecificationsMasters)
                {
                    foreach(var sp in specs.LstVehicleSpecifications)
                    {
                        _context.VehicleSpecifications.Add(sp);
                       
                    }
                }
                //seedVehicleType.VehicleSpecificationsMasters =  _context.VehicleSpecificationsMaster.ToList();
                _context.SaveChanges();

            }
        }



    }
}
