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
            this.MyReceipts = new List<SntReceipt>();
            this.Orders = new List<Order>();
        }

        public List<Order> Orders { get; set; }
        public List<SntReceipt> MyReceipts { get; set; }
    }
}
