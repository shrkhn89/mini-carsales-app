using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SA_CarSales.Models
{
    public class VehicleSpecificationsMaster : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        //[ForeignKey("VehicleType")]
        //public Guid TypeId { get; set; }

        public VehicleType VehicleType { get; set; }

        public string Definitions { get; set; }

        public virtual ICollection<VehicleSpecifications> LstVehicleSpecifications { get; set; }

    }
}
