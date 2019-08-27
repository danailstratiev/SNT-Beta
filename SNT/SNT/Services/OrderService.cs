using SNT.Data;
using SNT.Models;
using SNT.ServiceModels;
using SNT.Services.Mapping;
using SNT.ViewModels;
using SNT.ViewModels.Confirm;
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

        public OrderConfirmViewModel Create(OrderServiceModel orderServiceModel, string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);

            Order order = new Order();
            Order orderFromInput = orderServiceModel.To<Order>();

            order.ClientName = orderFromInput.ClientName;
            order.DeliveryAddress = orderFromInput.DeliveryAddress;
            order.Comment = orderFromInput.Comment;
            order.ClientId = user.Id;
            order.Client = user;
            order.DateOfCreation = DateTime.UtcNow;
            order.OrderStage = Models.Enums.OrderStage.Active;

            HashSet<ShoppingBagTyre> bagTyres = new HashSet<ShoppingBagTyre>();

            var sum = 0m;

            foreach (var tyre in this.context.ShoppingBagTyres.Where(x => x.UserId == user.Id))
            {
                bagTyres.Add(tyre);
            }

            foreach (var tyre in bagTyres)
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

                sum += orderTyre.Price * orderTyre.Quantity;

                order.Tyres.Add(orderTyre);
                this.context.OrderTyres.Add(orderTyre);
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

                sum += orderWheelRim.Price * orderWheelRim.Quantity;
                
                order.WheelRims.Add(orderWheelRim);
                this.context.OrderWheelRims.Add(orderWheelRim);
            }

            order.Sum = sum;

            user.Orders.Add(order);

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            var orderConfirmViewModel = new OrderConfirmViewModel()
            {
                Id = order.Id,
                ClientName = order.ClientName,
                DeliveryAddress = order.DeliveryAddress,
                Comment = order.Comment,
                ClientId = order.ClientId,
                Client = order.Client,
                DateOfCreation = order.DateOfCreation                
            };

            orderConfirmViewModel.Tyres = order.Tyres;
            orderConfirmViewModel.WheelRims = order.WheelRims;

            return orderConfirmViewModel;
        }

        public OrderConfirmViewModel ReviewOrder(string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);

            var order = context.Orders.FirstOrDefault(x => x.OrderStage == Models.Enums.OrderStage.Active &&
            x.ClientId == userId);

            var orderConfirmViewModel = new OrderConfirmViewModel()
            {
                Id = order.Id,
                ClientName = order.ClientName,
                DeliveryAddress = order.DeliveryAddress,
                Comment = order.Comment,
                ClientId = order.ClientId,
                Client = order.Client,
                DateOfCreation = order.DateOfCreation,
                Sum = order.Sum
            };

            orderConfirmViewModel.Tyres = this.context.OrderTyres.Where(x => x.OrderId == order.Id).ToHashSet();
            orderConfirmViewModel.WheelRims = order.WheelRims;

            return orderConfirmViewModel;
        }

        public async Task<bool> CompleteOrder(string orderId)
        {
            var order = context.Orders.FirstOrDefault(x => x.OrderStage == Models.Enums.OrderStage.Active &&
            x.Id == orderId);

            order.OrderStage = Models.Enums.OrderStage.Complete;

            this.context.Orders.Update(order);

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteIncompleteOrders(string userId)
        {
            var incompleteOrders = this.context.Orders.Where(x => x.ClientId == userId &&
           x.OrderStage == Models.Enums.OrderStage.Active).ToList();

            for (int i = 0; i < incompleteOrders.Count; i++)
            {
                var idleTyres = this.context.OrderTyres.Where(x => x.OrderId == incompleteOrders[i].Id).ToList();
                this.context.OrderTyres.RemoveRange(idleTyres);

                var idleWheelRims = this.context.OrderWheelRims.Where(x => x.OrderId == incompleteOrders[i].Id).ToList();
                this.context.OrderWheelRims.RemoveRange(idleWheelRims);
            }

            this.context.Orders.RemoveRange(incompleteOrders);

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        //public async Task<bool> GetOrdersHistory(string userId)
        //{
        //    List<OrderCompleteViewModel> orderHistory = new List<OrderCompleteViewModel>();

        //    foreach (var order in this.context.Orders)
        //    {

        //    }
        //}

    }
}