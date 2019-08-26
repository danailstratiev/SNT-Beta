using AutoMapper;
using SNT.Models;
using SNT.Models.Enums;
using SNT.ServiceModels;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.InputModels
{
    public class OrderCreateInputModel : IMapTo<OrderServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }
                
        public string ClientName { get; set; }

        public string DeliveryAddress { get; set; }              
               
        public string Comment { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<OrderCreateInputModel, OrderServiceModel>();
        }
    }
}
