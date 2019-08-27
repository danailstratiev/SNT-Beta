using SNT.Data;
using SNT.Models;
using SNT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public class ReceiptService : IReceiptService
    {
        private SntDbContext context;
        //private OrderService orderService;

        public ReceiptService(SntDbContext context)
        {
            this.context = context;
            //this.orderService = orderService;
        }

        public async Task<bool> GenerateReceipt(string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);
            
            var orderFromDb = this.context.Orders.FirstOrDefault(x => x.ClientId == userId && x.OrderStage == Models.Enums.OrderStage.Active);

            Receipt receipt = new Receipt()
            {
                OrderId = orderFromDb.Id,
                UserId = orderFromDb.ClientId,
                Fee = orderFromDb.Sum,
                ClientName = orderFromDb.ClientName,
                DateOfIssue = orderFromDb.DateOfCreation,
                DeliveryAddress = orderFromDb.DeliveryAddress,
                Comment = orderFromDb.Comment,
                Order = orderFromDb
            };

            await this.context.Receipts.AddAsync(receipt);
            orderFromDb.OrderStage = Models.Enums.OrderStage.Complete;
            user.MyReceipts.Add(receipt);

            this.context.Update(orderFromDb);

            var result = this.context.SaveChangesAsync();

            return true;
        }

        public ReceiptDetailsViewModel GetReceiptDetails(string orderId)
        {
            var receiptFromDb = this.context.Receipts.FirstOrDefault(x => x.OrderId == orderId);

            var receiptDetailsViewModel = new ReceiptDetailsViewModel()
            {
                OrderId = receiptFromDb.Id,
                UserId = receiptFromDb.UserId,
                Fee = receiptFromDb.Fee,
                ClientName = receiptFromDb.ClientName,
                DateOfIssue = receiptFromDb.DateOfIssue,
                DeliveryAddress = receiptFromDb.DeliveryAddress,
                Comment = receiptFromDb.Comment,
                Order = receiptFromDb.Order
            };

            return receiptDetailsViewModel;
        }
    }
}
