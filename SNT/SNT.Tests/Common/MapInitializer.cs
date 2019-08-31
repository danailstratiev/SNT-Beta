using SNT.Models;
using SNT.ServiceModels;
using SNT.Services.Mapping;
using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SNT.Tests.Common
{
    public class MapInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(TyreServiceModel).GetTypeInfo().Assembly,
                typeof(Tyre).GetTypeInfo().Assembly);
        }
    }
}
