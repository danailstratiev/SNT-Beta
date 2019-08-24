using SNT.Data;
using SNT.Models;
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

            if (user == null)
            {
                return false;
            }

            var shoppingBagTyre = new ShoppingBagTyre
            {
                ShoppingBagId = user.ShoppingBag.Id,
                TyreId = tyreId,
                Tyre = this.context.Tyres.FirstOrDefault(x => x.Id == tyreId),
                Quantity = quantity,
            };

            var currentTyre = context.ShoppingBagTyres.FirstOrDefault(x => x.ShoppingBagId == user.ShoppingBag.Id && x.TyreId == shoppingBagTyre.TyreId);
            
            if (currentTyre == null)
            {
                context.ShoppingBagTyres.Add(shoppingBagTyre);
            }
            else
            {
                currentTyre.Quantity += shoppingBagTyre.Quantity;
            }

            await this.context.SaveChangesAsync();
            
            return true;
        }
    }
}
