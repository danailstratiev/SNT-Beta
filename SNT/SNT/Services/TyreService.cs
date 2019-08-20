using SNT.Data;
using SNT.Models;
using SNT.ServiceModels;
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
        
        public async Task<bool> Create(TyreServiceModel tyreServiceModel)
        {            
            Tyre tyre = AutoMapper.Mapper.Map<Tyre>(tyreServiceModel);

            context.Tyres.Add(tyre);
            int result = await context.SaveChangesAsync();

            return result > 0;
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
