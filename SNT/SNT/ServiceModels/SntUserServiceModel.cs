using Microsoft.AspNetCore.Identity;
using SNT.Models;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.ServiceModels
{
    public class SntUserServiceModel : IdentityUser, IMapFrom<SntUser>
    {
        ShoppingBagServiceModel ShoppingBag;

        List<OrderServiceModel> Orders;
    }
}
