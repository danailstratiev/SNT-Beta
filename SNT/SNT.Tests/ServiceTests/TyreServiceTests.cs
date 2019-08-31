using Microsoft.EntityFrameworkCore;
using SNT.Data;
using SNT.Models;
using SNT.ServiceModels;
using SNT.Services;
using SNT.Services.Mapping;
using SNT.Tests.Common;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SNT.Tests.ServiceTests
{
   public class TyreServiceTests
    {
        private ITyreService tyreService;

        private List<Tyre> GetDummyData()
        {
            return new List<Tyre>()
            {
                new Tyre
                {
                    Model = "Ant96",
                    Brand = "Pym Tech",
                    Type = Models.Enums.SeasonType.AllSeasons,
                    Price = 150.59M,
                    YearOfProduction = 2012,
                    Picture = "src/pics/somethingfunny/tyre",
                    Width = 195,
                    Ratio = 65,
                    Diameter = 15,
                    Status = Models.Enums.AvailabilityStatus.InStock,
                    Description = "For the queen !"
                },
                new Tyre
                {
                    Model = "Atom Ant",
                    Brand = "Palmer Tech",
                    Type = Models.Enums.SeasonType.AllSeasons,
                    Price = 169.59M,
                    YearOfProduction = 2018,
                    Picture = "src/pics/somethingfunny/atomant",
                    Width = 195,
                    Ratio = 65,
                    Diameter = 15,
                    Status = Models.Enums.AvailabilityStatus.OutOfStock,
                    Description = "Wield the power of Atom Ant!"
                }
            };
        }

        private async Task SeedData(SntDbContext context)
        {
            context.AddRange(GetDummyData());
            await context.SaveChangesAsync();
        }

        public TyreServiceTests()
        {
            MapInitializer.InitializeMapper();
        }

        [Fact]
        public async Task GetAllTyres_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "TyreService GetAllProducts() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.tyreService = new TyreService(context);

            List<TyreServiceModel> actualResults = await this.tyreService.GetAllTyres().ToListAsync();
            List<TyreServiceModel> expectedResults = GetDummyData().To<TyreServiceModel>().ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Model == actualEntry.Model, errorMessagePrefix + " " + "Model is not returned properly.");
                Assert.True(expectedEntry.Brand == actualEntry.Brand, errorMessagePrefix + " " + "Brand is not returned properly.");
                Assert.True(expectedEntry.Type == actualEntry.Type, errorMessagePrefix + " " + "Type is not returned properly.");
                Assert.True(expectedEntry.Status == actualEntry.Status, errorMessagePrefix + " " + "Status is not returned properly.");
                Assert.True(expectedEntry.Diameter == actualEntry.Diameter, errorMessagePrefix + " " + "Diameter is not returned properly.");
                Assert.True(expectedEntry.Ratio == actualEntry.Ratio, errorMessagePrefix + " " + "Ratio is not returned properly.");
                Assert.True(expectedEntry.Description == actualEntry.Description, errorMessagePrefix + " " + "Description is not returned properly.");
                Assert.True(expectedEntry.Width == actualEntry.Width, errorMessagePrefix + " " + "Width is not returned properly.");
                Assert.True(expectedEntry.YearOfProduction == actualEntry.YearOfProduction, errorMessagePrefix + " " + "YearOfProduction is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.Picture == actualEntry.Picture, errorMessagePrefix + " " + "Picture is not returned properly.");
            }
        }
    }
}
