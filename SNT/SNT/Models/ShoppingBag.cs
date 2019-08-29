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
            this.Id = Guid.NewGuid().ToString();
            this.Tyres = new HashSet<ShoppingBagTyre>();
            this.WheelRims = new HashSet<ShoppingBagWheelRim>();
            this.MotorOils = new HashSet<ShoppingBagMotorOil>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public SntUser User { get; set; }

        public HashSet<ShoppingBagTyre> Tyres { get; set; }

        public HashSet<ShoppingBagWheelRim> WheelRims { get; set; }

        public HashSet<ShoppingBagMotorOil> MotorOils { get; set; }

    }
}
