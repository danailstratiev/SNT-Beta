using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class OrderTyre
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string TyreId { get; set; }
        public int Quantity { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
    }
}
