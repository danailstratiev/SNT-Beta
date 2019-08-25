using SNT.Models;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.ViewModels.Home
{
    public class ShoppingBagHomeViewModel
    {
        public ShoppingBagHomeViewModel(HashSet<ShoppingBagTyre> tyres)
        {
            this.Tyres = tyres;
        }

        public HashSet<ShoppingBagTyre> Tyres { get; set; }
        public HashSet<ShoppingBagWheelRim> WheelRims { get; set; }
    }
}
