using SNT.Models;
using SNT.Models.Enums;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.ServiceModels
{
    public class OrderServiceModel : IMapTo<Order>, IMapFrom<Order>
    {
        public string Id { get; set; }

        public DateTime DateOfCreation { get; set; }

        public DateTime DeliveryDate => DateOfCreation.AddDays(7);

        public DeliveryDestination DeliveryDestination { get; set; }

        public string ClientId { get; set; }

        public SntUserServiceModel Client { get; set; }

        public List<TyreServiceModel> Tyres { get; set; }

        public List<WheelRimServiceModel> WheelRims { get; set; }

        public OrderStage OrderStage { get; set; }
    }
}
