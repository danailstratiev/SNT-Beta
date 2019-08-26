using SNT.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public interface IOrderService
    {
        Task<bool> Create(OrderServiceModel orderServiceModel, string userId);
    }
}
