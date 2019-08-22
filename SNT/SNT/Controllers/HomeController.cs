using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SNT.Models;
using SNT.Services;
using SNT.ViewModels.Home;

namespace SNT.Controllers
{
    public class HomeController : Controller
    {
        private ITyreService tyreService;
        private IWheelRimService wheelRimService;

        public HomeController(ITyreService tyreService, IWheelRimService wheelRimService)
        {
            this.tyreService = tyreService;
            this.wheelRimService = wheelRimService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Tyres()
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

            return View(tyres);
        }

        [HttpGet]
        public async Task<IActionResult> WheelRims()
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
    }
}
