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

        public async Task<bool> Create(OrderServiceModel orderServiceModel,string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);

            Order order = orderServiceModel.To<Order>();

            order.ClientId = user.Id;
            order.Client = user;
            order.DateOfCreation = DateTime.UtcNow;
            order.OrderStage = Models.Enums.OrderStage.Accepted;

            foreach (var tyre in user.ShoppingBag.Tyres)
            {
                var orderTyre = new OrderTyre()
                {
                    OrderId = order.Id,
                    UserId = user.Id,
                    TyreId = tyre.TyreId,
                    Model = tyre.Model,
                    Brand = tyre.Brand,
                    Price = tyre.Price,
                    Quantity = tyre.Quantity
                };

                order.Tyres.Add(orderTyre);
            }

            foreach (var wheelRim in user.ShoppingBag.WheelRims)
            {
                var orderWheelRim = new OrderWheelRim()
                {
                    OrderId = order.Id,
                    UserId = user.Id,
                    WheelRimId = wheelRim.WheelRimId,
                    Model = wheelRim.Model,
                    Brand = wheelRim.Brand,
                    Price = wheelRim.Price,
                    Quantity = wheelRim.Quantity
                };

                order.WheelRims.Add(orderWheelRim);
            }

            user.Orders.Add(order);

            this.context.Orders.Add(order);
            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
