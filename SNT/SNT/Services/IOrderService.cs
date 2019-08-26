using SNT.ServiceModels;
using SNT.ViewModels.Confirm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public interface IOrderService
    {
        OrderConfirmViewModel Create(OrderServiceModel orderServiceModel, string userId);

        OrderConfirmViewModel GetOrder(string userId);

    }
}
