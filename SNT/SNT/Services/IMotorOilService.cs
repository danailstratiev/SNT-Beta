using SNT.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public interface IMotorOilService
    {
        Task<bool> Create(MotorOilServiceModel motorOilServiceModel);

        Task<bool> EditMotorOil(MotorOilServiceModel motorOilServiceModel);

        IQueryable<MotorOilServiceModel> GetAllAvailableOils();

        IQueryable<MotorOilServiceModel> GetAllOils();

        MotorOilServiceModel GetMotorOilById(string id);
    }
}
