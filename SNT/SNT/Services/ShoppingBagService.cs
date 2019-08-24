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

        public async Task<bool> AddTyreToShoppingBag(string tyreId, string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return false;
            }

            var shoppingBagTyre = new ShoppingBagTyre
            {
                TyreId = tyreId,
                Tyre = this.context.Tyres.FirstOrDefault(x => x.Id == tyreId),
                Quantity = 1,
            };

            if (!user.ShoppingBag.Tyres.Any())
            {
                user.ShoppingBag.Tyres.Add(shoppingBagTyre);
            }
            else
            {
                var currentTyre = user.ShoppingBag.Tyres.FirstOrDefault(x => x.Id == shoppingBagTyre.Id);

                currentTyre.Quantity += 1;
            }


            return true;
        }
    }
}
