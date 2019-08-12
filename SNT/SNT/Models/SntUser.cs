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

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public ShoppingBag ShoppingBag { get; set; }

        public List<SntReceipt> MyReceipts { get; set; }
    }
}
