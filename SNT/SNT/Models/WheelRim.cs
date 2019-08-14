using SNT.Models.Enums;
using SNT.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Models
{
    public class WheelRim : IProduct
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public AvailabilityStatus Status { get; set; }
                
        public decimal Price { get; set; }

        //Междуболтово разстояние (PCD)
        public string PCD { get; set; }

        //Централен отвор
        public double CentralLukeDiameter { get; set; }

        //Офсет (ЕТ)
        public int Offset { get; set; }

        public string Material { get; set; }

        public string Description { get; set; }
    }
}
