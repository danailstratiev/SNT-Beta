using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNT.Services;

namespace SNT.Controllers
{
    public class WheelRimController : Controller
    {
        private readonly IWheelRimService wheelRimService;

        public WheelRimController(IWheelRimService wheelRimService)
        {
            this.wheelRimService = wheelRimService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}