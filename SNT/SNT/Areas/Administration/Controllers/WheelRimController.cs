using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNT.InputModels;
using SNT.ServiceModels;
using SNT.Services;
using SNT.Services.Mapping;
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

        
    }
}