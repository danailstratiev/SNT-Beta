using SNT.Models;
using SNT.Models.Enums;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.ServiceModels
{
    public class WheelRimServiceModel : IMapFrom<WheelRim>, IMapTo<WheelRim>
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public AvailabilityStatus Status { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string PCD { get; set; }

        public double CentralLukeDiameter { get; set; }

        public int Offset { get; set; }

        public string Material { get; set; }

        public int YearOfProduction { get; set; }

        public string Description { get; set; }
    }
}
