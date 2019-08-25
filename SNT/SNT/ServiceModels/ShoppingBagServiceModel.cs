using AutoMapper;
using SNT.Models;
using SNT.Services.Mapping;
using SNT.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.ServiceModels
{
    public class ShoppingBagServiceModel : IMapFrom<ShoppingBagHomeViewModel>, IHaveCustomMappings
    {
        public string UserId { get; set; }

        public HashSet<ShoppingBagTyre> Tyres { get; set; }

        public HashSet<ShoppingBagWheelRim> WheelRims { get; set; }


        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<ShoppingBagServiceModel, ShoppingBagHomeViewModel>();
        }

    }
}
