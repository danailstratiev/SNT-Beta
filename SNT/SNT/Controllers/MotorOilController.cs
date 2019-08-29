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
    public class MotorOilInputModel : IMapFrom<MotorOilReviewViewModel>
    {
        public string TyreId { get; set; }

    }
    public class MotorOilController : Controller
    {
        private IMotorOilService motorOilService;
        private IShoppingBagService shoppingbagService;
        private readonly UserManager<SntUser> userManager;

        public MotorOilController(IMotorOilService motorOilService, IShoppingBagService shoppingbagService,
            UserManager<SntUser> userManager)
        {
            this.motorOilService = motorOilService;
            this.shoppingbagService = shoppingbagService;
            this.userManager = userManager;
        }

        [HttpGet(Name = "Review")]
        public IActionResult Review(string id)
        {
            MotorOilReviewViewModel motorOilReviewViewModel = this.motorOilService.GetMotorOilById(id).To<MotorOilReviewViewModel>();

            return View(motorOilReviewViewModel);
        }


        [HttpPost(Name = "AddToBag")]
        public async Task<IActionResult> AddToBag(MotorOilInputModel tyreBagInputModel)
        {
            string userId = this.userManager.GetUserId(this.HttpContext.User);

            await this.shoppingbagService.AddTyreToShoppingBag(tyreBagInputModel.TyreId, userId);

            return this.Redirect("/");
        }
    }
}