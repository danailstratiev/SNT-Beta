using SNT.Models;
using SNT.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public interface ITyreService
    {
        Task<bool> Create(TyreServiceModel tyreServiceModel);

        Task<Tyre> EditTyre(Tyre tyre);

        Task<Tyre> GetTyreById(string id);

        IQueryable<Tyre> GetAllTyresByPriceAscending();

        IQueryable<Tyre> GetAllTyresByPriceDescending();

        IQueryable<Tyre> GetAllSummerTyres();

        IQueryable<Tyre> GetAllWinterTyres();

        IQueryable<Tyre> GetAllTyresByBrand();

        IQueryable<Tyre> GetAllTyresByWidth();

        IQueryable<Tyre> GetAllTyresByRatio();

        IQueryable<Tyre> GetAllTyresByDiameter();

        IQueryable<Tyre> GetAllAvailableTyres();

        IQueryable<Tyre> GetAllUnavailableTyres();



    }
}
