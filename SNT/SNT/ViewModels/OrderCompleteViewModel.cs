using SNT.Models;
using SNT.Models.Enums;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.ViewModels
{
    public class OrderCompleteViewModel : IMapFrom<Order>
    {
        public string Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime DeliveryDate => DateOfCreation.AddDays(7);

        public string DeliveryAddress { get; set; }

        public string ClientName { get; set; }

        public string ClientId { get; set; }

        public SntUser Client { get; set; }

        public HashSet<OrderTyre> Tyres { get; set; }

        public HashSet<OrderWheelRim> WheelRims { get; set; }

        public OrderStage OrderStage { get; set; }

        public string Comment { get; set; }

        public decimal Sum { get; set; }
    }
}
