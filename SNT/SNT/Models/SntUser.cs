using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class SntUser : IdentityUser
    {
        public SntUser()
        {
            this.MyReceipts = new List<Receipt>();
            this.Orders = new List<Order>();
            this.ShoppingBag = new ShoppingBag();
        }

        public ShoppingBag ShoppingBag { get; set; }
        public List<Order> Orders { get; set; }
        public List<Receipt> MyReceipts { get; set; }
    }
}
