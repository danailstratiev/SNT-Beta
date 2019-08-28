using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNT.InputModels;
using SNT.ServiceModels;
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

        [HttpPost("/Administration/Tyres/Create")]
        public async Task<IActionResult> Create(MotorOilCreateInputModel motorOilCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(motorOilCreateInputModel);
            }

            string imageUrl = await this.cloudinaryService.UploadPictureAsync(
               motorOilCreateInputModel.Picture,
               motorOilCreateInputModel.Model);

            MotorOilServiceModel motorOilServiceModel = AutoMapper.Mapper.Map<MotorOilServiceModel>(motorOilCreateInputModel);

            motorOilServiceModel.Picture = imageUrl;

            await this.motorOilService.Create(motorOilServiceModel);

            return this.Redirect("/");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}