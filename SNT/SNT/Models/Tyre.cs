using SNT.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class Tyre
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public TyreType Type { get; set; }

        public AvailabilityStatus Status { get; set; }

        public decimal Price { get; set; }

        public int Width { get; set; }

        public int Ratio { get; set; }

        public int Diameter { get; set; }
    }
}
