using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SA_CarSales.Models
{
    public class VehicleSpecifications : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Vehicle")]
        public Guid VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        [ForeignKey("Definition")]
        public Guid DefinitionId { get; set; }

        public VehicleSpecificationsMaster Definition { get; set; }


        public string Value { get; set; }
    }
}
