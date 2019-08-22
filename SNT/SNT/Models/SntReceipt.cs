using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class SntReceipt
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string UserId { get; set; }

        public SntUser User { get; set; }

        //public string ShoppingBagId { get; set; }

        //public ShoppingBag ShoppingBag { get; set; }
    }
}
