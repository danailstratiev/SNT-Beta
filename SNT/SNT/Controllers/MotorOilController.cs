using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNT.Services;
using SNT.Services.Mapping;
using SNT.ViewModels.Review;

namespace SNT.Controllers
{
    public class MotorOilController : Controller
    {
        private IMotorOilService motorOilService;

        public MotorOilController(IMotorOilService motorOilService)
        {
            this.motorOilService = motorOilService;
        }


        [HttpGet(Name = "Review")]
        public IActionResult Review(string id)
        {
            MotorOilReviewViewModel motorOilReviewViewModel = this.motorOilService.GetMotorOilById(id).To<MotorOilReviewViewModel>();

            return View(motorOilReviewViewModel);
        }
    }
}