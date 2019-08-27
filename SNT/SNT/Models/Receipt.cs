using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class Receipt
    {
        public Receipt()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string UserId { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }

        public string ClientName { get; set; }

        public string DeliveryAddress { get; set; }

        public string Comment { get; set; }
    }
}
