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

        IQueryable<MotorOilServiceModel> GetAllAvailableOils();

        MotorOilServiceModel GetMotorOilById(string id);
    }
}
