using SNT.Data;
using SNT.Models;
using SNT.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public class ShoppingBagService : IShoppingBagService
    {
        private SntDbContext context;

        public ShoppingBagService(SntDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddTyreToShoppingBag(string tyreId, string userId, int quantity)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);
            bool validQuantity = quantity > 0 ;

            if (user == null || tyreId == null || validQuantity == false)
            {
                return false;
            }

            var currentTyre = context.ShoppingBagTyres.FirstOrDefault(x => x.ShoppingBagId == user.ShoppingBag.Id && x.TyreId == tyreId);

            if (currentTyre != null)
            {
                context.ShoppingBagTyres.FirstOrDefault(x => x.ShoppingBagId == user.ShoppingBag.Id && x.TyreId == tyreId)
                    .Quantity += quantity;

                var result = await this.context.SaveChangesAsync();

                return result > 0;
            }

            var tyre = this.context.Tyres.SingleOrDefault(x => x.Id == tyreId);

            var shoppingBagTyre = new ShoppingBagTyre
            {
                ShoppingBagId = user.ShoppingBag.Id,
                TyreId = tyreId,
                Tyre = tyre,
                Quantity = quantity,
            };

            await this.context.SaveChangesAsync();
            
            return true;
        }

        public ShoppingBagHomeViewModel GetAllCartProducts(string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);

            List<ShoppingBagTyre> bagTyres = new List<ShoppingBagTyre>();

            foreach (var tyre in this.context.ShoppingBagTyres.Where(x => x.ShoppingBagId == user.ShoppingBag.Id))
            {
                bagTyres.Add(tyre);
            }

            return new ShoppingBagHomeViewModel(bagTyres);
        }

        //public async Task<bool> RemoveTyreFromShoppingBag(string tyreId, string userId)

        public async Task<bool> RemoveAllShoppingBagProducts(string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return false;
            }

            var shoppingBagId = user.ShoppingBag.Id;

            var products = this.context.ShoppingBagTyres.Where(x => x.ShoppingBagId == shoppingBagId);

            this.context.ShoppingBagTyres.RemoveRange(products);

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

    }
}
