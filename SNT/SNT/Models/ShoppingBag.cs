using SNT.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class ShoppingBag
    {
        public List<IProduct> Products { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
