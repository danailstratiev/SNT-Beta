using SNT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public interface IReceiptService
    {
       Task<bool> GenerateReceipt(string userId);

        ReceiptDetailsViewModel GetReceiptDetails(string orderId);

    }
}
