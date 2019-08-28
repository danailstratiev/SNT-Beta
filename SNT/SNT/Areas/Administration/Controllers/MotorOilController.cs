using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNT.Services;

namespace SNT.Areas.Administration.Controllers
{
    public class MotorOilController : Controller
    {
        private readonly IMotorOilService motorOilService;
        private readonly ICloudinaryService cloudinaryService;

        public MotorOilController(IMotorOilService motorOilService, ICloudinaryService cloudinaryService)
        {
            this.motorOilService = motorOilService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet("/Administration/MotorOil/Create")]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}