using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNT.Services;
using SNT.Services.Mapping;
using SNT.ViewModels;

namespace SNT.Controllers
{
    public class TyreController : Controller
    {
        private ITyreService tyreService;

        public TyreController(ITyreService tyreService)
        {
            this.tyreService = tyreService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet(Name = "Review")]
        public IActionResult Review(string id)
        {
            TyreReviewViewModel tyreReviewViewModel = this.tyreService.GetTyreById(id).To<TyreReviewViewModel>();
            return View();
        }


    }
}