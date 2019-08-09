using SNT.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class ShoppingBag
    {
        public string Id { get; set; }

        public List<Tyre> Tyres { get; set; }
        public List<WheelRim> WheelRims { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
