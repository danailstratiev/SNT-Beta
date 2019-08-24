using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public interface IShoppingBagService
    {
        Task<bool> AddTyreToShoppingBag(string tyreId, string userId, int quantity);
    }
}
