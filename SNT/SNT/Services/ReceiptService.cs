using SNT.Data;
using SNT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public class ReceiptService
    {
        private SntDbContext context;
        private OrderService orderService;

        public ReceiptService(SntDbContext context, OrderService orderService)
        {
            this.context = context;
            this.orderService = orderService;
        }

        public async Task<bool> GenerateReceipt(string userId)
        {
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

            this.context.Update(orderFromDb);

            var result = this.context.SaveChangesAsync();

            return true;
        }
    }
}
