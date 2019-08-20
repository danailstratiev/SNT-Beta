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
    public class TyreCreateInputModel : IMapTo<TyreServiceModel>, IHaveCustomMappings
    {
        [Required]
        public string Model { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public SeasonType Type { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public AvailabilityStatus Status { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public int Ratio { get; set; }

        [Required]
        public int Diameter { get; set; }

        [Required]
        public int YearOfProduction { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
               .CreateMap<TyreCreateInputModel, TyreServiceModel>();
        }
    }
}
