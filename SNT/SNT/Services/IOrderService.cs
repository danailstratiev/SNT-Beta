using SNT.ServiceModels;
using SNT.ViewModels.Confirm;
using SNT.ViewModels.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public interface IOrderService
    {
        OrderConfirmViewModel Create(OrderServiceModel orderServiceModel, string userId);

        OrderConfirmViewModel ReviewOrder(string userId);

        void CompleteOrder(string orderId);

        Task<bool> DeleteIncompleteOrders(string userId);

        List<OrderServiceModel> GetOrdersHistory(string userId);

        OrderReviewViewModel GetOrderReview(string orderId);
    }
}
