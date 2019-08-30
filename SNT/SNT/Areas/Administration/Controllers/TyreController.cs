using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNT.InputModels;
using SNT.Models;
using SNT.ServiceModels;
using SNT.Services;
using SNT.Services.Mapping;
using SNT.ViewModels.Edit;
using SNT.ViewModels.Home;

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

        [HttpGet("/Administration/Tyre/Create")]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpGet("/Administration/Tyre/Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            TyreEditViewModel tyreReviewViewModel = this.tyreService.GetTyreById(id).To<TyreEditViewModel>();

            return View(tyreReviewViewModel);
        }

        [HttpPost("/Administration/Tyre/Create")]
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

        [HttpGet("/Administration/Tyre/AllTyres")]
        public async Task<IActionResult> AllTyres()
        {
            List<TyreHomeViewModel> tyres = await this.tyreService.GetAllTyres()
                .Select(tyre => new TyreHomeViewModel
                {
                    Id = tyre.Id,
                    Model = tyre.Model,
                    Brand = tyre.Brand,
                    Type = tyre.Type,
                    Status = tyre.Status,
                    Price = tyre.Price,
                    Picture = tyre.Picture,
                    Width = tyre.Width,
                    Ratio = tyre.Ratio,
                    Diameter = tyre.Diameter,
                    Description = tyre.Description,
                    YearOfProduction = tyre.YearOfProduction
                })
                .ToListAsync();

            return this.View(tyres);
        }



        //[HttpPost]
        //[Route("/Home/Tyres")]
        //public IActionResult Delete(string id)
        //{
        //    this.tyreService.MakeTyreOutOfStock(id);

        //    return Redirect("/");
        //}

        //[HttpGet]
        //public IActionResult Edit(string id)
        //{

        //    return View();
        //}


    }
}