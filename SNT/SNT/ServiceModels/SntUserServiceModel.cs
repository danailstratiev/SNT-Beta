using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.ServiceModels
{
    public class SntUserServiceModel : IdentityUser
    {
        List<OrderServiceModel> Orders;
    }
}
