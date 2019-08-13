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
            this.ShoppingBag = new ShoppingBag();
            this.MyReceipts = new List<SntReceipt>();
        }

        public string ShoppingBagId { get; set; }

        public ShoppingBag ShoppingBag { get; set; }

        public List<SntReceipt> MyReceipts { get; set; }
    }
}
