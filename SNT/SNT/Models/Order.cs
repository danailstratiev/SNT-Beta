using SNT.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class Order
    {
        public string Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DeliveryDestination DeliveryDestination { get; set; }
    }
}
