﻿using SNT.Data;
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

        public async Task<bool> AddTyreToShoppingBag(string tyreId, string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null || tyreId == null)
            {
                return false;
            }

            var currentTyre = context.ShoppingBagTyres.FirstOrDefault(x => x.UserId == user.Id && x.TyreId == tyreId);

            if (currentTyre != null)
            {
                return true;
            }

            var tyre = this.context.Tyres.SingleOrDefault(x => x.Id == tyreId);

            var shoppingBagTyre = new ShoppingBagTyre
            {
                UserId = user.Id,
                TyreId = tyreId,
                Model = tyre.Model,
                Brand = tyre.Brand,
                Price = tyre.Price,
                Picture = tyre.Picture,
                Quantity = 1,
            };

            this.context.ShoppingBagTyres.Add(shoppingBagTyre);

            await this.context.SaveChangesAsync();

            return true;
        }

        public ShoppingBagHomeViewModel GetAllCartProducts(string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);

            HashSet<ShoppingBagTyre> bagTyres = new HashSet<ShoppingBagTyre>();

            foreach (var tyre in this.context.ShoppingBagTyres.Where(x => x.UserId == user.Id))
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

            var products = this.context.ShoppingBagTyres.Where(x => x.UserId == userId);

            this.context.ShoppingBagTyres.RemoveRange(products);

            var result = await this.context.SaveChangesAsync();

            return result > 0;
        }

    }
}