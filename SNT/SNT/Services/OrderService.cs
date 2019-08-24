using SNT.Data;
using SNT.Models;
using SNT.ServiceModels;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public class OrderService : IOrderService
    {
        private SntDbContext context;

        public OrderService(SntDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(OrderServiceModel orderServiceModel)
        {
            Order order = orderServiceModel.To<Order>();

            this.context.Orders.Add(order);
            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
