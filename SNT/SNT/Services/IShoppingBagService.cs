using SNT.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public interface IShoppingBagService
    {
        Task<bool> AddTyreToShoppingBag(string tyreId, string userId);

        Task<bool> AddWheelRimToShoppingBag(string wheelRimId, string userId);

        Task<bool> AddMotorOilToShoppingBag(string motorOilId, string userId);

        ShoppingBagHomeViewModel GetAllCartProducts(string userId);

        void RemoveAllShoppingBagProducts(string userId);


        void UpdateShoppingBagTyreQuantity(string bagTyreId, int quantity);

        void UpdateShoppingBagWheelRimQuantity(string bagWheelRimId, int quantity);

        void UpdateShoppingBagMotorOilQuantity(string motorOilId, int quantity);

        void RemoveTyreFromShoppingBag(string bagTyreId, string userId);

        void RemoveWheelRimFromShoppingBag(string bagWheelRimId, string userId);

        void RemoveMotorOilFromShoppingBag(string bagMotorOilId, string userId);
    }
}
