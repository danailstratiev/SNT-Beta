﻿using SNT.Models.Enums;
using SNT.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class MotorOil : IProduct
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }      

        public string Viscosity { get; set; }

        public int Volume { get; set; }

        public string Type { get; set; }

        public AvailabilityStatus Status { get; set; }

        public string Description { get; set; }
    }
}
