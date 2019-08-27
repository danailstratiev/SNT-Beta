using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SNT.Services;

namespace SNT.Controllers
{
    public class ReceiptController : Controller
    {
        private IReceiptService receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Receipt/Details")]
        public async Task<IActionResult> Details(string orderId)
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.receiptService.GenerateReceipt(userId);

            var receiptDetailsViewModel = this.receiptService.GetReceiptDetails(orderId);

            return View(receiptDetailsViewModel);
        }
    }
}