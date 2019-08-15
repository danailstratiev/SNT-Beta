using SNT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public interface IWheelRimService
    {
        Task<WheelRim> EditWheelRim(WheelRim wheelRim);

        Task<WheelRim> GetWheelRimById(string id);

        IQueryable<WheelRim> GetAllWheelRimsByPriceAscending();

        IQueryable<WheelRim> GetAllWheelRimsByPriceDescending();

        IQueryable<WheelRim> GetAllWheelRimsByBrand();

        IQueryable<WheelRim> GetAllAvailableWheelRims();

        IQueryable<WheelRim> GetAllUnavailableWheelRims();

        IQueryable<WheelRim> GetAllWheelRimsByPCD();

        IQueryable<WheelRim> GetAllWheelRimsByOffset();

        IQueryable<WheelRim> GetAllWheelRimsByMaterial();

        IQueryable<WheelRim> GetAllWheelRimsByCentralLukeDiameter();

    }
}
