using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class ShoppingBagTyre
    {
        public string Id { get; set; }

        public string TyreId { get; set; }

        public Tyre Tyre { get; set; }

        public int Quantity { get; set; }
    }
}
