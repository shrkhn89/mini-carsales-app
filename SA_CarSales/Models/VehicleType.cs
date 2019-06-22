using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SA_CarSales.Models
{
    public class VehicleType: IEntity
    {

        [Key]
        public Guid VehicleTypeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<VehicleSpecificationsMaster> VehicleSpecificationsMasters { get; set; }
    }
}
