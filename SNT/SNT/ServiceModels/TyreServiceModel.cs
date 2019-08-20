using SNT.Models;
using SNT.Models.Enums;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.ServiceModels
{
    public class TyreServiceModel : IMapFrom<Tyre>, IMapTo<Tyre>
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public SeasonType Type { get; set; }

        public AvailabilityStatus Status { get; set; }

        public decimal Price { get; set; }

        public int Width { get; set; }

        public int Ratio { get; set; }

        public int Diameter { get; set; }

        public string Description { get; set; }

        public int YearOfProduction { get; set; }
    }
}
