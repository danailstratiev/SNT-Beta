using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNT.Models;
using SNT.Services;

namespace SNT.Areas.Administrator.Controllers
{
    public class TyreController : AdminController
    {
        private ITyreService tyreService;

        public TyreController(ITyreService tyreService)
        {
            this.tyreService = tyreService;
        }

        [HttpGet("/Administrator/Types/Create")]
        public async Task<IActionResult> CreateType()
        {
            return this.View("Type/Create");
        }

        [HttpPost("/Administrator/Types/Create")]
        public async Task <IActionResult> Create(Tyre tyre)
        {
            return null;
        }
    }
}