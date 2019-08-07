using SNT.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models.Interfaces
{
    public interface IProduct
    {
       string Model { get; set; }

       string Brand { get; set; }

       decimal Price { get; set; }

       AvailabilityStatus Status { get; set; }

        string Description { get; set; }

    }
}
