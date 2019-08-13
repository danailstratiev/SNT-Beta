using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SNT.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Admin")]
    public abstract class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}