using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNT.Models;
using SNT.Services;

namespace SNT.Areas.Administration.Controllers
{
    public class TyreController : AdminController
    {
        private ITyreService tyreService;

        public TyreController(ITyreService tyreService)
        {
            this.tyreService = tyreService;
        }

        [HttpGet("/Administration/Tyres/Create")]
        public async Task<IActionResult> Create()
        {
            return this.View("Tyres/Create");
        }

        [HttpPost("/Administration/Tyres/Create")]
        public async Task <IActionResult> Create(Tyre tyre)
        {
            return this.View("Tyres/Create");            
        }
    }
}