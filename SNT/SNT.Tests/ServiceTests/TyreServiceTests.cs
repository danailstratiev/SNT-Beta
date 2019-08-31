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

        [Fact]
        public async Task GetAllTyres_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "TyreService GetAllTyres() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            this.tyreService = new TyreService(context);

            List<TyreServiceModel> actualResults = await this.tyreService.GetAllTyres().ToListAsync();

            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetTyreById_WithExistentId_ShouldReturnCorrectResult()
        {
            string errorMessagePrefix = "TyreService GetTyreById() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.tyreService = new TyreService(context);

            TyreServiceModel expectedData = context.Tyres.First().To<TyreServiceModel>();
            TyreServiceModel actualData =  this.tyreService.GetTyreById(expectedData.Id);

            Assert.True(expectedData.Model == actualData.Model, errorMessagePrefix + " " + "Model is not returned properly.");
                Assert.True(expectedData.Brand == actualData.Brand, errorMessagePrefix + " " + "Brand is not returned properly.");
                Assert.True(expectedData.Type == actualData.Type, errorMessagePrefix + " " + "Type is not returned properly.");
                Assert.True(expectedData.Status == actualData.Status, errorMessagePrefix + " " + "Status is not returned properly.");
                Assert.True(expectedData.Diameter == actualData.Diameter, errorMessagePrefix + " " + "Diameter is not returned properly.");
                Assert.True(expectedData.Ratio == actualData.Ratio, errorMessagePrefix + " " + "Ratio is not returned properly.");
                Assert.True(expectedData.Description == actualData.Description, errorMessagePrefix + " " + "Description is not returned properly.");
                Assert.True(expectedData.Width == actualData.Width, errorMessagePrefix + " " + "Width is not returned properly.");
                Assert.True(expectedData.YearOfProduction == actualData.YearOfProduction, errorMessagePrefix + " " + "YearOfProduction is not returned properly.");
                Assert.True(expectedData.Price == actualData.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedData.Picture == actualData.Picture, errorMessagePrefix + " " + "Picture is not returned properly.");
        }

        [Fact]
        public async Task GetTyreById_WithNonExistentId_ShouldReturnNull()
        {
            string errorMessagePrefix = "TyreService GetTyreById() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.tyreService = new TyreService(context);

            TyreServiceModel actualData = this.tyreService.GetTyreById("stamat");

            Assert.True(actualData == null, errorMessagePrefix);
        }

        public async Task Create_WithCorrectData_ShouldSuccessfullyCreate()
        {
            string errorMessagePrefix = "TyreService Create() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.tyreService = new TyreService(context);

            TyreServiceModel testProduct = new TyreServiceModel
            {
                Model = "Giant Ant",
                Brand = "Pym Tech",
                Type = Models.Enums.SeasonType.AllSeasons,
                Price = 189.59M,
                YearOfProduction = 2018,
                Picture = "src/pics/giant/ant",
                Width = 195,
                Ratio = 65,
                Diameter = 15,
                Status = Models.Enums.AvailabilityStatus.OutOfStock,
                Description = "Wield the power of Giant Ant!"
            };

            bool actualResult = await this.tyreService.Create(testProduct);
            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task Create_WithNonExistentProductType_ShouldThrowArgumentNullException()
        {
            string errorMessagePrefix = "TyreService Create() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.tyreService = new TyreService(context);


            TyreServiceModel testProduct = new TyreServiceModel
            {
                Model = "Giant Ant",
                Brand = "Pym Tech",
                Type = Models.Enums.SeasonType.AllSeasons,
                Price = 189.59M,
                YearOfProduction = 2018,
                Picture = "src/pics/giant/ant",
                Width = 205,
                Ratio = 75,
                Diameter = 18,
                Status = Models.Enums.AvailabilityStatus.OutOfStock,
                Description = "Wield the power of Giant Ant!"
            };
            

            await Assert.ThrowsAsync<ArgumentNullException>(() => this.tyreService.Create(testProduct));
        }

        [Fact]
        public async Task EditTyre_WithCorrectData_ShouldPassSuccessfully()
        {
            string errorMessagePrefix = "ProductService Edit() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.tyreService = new TyreService(context);

            TyreServiceModel expectedData = context.Tyres.First().To<TyreServiceModel>();

            bool actualData = await this.tyreService.EditTyre(expectedData);

            Assert.True(actualData, errorMessagePrefix);
        }

        [Fact]
        public async Task EditTyre_WithCorrectData_ShouldEditProductCorrectly()
        {
            string errorMessagePrefix = "ProductService EditTyre() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.tyreService = new TyreService(context);

            TyreServiceModel expectedData = context.Tyres.First().To<TyreServiceModel>();

            expectedData.Model = "EdittedModelame";
            expectedData.Price = 0.01M;
            expectedData.YearOfProduction = 1998;
            expectedData.Picture = "Editted_Picture";

            await this.tyreService.EditTyre(expectedData);

            TyreServiceModel actualData = context.Tyres.First().To<TyreServiceModel>();

            Assert.True(actualData.Model == expectedData.Model, errorMessagePrefix + " " + "Model not editted properly.");
            Assert.True(actualData.Price == expectedData.Price, errorMessagePrefix + " " + "Price not editted properly.");
            Assert.True(actualData.YearOfProduction == expectedData.YearOfProduction, errorMessagePrefix + " " + "YearOfProduction not editted properly.");
            Assert.True(actualData.Picture == expectedData.Picture, errorMessagePrefix + " " + "Picture not editted properly.");

        }

        [Fact]
        public async Task EditTyre_WithNonExistentTyreId_ShouldThrowArgumentNullException()
        {
            string errorMessagePrefix = "TyreService EditTyre() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.tyreService = new TyreService(context);

            TyreServiceModel expectedData = context.Tyres.First().To<TyreServiceModel>();


            expectedData.Id = "1";
            expectedData.Model = "EdittedModelame";
            expectedData.Price = 0.01M;
            expectedData.YearOfProduction = 1998;
            expectedData.Picture = "Editted_Picture";

            await Assert.ThrowsAsync<ArgumentNullException>(() => this.tyreService.EditTyre(expectedData));
        }
    }
}
