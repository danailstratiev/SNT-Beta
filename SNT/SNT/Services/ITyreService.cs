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

        Task<TyreServiceModel> EditTyre(Tyre tyre);

       TyreServiceModel GetTyreById(string id);

        IQueryable<TyreServiceModel> GetAllTyresByPriceAscending();

        IQueryable<TyreServiceModel> GetAllTyresByPriceDescending();

        IQueryable<TyreServiceModel> GetAllSummerTyres();

        IQueryable<TyreServiceModel> GetAllWinterTyres();

        IQueryable<TyreServiceModel> GetAllTyresByBrand();

        IQueryable<TyreServiceModel> GetAllTyresByWidth();

        IQueryable<TyreServiceModel> GetAllTyresByRatio();

        IQueryable<TyreServiceModel> GetAllTyresByDiameter();

        IQueryable<TyreServiceModel> GetAllAvailableTyres();

        IQueryable<TyreServiceModel> GetAllUnavailableTyres();
    }
}
