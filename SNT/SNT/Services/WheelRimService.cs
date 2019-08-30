using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SNT.Data;
using SNT.Models;
using SNT.ServiceModels;
using SNT.Services.Mapping;

namespace SNT.Services
{
    public class WheelRimService : IWheelRimService
    {
        private SntDbContext context;

        public WheelRimService(SntDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(WheelRimServiceModel wheelRimServiceModel)
        {
            WheelRim wheelRim = AutoMapper.Mapper.Map<WheelRim>(wheelRimServiceModel);

            context.WheelRims.Add(wheelRim);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public WheelRimServiceModel GetWheelRimById(string id)
        {
            return this.context.WheelRims.To<WheelRimServiceModel>().SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<WheelRimServiceModel> GetAllWheelRims()
        {
            return this.context.WheelRims.To<WheelRimServiceModel>();
        }

        public Task<WheelRim> EditWheelRim(WheelRim wheelRim)
        {
            throw new NotImplementedException();
        }

        public IQueryable<WheelRimServiceModel> GetAllAvailableWheelRims()
        {
            return this.context.WheelRims.Where(x => x.Status == Models.Enums.AvailabilityStatus.InStock).To<WheelRimServiceModel>();
        }

        public async Task<bool> EditWheelRim (WheelRimServiceModel wheelRimServiceModel)
        {
            var wheelRimFromDb = await this.context.WheelRims.SingleOrDefaultAsync(p => p.Id == wheelRimServiceModel.Id);

            AutoMapper.Mapper.Map(wheelRimServiceModel, wheelRimFromDb);

            this.context.WheelRims.Update(wheelRimFromDb);

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public IQueryable<WheelRim> GetAllUnavailableWheelRims()
        {
            throw new NotImplementedException();
        }

        public IQueryable<WheelRim> GetAllWheelRimsByBrand()
        {
            throw new NotImplementedException();
        }

        public IQueryable<WheelRim> GetAllWheelRimsByCentralLukeDiameter()
        {
            throw new NotImplementedException();
        }

        public IQueryable<WheelRim> GetAllWheelRimsByMaterial()
        {
            throw new NotImplementedException();
        }

        public IQueryable<WheelRim> GetAllWheelRimsByOffset()
        {
            throw new NotImplementedException();
        }

        public IQueryable<WheelRim> GetAllWheelRimsByPCD()
        {
            throw new NotImplementedException();
        }

        public IQueryable<WheelRim> GetAllWheelRimsByPriceAscending()
        {
            throw new NotImplementedException();
        }

        public IQueryable<WheelRim> GetAllWheelRimsByPriceDescending()
        {
            throw new NotImplementedException();
        }
    }
}
