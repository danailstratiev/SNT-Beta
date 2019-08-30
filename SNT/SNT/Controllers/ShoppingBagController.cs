using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SNT.Data;
using SNT.Models;
using SNT.Services;

namespace SNT.Controllers
{
    public class ShoppingBagController : Controller
    {
        private readonly UserManager<SntUser> userManager;
        private IShoppingBagService shoppingbagService;
        private SntDbContext context;

        public ShoppingBagController(UserManager<SntUser> userManager, IShoppingBagService shoppingbagService,
            SntDbContext context)
        {
            this.userManager = userManager;
            this.shoppingbagService = shoppingbagService;
            this.context = context;
        }
        [HttpGet("/Shoppingbag/Index")]
        public IActionResult Index()
        {
            string userId = this.userManager.GetUserId(this.HttpContext.User);

            var shoppingBagHomeViewModel = this.shoppingbagService.GetAllCartProducts(userId);
            shoppingBagHomeViewModel.Sum();
            //ToDo Refactor this
            //TyreServiceModel tyreServiceModel = AutoMapper.Mapper.Map<TyreServiceModel>(tyreCreateInputModel);
            
            return View(shoppingBagHomeViewModel);
        }

        [HttpPost]
        //[Route("/Shoppingbag/Index")]
        public IActionResult EditTyreQuantity(string bagTyreId,int quantity)
        {

            this.shoppingbagService.UpdateShoppingBagTyreQuantity( bagTyreId, quantity);

            return RedirectToAction("Index");
        }

        public IActionResult EditWheelRimQuantity(string bagWheelRimId,int quantity)
        {

            this.shoppingbagService.UpdateShoppingBagWheelRimQuantity(bagWheelRimId, quantity);

            return RedirectToAction("Index");
        }

        public IActionResult EditMotorOilQuantity(string motorOilId, int quantity)
        {

            this.shoppingbagService.UpdateShoppingBagMotorOilQuantity(motorOilId, quantity);

            return RedirectToAction("Index");
        }

        public IActionResult CalculateTotalPrice(string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult RemoveTyre(string bagTyreId)
        {
            string userId = this.userManager.GetUserId(this.HttpContext.User);

            this.shoppingbagService.RemoveTyreFromShoppingBag(bagTyreId, userId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveWheelRim(string bagWheelRimId)
        {
            string userId = this.userManager.GetUserId(this.HttpContext.User);

            this.shoppingbagService.RemoveWheelRimFromShoppingBag(bagWheelRimId, userId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveMotorOil(string bagMotorOilId)
        {
            string userId = this.userManager.GetUserId(this.HttpContext.User);

            this.shoppingbagService.RemoveMotorOilFromShoppingBag(bagMotorOilId, userId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearShoppingBag()
        {
            string userId = this.userManager.GetUserId(this.HttpContext.User);

            this.shoppingbagService.RemoveAllShoppingBagProducts(userId);

            return RedirectToAction("Index");
        }

        
    }
}