using Microsoft.AspNetCore.Http;
using SNT.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.InputModels
{
    public class TyreCreateInputModel
    {
        public string Model { get; set; }

        public IFormFile Picture { get; set; }

        public string Brand { get; set; }

        public SeasonType Type { get; set; }

        public AvailabilityStatus Status { get; set; }

        public decimal Price { get; set; }

        public int Width { get; set; }

        public int Ratio { get; set; }

        public int Diameter { get; set; }

        public int YearOfProduction { get; set; }
    }
}
