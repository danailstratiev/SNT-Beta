using AutoMapper;
using SNT.Models.Enums;
using SNT.ServiceModels;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.InputModels
{
    public class WheelRimCreateInputModel : IMapTo<WheelRimServiceModel>, IHaveCustomMappings
    {
        [Required]
        public string Model { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public AvailabilityStatus Status { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public string PCD { get; set; }

        [Required]
        public double CentralLukeDiameter { get; set; }

        [Required]
        public int Offset { get; set; }

        [Required]
        public string Material { get; set; }

        [Required]
        public int YearOfProduction { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<WheelRimCreateInputModel, WheelRimServiceModel>();
        }
    }
}
