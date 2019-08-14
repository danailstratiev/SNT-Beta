using SNT.Data;
using SNT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public class TyreService
    {
        private SntDbContext context;

        public TyreService(SntDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(Tyre newTyre)
        {
            var foundtyre = this.context.Tyres.FirstOrDefault(x => x.Id == newTyre.Id);

            if (foundtyre == null)
            {
                var tyre = new Tyre
                {
                    Brand = newTyre.Brand,
                    Model = newTyre.Model,
                    Type = newTyre.Type,
                    Status = newTyre.Status,
                    Price = newTyre.Price,
                    Width = newTyre.Width,
                    Ratio = newTyre.Ratio,
                    Diameter = newTyre.Diameter,
                    Description = newTyre.Description,
                    YearOfProduction = newTyre.YearOfProduction,
                    Quantity = newTyre.Quantity
                };
            }
            else
            {
                foundtyre.Quantity += newTyre.Quantity;

                if (foundtyre.Quantity > 0)
                {
                    foundtyre.Status = Models.Enums.AvailabilityStatus.InStock;
                }
            }

            context.SaveChangesAsync();

            return true;
        }
    }
}
