using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class ShoppingBag
    {
        public ShoppingBag()
        {
            this.Tyres = new List<ShoppingBagTyre>();
            //WheelRims = new List<WheelRim>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public SntUser User { get; set; }

        public List<ShoppingBagTyre> Tyres { get; set; }

        //public List<WheelRim> WheelRims { get; set; }

    }
}
