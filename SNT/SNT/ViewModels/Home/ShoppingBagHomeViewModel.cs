using SNT.Models;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.ViewModels.Home
{
    public class ShoppingBagHomeViewModel : IMapFrom<ShoppingBag>, IMapTo<ShoppingBag>
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public SntUser User { get; set; }

        public List<ShoppingBagTyre> Tyres { get; set; }
    }
}
