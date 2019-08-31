using Microsoft.EntityFrameworkCore;
using SNT.Data;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace SNT.Tests.Common
{
    public class SntDbContextInMemoryFactory
    {
        public static SntDbContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<SntDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

            return new SntDbContext(options);
        }
    }
}
