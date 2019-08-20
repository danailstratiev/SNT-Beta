using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNT.InputModels;
using SNT.Models;
using SNT.ServiceModels;
using SNT.Services;

namespace SNT.Areas.Administration.Controllers
{
    public class TyreController : AdminController
    {
        private ITyreService tyreService;
        private readonly ICloudinaryService cloudinaryService;

        public TyreController(ITyreService tyreService, ICloudinaryService cloudinaryService)
        {
            this.tyreService = tyreService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet("/Administration/Tyres/Create")]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost("/Administration/Tyres/Create")]
        public async Task <IActionResult> Create(TyreCreateInputModel tyreCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(tyreCreateInputModel);
            }

            string imageUrl = await this.cloudinaryService.UploadPictureAsync(
               tyreCreateInputModel.Picture,
               tyreCreateInputModel.Model);

            TyreServiceModel tyreServiceModel = AutoMapper.Mapper.Map<TyreServiceModel>(tyreCreateInputModel);

            tyreServiceModel.Picture = imageUrl;

            await this.tyreService.Create(tyreServiceModel);

            return this.Redirect("/");
        }
    }
}