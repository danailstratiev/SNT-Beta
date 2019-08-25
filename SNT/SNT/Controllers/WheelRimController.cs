using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SNT.Models;
using SNT.Services;
using SNT.Services.Mapping;
using SNT.ViewModels.Review;

namespace SNT.Controllers
{
    public class WheelRimBagInputModel : IMapFrom<WheelRimReviewViewModel>
    {
        public string WheelRimId { get; set; }

    }

    public class WheelRimController : Controller
    {
        private readonly IWheelRimService wheelRimService;
        private IShoppingBagService shoppingbagService;
        private readonly UserManager<SntUser> userManager;

        public WheelRimController(IWheelRimService wheelRimService, IShoppingBagService shoppingbagService,
            UserManager<SntUser> userManager)
        {
            this.wheelRimService = wheelRimService;
            this.shoppingbagService = shoppingbagService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet(Name = "Review")]
        public IActionResult Review(string id)
        {
            WheelRimReviewViewModel wheelRimReviewViewModel = this.wheelRimService.GetWheelRimById(id).To<WheelRimReviewViewModel>();

            return View(wheelRimReviewViewModel);
        }

        [HttpPost(Name = "AddToBag")]
        public async Task<IActionResult> AddToBag(WheelRimBagInputModel wheelRimBagInputModel)
        {
            string userId = this.userManager.GetUserId(this.HttpContext.User);

            await this.shoppingbagService.AddWheelRimToShoppingBag(wheelRimBagInputModel.WheelRimId, userId);

            return this.Redirect("/");
        }
    }
}