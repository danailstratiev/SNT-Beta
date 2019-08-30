using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNT.InputModels;
using SNT.ServiceModels;
using SNT.Services;
using SNT.Services.Mapping;
using SNT.ViewModels.Home;
using SNT.ViewModels.Review;

namespace SNT.Areas.Administration.Controllers
{
    public class MotorOilController : AdminController
    {
        private readonly IMotorOilService motorOilService;
        private readonly ICloudinaryService cloudinaryService;

        public MotorOilController(IMotorOilService motorOilService, ICloudinaryService cloudinaryService)
        {
            this.motorOilService = motorOilService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet("Administration/MotorOil/Create")]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost("/Administration/MotorOil/Create")]
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

        [HttpGet(Name = "Review")]
        public IActionResult Review(string id)
        {
            MotorOilReviewViewModel motorOilReviewViewModel = this.motorOilService.GetMotorOilById(id).To<MotorOilReviewViewModel>();

            return View(motorOilReviewViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AllMotorOils()
        {
            List<MotorOilHomeViewModel> motorOils = await this.motorOilService.GetAllOils().
                Select(motorOil => new MotorOilHomeViewModel
                {
                    Id = motorOil.Id,
                    Model = motorOil.Model,
                    Brand = motorOil.Brand,
                    Price = motorOil.Price,
                    Viscosity = motorOil.Viscosity,
                    Volume = motorOil.Volume,
                    Type = motorOil.Type,
                    Picture = motorOil.Picture,
                    Status = motorOil.Status,
                    Description = motorOil.Description
                })
                .ToListAsync<MotorOilHomeViewModel>();

            return View(motorOils);
        }

        [HttpGet("/Administration/MotorOil/Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            var motorOilServiceModel = this.motorOilService.GetMotorOilById(id);

            return View(motorOilServiceModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MotorOilServiceModel motorOilServiceModel)
        {
            await this.motorOilService.EditMotorOil(motorOilServiceModel);

            return this.Redirect("/Administration/MotorOil/AllMotorOils");
        }
    }
}