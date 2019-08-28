using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class MotorOilCreateInputModel : IMapTo<MotorOilServiceModel>, IHaveCustomMappings
    {
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Viscosity { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public IFormFile Picture { get; set; }
        [Required]
        public AvailabilityStatus Status { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<MotorOilCreateInputModel, MotorOilServiceModel>();
        }
    }
}
