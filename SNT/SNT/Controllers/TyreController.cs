using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SNT.Models;
using SNT.Services;
using SNT.Services.Mapping;
using SNT.ViewModels;

namespace SNT.Controllers
{
    public class TyreController : Controller
    {
        private ITyreService tyreService;
        private IShoppingBagService shoppingbagService;
        private IOrderService orderService;
        private readonly UserManager<SntUser> userManager;


        public TyreController(ITyreService tyreService, IOrderService orderService,
            UserManager<SntUser> userManager, IShoppingBagService shoppingbagService)
        {
            this.tyreService = tyreService;
            this.orderService = orderService;
            this.userManager = userManager;
            this.shoppingbagService = shoppingbagService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet(Name = "Review")]
        public IActionResult Review(string id)
        {
            TyreReviewViewModel tyreReviewViewModel = this.tyreService.GetTyreById(id).To<TyreReviewViewModel>();

            return View(tyreReviewViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToBag(TyreReviewViewModel tyreReviewViewModel, int quantity)
        {
            string userId = this.userManager.GetUserId(this.HttpContext.User);

            await this.shoppingbagService.AddTyreToShoppingBag(tyreReviewViewModel.Id, userId, quantity);

            return this.Redirect("/");
        }

    }
}