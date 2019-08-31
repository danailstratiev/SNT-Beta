using Microsoft.EntityFrameworkCore;
using SNT.Data;
using SNT.Models;
using SNT.ServiceModels;
using SNT.Services.Mapping;
using SNT.ViewModels.Edit;
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

        //public Task<TyreServiceModel> EditTyre(Tyre tyre)
        //{
        //    throw new NotImplementedException();
        //}

        public IQueryable<TyreServiceModel> GetAllAvailableTyres()
        {
            return this.context.Tyres.Where(x => x.Status == Models.Enums.AvailabilityStatus.InStock).
                To<TyreServiceModel>();
        }

        public IQueryable<TyreServiceModel> GetAllSummerTyres()
        {
            throw new NotImplementedException();
        }      

        
        public IQueryable<TyreServiceModel> GetAllTyres()
        {
            return this.context.Tyres.To<TyreServiceModel>();
        }
               

        public async Task<bool> MakeTyreOutOfStock(string id)
        {
            var tyre = this.context.Tyres.SingleOrDefault(x => x.Id == id);

            tyre.Status = Models.Enums.AvailabilityStatus.OutOfStock;

            this.context.Tyres.Update(tyre);

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> EditTyre (TyreServiceModel tyreServiceModel)
        {
            var tyreFromDb = await this.context.Tyres.SingleOrDefaultAsync(p => p.Id == tyreServiceModel.Id);

            AutoMapper.Mapper.Map(tyreServiceModel, tyreFromDb);

            this.context.Tyres.Update(tyreFromDb);

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }


        public TyreServiceModel GetTyreById(string id)
        {
            return this.context.Tyres.To<TyreServiceModel>().SingleOrDefault(x => x.Id == id);
        }
    }
}
