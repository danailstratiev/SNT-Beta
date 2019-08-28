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

        Task<bool> MakeTyreOutOfStock(string id);

        IQueryable<TyreServiceModel> GetAllTyres();


        IQueryable<TyreServiceModel> GetAllAvailableTyres();

    }
}
