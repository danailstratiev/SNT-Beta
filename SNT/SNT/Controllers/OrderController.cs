using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNT.InputModels;
using SNT.ServiceModels;
using SNT.Services;

namespace SNT.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/Order/Create")]
        public IActionResult Create(OrderCreateInputModel orderCreateInputModel)
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            OrderServiceModel orderServiceModel = AutoMapper.Mapper.Map<OrderServiceModel>(orderCreateInputModel);

            this.orderService.Create(orderServiceModel, userId);

            return Redirect("/");
        }
    }
}