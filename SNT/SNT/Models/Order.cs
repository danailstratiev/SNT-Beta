using SNT.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class Order
    {
        public Order()
        {
            Tyres = new List<Tyre>();
            WheelRims = new List<WheelRim>();
        }

        public string Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime DeliveryDate => DateOfCreation.AddDays(7);

        public DeliveryDestination DeliveryDestination { get; set; }

        public string ClientId { get; set; }

        public SntUser Client { get; set; }

        public List<Tyre> Tyres { get; set; }

        public List<WheelRim> WheelRims{ get; set; }

        public OrderStage OrderStage { get; set; }
    }
}
