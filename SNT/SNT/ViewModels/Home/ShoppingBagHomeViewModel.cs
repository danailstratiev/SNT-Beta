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
        public ShoppingBagHomeViewModel(HashSet<ShoppingBagTyre> tyres, 
            HashSet<ShoppingBagWheelRim> wheelRims, string userId)
        {
            this.Tyres = tyres;

            this.WheelRims = wheelRims;

            this.UserId = userId;
        }

        public string UserId { get; set; }

        public HashSet<ShoppingBagTyre> Tyres { get; set; }
        public HashSet<ShoppingBagWheelRim> WheelRims { get; set; }

        public decimal TotalSum { get => Sum(); }

        public decimal Sum()
        {
            var sum = 0m;

            foreach (var tyre in this.Tyres)
            {
                sum += tyre.Price;
            }

            foreach (var wheelRim in this.WheelRims)
            {
                sum += wheelRim.Price;
            }

            return sum;
        }
    }
}
