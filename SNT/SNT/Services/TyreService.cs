using SNT.Data;
using SNT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public class TyreService : ITyreService
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
                };
            }
            else
            {
              
            }

            await context.SaveChangesAsync();

            return true;
        }

        public Task<Tyre> EditTyre(Tyre tyre)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tyre> GetAllAvailableTyres()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tyre> GetAllSummerTyres()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tyre> GetAllTyresByBrand()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tyre> GetAllTyresByDiameter()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tyre> GetAllTyresByPriceAscending()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tyre> GetAllTyresByPriceDescending()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tyre> GetAllTyresByRatio()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tyre> GetAllTyresByWidth()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tyre> GetAllUnavailableTyres()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tyre> GetAllWinterTyres()
        {
            throw new NotImplementedException();
        }

        public Task<Tyre> GetTyreById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
