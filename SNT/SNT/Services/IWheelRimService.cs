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

        Task<WheelRim> EditWheelRim(WheelRim wheelRim);

        WheelRimServiceModel GetWheelRimById(string id);

        IQueryable<WheelRim> GetAllWheelRimsByPriceAscending();

        IQueryable<WheelRim> GetAllWheelRimsByPriceDescending();

        IQueryable<WheelRim> GetAllWheelRimsByBrand();

        IQueryable<WheelRim> GetAllAvailableWheelRims();

        IQueryable<WheelRimServiceModel> GetAllWheelRims();

        IQueryable<WheelRim> GetAllWheelRimsByPCD();

        IQueryable<WheelRim> GetAllWheelRimsByOffset();

        IQueryable<WheelRim> GetAllWheelRimsByMaterial();

        IQueryable<WheelRim> GetAllWheelRimsByCentralLukeDiameter();

    }
}
