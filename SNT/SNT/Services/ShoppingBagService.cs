using SNT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNT.Services
{
    public class ShoppingBagService : IShoppingBagService
    {
        private SntDbContext context;

        public ShoppingBagService(SntDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddTyreToShoppingBag()
        {

            return true;
        }
    }
}
