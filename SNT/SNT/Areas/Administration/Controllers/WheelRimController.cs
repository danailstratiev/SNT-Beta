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
    

    public class WheelRimController : AdminController
    {
        private IWheelRimService wheelRimService;
        private readonly ICloudinaryService cloudinaryService;
       

        public WheelRimController(IWheelRimService wheelRimService, ICloudinaryService cloudinaryService)
        {
            this.wheelRimService = wheelRimService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet("/Administration/WheelRim/Create")]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost("/Administration/WheelRim/Create")]
        public async Task<IActionResult> Create(WheelRimCreateInputModel wheelRimCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(wheelRimCreateInputModel);
            }

            string imageUrl = await this.cloudinaryService.UploadPictureAsync(
               wheelRimCreateInputModel.Picture,
               wheelRimCreateInputModel.Model);

            WheelRimServiceModel wheelRimServiceModel = AutoMapper.Mapper.Map<WheelRimServiceModel>(wheelRimCreateInputModel);

            wheelRimServiceModel.Picture = imageUrl;

            await this.wheelRimService.Create(wheelRimServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Review")]
        public IActionResult Review(string id)
        {
            WheelRimReviewViewModel wheelRimReviewViewModel = this.wheelRimService.GetWheelRimById(id).To<WheelRimReviewViewModel>();

            return View(wheelRimReviewViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AllWheelRims()
        {
            List<WheelRimHomeViewModel> wheelRims = await this.wheelRimService.GetAllWheelRims().
                Select(wheelRim => new WheelRimHomeViewModel
                {
                    Id = wheelRim.Id,
                    Model = wheelRim.Model,
                    Brand = wheelRim.Brand,
                    CentralLukeDiameter = wheelRim.CentralLukeDiameter,
                    PCD = wheelRim.PCD,
                    Offset = wheelRim.Offset,
                    Status = wheelRim.Status,
                    Picture = wheelRim.Picture,
                    Price = wheelRim.Price,
                    Material = wheelRim.Material,
                    YearOfProduction = wheelRim.YearOfProduction,
                    Description = wheelRim.Description
                })
                .ToListAsync();

            return View(wheelRims);
        }

        [HttpGet("/Administration/WheelRim/Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            var wheelRimServiceModel = this.wheelRimService.GetWheelRimById(id);

            return View(wheelRimServiceModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WheelRimServiceModel wheelRimServiceModel)
        {
            await this.wheelRimService.EditWheelRim(wheelRimServiceModel);

            return this.Redirect("/Administration/WheelRim/AllWheelRims");
        }
    }
}