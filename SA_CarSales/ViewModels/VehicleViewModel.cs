using Microsoft.AspNetCore.Mvc.Rendering;
using SA_CarSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA_CarSales.ViewModels
{
    public class VehicleViewModel
    {
        public Guid Id { get; set; }


        public List<SelectListItem> VehicleTypes { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int NoOfDoors { get; set; }

        public int NoOfWheels { get; set; }
    }
}
