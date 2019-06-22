using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SA_CarSales.Models
{
    public class Vehicle :IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("VehicleType")]
        public Guid TypeId { get; set; }

        public VehicleType VehicleType { get; set; }
        
        public string Make { get; set; }

        public string Model { get; set; }

        public int NoOfDoors { get; set; }

        public int NoOfWheels { get; set; }

        public virtual ICollection<VehicleSpecifications> VehicleSpecifications { get; set; }

    }

   


}
