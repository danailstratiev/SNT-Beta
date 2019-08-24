using SNT.Models;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.ServiceModels
{
    public class ShoppingBagServiceModel : IMapFrom<ShoppingBag>, IMapTo<ShoppingBag>
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public SntUser User { get; set; }

        public List<Tyre> Tyres { get; set; }

        public List<WheelRim> WheelRims { get; set; }
    }
}
