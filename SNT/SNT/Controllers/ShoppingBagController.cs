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

        public IActionResult Index()
        {
            string userId = this.userManager.GetUserId(this.HttpContext.User);

            var shoppingBagHomeViewModel = this.shoppingbagService.GetAllCartProducts(userId);
            return View(shoppingBagHomeViewModel);
        }

        public IActionResult EditShoppingBagQuantity(string id)
        {
            return View();
        }

    }
}