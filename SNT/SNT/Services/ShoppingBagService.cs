using SNT.Data;
using SNT.Models;
using SNT.ServiceModels;
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

        public async Task<bool> AddMotorOilToShoppingBag(string motorOilId, string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null || motorOilId == null)
            {
                return false;
            }

            var currentMotorOil = context.ShoppingBagMotorOils.FirstOrDefault(x => x.UserId == user.Id && x.MotorOilId == motorOilId);

            if (currentMotorOil != null)
            {
                return true;
            }

            var motorOil = this.context.MotorOils.SingleOrDefault(x => x.Id == motorOilId);

            var shoppingMotorOil = new ShoppingBagMotorOil
            {
                UserId = user.Id,
                MotorOilId = motorOil.Id,
                Model = motorOil.Model,
                Brand = motorOil.Brand,
                Price = motorOil.Price,
                Picture = motorOil.Picture,
                Quantity = 1,
            };

            this.context.ShoppingBagMotorOils.Add(shoppingMotorOil);

            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddWheelRimToShoppingBag(string wheelRimId, string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);
            
            if (user == null || wheelRimId == null)
            {
                return false;
            }

            var currentTyre = context.ShoppingBagWheelRims.FirstOrDefault(x => x.UserId == user.Id && x.WheelRimId == wheelRimId);

            if (currentTyre != null)
            {
                return true;
            }

            var wheelRim = this.context.WheelRims.SingleOrDefault(x => x.Id == wheelRimId);

            var shoppingBagWheelRim = new ShoppingBagWheelRim
            {
                UserId = user.Id,
                WheelRimId = wheelRimId,
                Model = wheelRim.Model,
                Brand = wheelRim.Brand,
                Price = wheelRim.Price,
                Picture = wheelRim.Picture,
                Quantity = 1,
            };

            this.context.ShoppingBagWheelRims.Add(shoppingBagWheelRim);

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

            HashSet<ShoppingBagWheelRim> bagWheelRims = new HashSet<ShoppingBagWheelRim>();

            foreach (var wheelRim in this.context.ShoppingBagWheelRims.Where(x => x.UserId == user.Id))
            {
                bagWheelRims.Add(wheelRim);
            }

            HashSet<ShoppingBagMotorOil> bagMotorOils = new HashSet<ShoppingBagMotorOil>();

            foreach (var motorOil in this.context.ShoppingBagMotorOils.Where(x => x.UserId == user.Id))
            {
                bagMotorOils.Add(motorOil);
            }

            user.ShoppingBag.Tyres = bagTyres;
            user.ShoppingBag.WheelRims = bagWheelRims;
            user.ShoppingBag.MotorOils = bagMotorOils;

            this.context.ShoppingBag.Update(user.ShoppingBag);
            this.context.SaveChangesAsync();

            return new ShoppingBagHomeViewModel(bagTyres, bagWheelRims, bagMotorOils, user.Id);
        }

        public void RemoveTyreFromShoppingBag(string bagTyreId, string userId)
        {
            var bagTyre = this.context.ShoppingBagTyres.FirstOrDefault(x => x.Id == bagTyreId && x.UserId == userId);

            this.context.ShoppingBagTyres.Remove(bagTyre);

            this.context.SaveChanges();
        }

        public void RemoveWheelRimFromShoppingBag(string bagWheelRimId, string userId)
        {
            var bagWheelRim = this.context.ShoppingBagWheelRims.FirstOrDefault(x => x.Id == bagWheelRimId && x.UserId == userId);

            this.context.ShoppingBagWheelRims.Remove(bagWheelRim);

            this.context.SaveChanges();

        }

        public void RemoveMotorOilFromShoppingBag(string bagMotorOilId, string userId)
        {
            var bagMotorOil = this.context.ShoppingBagMotorOils.FirstOrDefault(x => x.Id == bagMotorOilId && x.UserId == userId);

            this.context.ShoppingBagMotorOils.Remove(bagMotorOil);

             this.context.SaveChanges();
        }

        public void RemoveAllShoppingBagProducts(string userId)
        {
            var user = this.context.Users.FirstOrDefault(x => x.Id == userId);

            var bagTyres = this.context.ShoppingBagTyres.Where(x => x.UserId == userId);
            var bagWheelRims = this.context.ShoppingBagWheelRims.Where(x => x.UserId == userId);
            var bagMotorOils = this.context.ShoppingBagMotorOils.Where(x => x.UserId == userId);

            this.context.ShoppingBagTyres.RemoveRange(bagTyres);
            this.context.ShoppingBagWheelRims.RemoveRange(bagWheelRims);
            this.context.ShoppingBagMotorOils.RemoveRange(bagMotorOils);

          this.context.SaveChanges();
        }

        public void UpdateShoppingBagTyreQuantity (string bagTyreId,int quantity)
        {
            var tyreFromDb = this.context.ShoppingBagTyres.FirstOrDefault(x => x.Id == bagTyreId);

            tyreFromDb.Quantity = quantity;

            this.context.Update(tyreFromDb);

            this.context.SaveChanges();
        }

        public void UpdateShoppingBagWheelRimQuantity (string bagWheelRimId,int quantity)
        {
            var wheelRimFromDb = this.context.ShoppingBagWheelRims.FirstOrDefault(x => x.Id == bagWheelRimId);

            wheelRimFromDb.Quantity = quantity;

            this.context.Update(wheelRimFromDb);

            this.context.SaveChanges();
        }

        public void UpdateShoppingBagMotorOilQuantity (string motorOilId, int quantity)
        {
            var motorOilFromDb = this.context.ShoppingBagMotorOils.FirstOrDefault(x => x.Id == motorOilId);

            motorOilFromDb.Quantity = quantity;

            this.context.Update(motorOilFromDb);

            this.context.SaveChanges();
        }

        public Task<ShoppingBagServiceModel> AddTyreToShoppingBag()
        {
            throw new NotImplementedException();
        }
    }
}
