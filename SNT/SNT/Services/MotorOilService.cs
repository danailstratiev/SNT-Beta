using Microsoft.EntityFrameworkCore;
using SNT.Data;
using SNT.Models;
using SNT.ServiceModels;
using SNT.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public class MotorOilService : IMotorOilService
    {
        private SntDbContext context;

        public MotorOilService(SntDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(MotorOilServiceModel motorOilServiceModel)
        {
            MotorOil motorOil = AutoMapper.Mapper.Map<MotorOil>(motorOilServiceModel);

            this.context.MotorOils.Add(motorOil);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public IQueryable<MotorOilServiceModel> GetAllAvailableOils()
        {
            return this.context.MotorOils.Where(x => x.Status == Models.Enums.AvailabilityStatus.InStock).To<MotorOilServiceModel>();
        }

        public IQueryable<MotorOilServiceModel> GetAllOils()
        {
            return this.context.MotorOils.To<MotorOilServiceModel>();
        }

        public MotorOilServiceModel GetMotorOilById(string id)
        {
            return this.context.MotorOils.To<MotorOilServiceModel>().SingleOrDefault(x => x.Id == id);
        }

        public async Task<bool> EditMotorOil(MotorOilServiceModel motorOilServiceModel)
        {
            var motorOilFromDb = await this.context.MotorOils.SingleOrDefaultAsync(p => p.Id == motorOilServiceModel.Id);

            AutoMapper.Mapper.Map(motorOilServiceModel, motorOilFromDb);

            this.context.MotorOils.Update(motorOilFromDb);

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }
    }
}
