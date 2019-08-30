using SNT.Models;
using SNT.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public interface IWheelRimService
    {
        Task<bool> Create(WheelRimServiceModel wheelRimServiceModel);

        Task<bool> EditWheelRim(WheelRimServiceModel wheelRimServiceModel);

        WheelRimServiceModel GetWheelRimById(string id);

        IQueryable<WheelRimServiceModel> GetAllAvailableWheelRims();

        IQueryable<WheelRimServiceModel> GetAllWheelRims();

        IQueryable<WheelRim> GetAllWheelRimsByPriceAscending();

        IQueryable<WheelRim> GetAllWheelRimsByPriceDescending();

        IQueryable<WheelRim> GetAllWheelRimsByBrand();



        IQueryable<WheelRim> GetAllWheelRimsByPCD();

        IQueryable<WheelRim> GetAllWheelRimsByOffset();

        IQueryable<WheelRim> GetAllWheelRimsByMaterial();

        IQueryable<WheelRim> GetAllWheelRimsByCentralLukeDiameter();

    }
}
