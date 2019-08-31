using Microsoft.EntityFrameworkCore;
using SNT.Data;
using SNT.Models;
using SNT.ServiceModels;
using SNT.Services;
using SNT.Services.Mapping;
using SNT.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SNT.Tests.ServiceTests
{
    public class WheelRimServiceTests
    {
        private IWheelRimService wheelRimService;

        private List<WheelRim> GetDummyData()
        {
            return new List<WheelRim>()
            {
                new WheelRim
                {
                    Model = "Ant96",
                    Brand = "Pym Tech",
                    Material = "carbon",
                    Price = 150.59M,
                    YearOfProduction = 2012,
                    Picture = "src/pics/somethingfunny/tyre",
                    Offset = 19,
                    PCD = "25",
                    CentralLukeDiameter = 15,
                    Status = Models.Enums.AvailabilityStatus.InStock,
                    Description = "For the queen !"
                },
                new WheelRim
                {
                    Model = "Atom Ant",
                    Brand = "Palmer Tech",
                    Material = "atomsteel",                    
                    Price = 189.59M,
                    YearOfProduction = 2018,
                    Picture = "src/pics/somethingfunny/atomant",
                    Offset = 195,
                    PCD = "65",
                    CentralLukeDiameter = 15,
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

        public WheelRimServiceTests()
        {
            MapInitializer.InitializeMapper();
        }

        [Fact]
        public async Task GetAllWheelRims_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "WheelRimService GetAllWheelRims() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.wheelRimService = new WheelRimService(context);

            List<WheelRimServiceModel> actualResults = await this.wheelRimService.GetAllWheelRims().ToListAsync();
            List<WheelRimServiceModel> expectedResults = GetDummyData().To<WheelRimServiceModel>().ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Model == actualEntry.Model, errorMessagePrefix + " " + "Model is not returned properly.");
                Assert.True(expectedEntry.Brand == actualEntry.Brand, errorMessagePrefix + " " + "Brand is not returned properly.");
                Assert.True(expectedEntry.PCD == actualEntry.PCD, errorMessagePrefix + " " + "PCD is not returned properly.");
                Assert.True(expectedEntry.Status == actualEntry.Status, errorMessagePrefix + " " + "Status is not returned properly.");
                Assert.True(expectedEntry.CentralLukeDiameter == actualEntry.CentralLukeDiameter, errorMessagePrefix + " " + "CentralLukeDiameter is not returned properly.");
                Assert.True(expectedEntry.Offset == actualEntry.Offset, errorMessagePrefix + " " + "Offset is not returned properly.");
                Assert.True(expectedEntry.Description == actualEntry.Description, errorMessagePrefix + " " + "Description is not returned properly.");
                Assert.True(expectedEntry.Material == actualEntry.Material, errorMessagePrefix + " " + "Material is not returned properly.");
                Assert.True(expectedEntry.YearOfProduction == actualEntry.YearOfProduction, errorMessagePrefix + " " + "YearOfProduction is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.Picture == actualEntry.Picture, errorMessagePrefix + " " + "Picture is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllWheelRims_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "WheelRimService GetAllWheelRims() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            this.wheelRimService = new WheelRimService(context);

            List<WheelRimServiceModel> actualResults = await this.wheelRimService.GetAllWheelRims().ToListAsync();

            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetWheelRimById_WithExistentId_ShouldReturnCorrectResult()
        {
            string errorMessagePrefix = "WheelRimService GetWheelRimById() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.wheelRimService = new WheelRimService(context);

            WheelRimServiceModel expectedData = context.WheelRims.First().To<WheelRimServiceModel>();
            WheelRimServiceModel actualData = this.wheelRimService.GetWheelRimById(expectedData.Id);

            Assert.True(expectedData.Model == actualData.Model, errorMessagePrefix + " " + "Model is not returned properly.");
            Assert.True(expectedData.Brand == actualData.Brand, errorMessagePrefix + " " + "Brand is not returned properly.");
            Assert.True(expectedData.PCD == actualData.PCD, errorMessagePrefix + " " + "PCD is not returned properly.");
            Assert.True(expectedData.Status == actualData.Status, errorMessagePrefix + " " + "Status is not returned properly.");
            Assert.True(expectedData.CentralLukeDiameter == actualData.CentralLukeDiameter, errorMessagePrefix + " " + "CentralLukeDiameter is not returned properly.");
            Assert.True(expectedData.Material == actualData.Material, errorMessagePrefix + " " + "Material is not returned properly.");
            Assert.True(expectedData.Description == actualData.Description, errorMessagePrefix + " " + "Description is not returned properly.");
            Assert.True(expectedData.Offset == actualData.Offset, errorMessagePrefix + " " + "Offset is not returned properly.");
            Assert.True(expectedData.YearOfProduction == actualData.YearOfProduction, errorMessagePrefix + " " + "YearOfProduction is not returned properly.");
            Assert.True(expectedData.Price == actualData.Price, errorMessagePrefix + " " + "Price is not returned properly.");
            Assert.True(expectedData.Picture == actualData.Picture, errorMessagePrefix + " " + "Picture is not returned properly.");
        }

        [Fact]
        public async Task GetWheelRimById_WithNonExistentId_ShouldReturnNull()
        {
            string errorMessagePrefix = "WheelRimService GetWheelRimById() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.wheelRimService = new WheelRimService(context);

            WheelRimServiceModel actualData = this.wheelRimService.GetWheelRimById("stamat");

            Assert.True(actualData == null, errorMessagePrefix);
        }

        public async Task Create_WithCorrectData_ShouldSuccessfullyCreate()
        {
            string errorMessagePrefix = "WheelRimService Create() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.wheelRimService = new WheelRimService(context);

            WheelRimServiceModel testProduct = new WheelRimServiceModel
            {
                Model = "Atom Ant",
                Brand = "Palmer Tech",
                Material = "atomsteel",
                Price = 209.59M,
                YearOfProduction = 2018,
                Picture = "src/pics/somethingfunny/atomant",
                Offset = 205,
                PCD = "65",
                CentralLukeDiameter = 15,
                Status = Models.Enums.AvailabilityStatus.InStock,
                Description = "Wield the power of Atom Ant!"
            };

            bool actualResult = await this.wheelRimService.Create(testProduct);
            Assert.True(actualResult, errorMessagePrefix);
        }

        

        [Fact]
        public async Task EditWheelRim_WithCorrectData_ShouldPassSuccessfully()
        {
            string errorMessagePrefix = "WheelRimService EditWheelRim() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.wheelRimService = new WheelRimService(context);

            WheelRimServiceModel expectedData = context.WheelRims.First().To<WheelRimServiceModel>();

            bool actualData = await this.wheelRimService.EditWheelRim(expectedData);

            Assert.True(actualData, errorMessagePrefix);
        }

        [Fact]
        public async Task EditWheelRim_WithCorrectData_ShouldEditProductCorrectly()
        {
            string errorMessagePrefix = "WheelRimService EditWheelRim() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.wheelRimService = new WheelRimService(context);

            WheelRimServiceModel expectedData = context.WheelRims.First().To<WheelRimServiceModel>();

            expectedData.Model = "EdittedModelame";
            expectedData.Price = 0.01M;
            expectedData.YearOfProduction = 1998;
            expectedData.Picture = "Editted_Picture";

            await this.wheelRimService.EditWheelRim(expectedData);

            WheelRimServiceModel actualData = context.Tyres.First().To<WheelRimServiceModel>();

            Assert.True(actualData.Model == expectedData.Model, errorMessagePrefix + " " + "Model not editted properly.");
            Assert.True(actualData.Price == expectedData.Price, errorMessagePrefix + " " + "Price not editted properly.");
            Assert.True(actualData.YearOfProduction == expectedData.YearOfProduction, errorMessagePrefix + " " + "YearOfProduction not editted properly.");
            Assert.True(actualData.Picture == expectedData.Picture, errorMessagePrefix + " " + "Picture not editted properly.");

        }

        [Fact]
        public async Task EditWheelRim_WithNonExistentTyreId_ShouldThrowArgumentNullException()
        {
            string errorMessagePrefix = "WheelRimService EditWheelRim() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.wheelRimService = new WheelRimService(context);

            WheelRimServiceModel expectedData = context.WheelRims.First().To<WheelRimServiceModel>();


            expectedData.Id = "1";
            expectedData.Model = "EdittedModelame";
            expectedData.Price = 0.01M;
            expectedData.YearOfProduction = 1998;
            expectedData.Picture = "Editted_Picture";

            await Assert.ThrowsAsync<ArgumentNullException>(() => this.wheelRimService.EditWheelRim(expectedData));
        }

        [Fact]
        public async Task GetAllAvailableWheelRIms_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "WheelRimService GetAllAvailableWheelRims() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.wheelRimService = new WheelRimService(context);

            List<WheelRimServiceModel> actualResults = await this.wheelRimService.GetAllAvailableWheelRims().ToListAsync();
            List<WheelRimServiceModel> expectedResults = GetDummyData().To<WheelRimServiceModel>().ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Model == actualEntry.Model, errorMessagePrefix + " " + "Model is not returned properly.");
                Assert.True(expectedEntry.Brand == actualEntry.Brand, errorMessagePrefix + " " + "Brand is not returned properly.");
                Assert.True(expectedEntry.PCD == actualEntry.PCD, errorMessagePrefix + " " + "PCD is not returned properly.");
                Assert.True(expectedEntry.Status == actualEntry.Status, errorMessagePrefix + " " + "Status is not returned properly.");
                Assert.True(expectedEntry.CentralLukeDiameter == actualEntry.CentralLukeDiameter, errorMessagePrefix + " " + "CentralLukeDiameter is not returned properly.");
                Assert.True(expectedEntry.Offset == actualEntry.Offset, errorMessagePrefix + " " + "Offset is not returned properly.");
                Assert.True(expectedEntry.Description == actualEntry.Description, errorMessagePrefix + " " + "Description is not returned properly.");
                Assert.True(expectedEntry.Material == actualEntry.Material, errorMessagePrefix + " " + "Material is not returned properly.");
                Assert.True(expectedEntry.YearOfProduction == actualEntry.YearOfProduction, errorMessagePrefix + " " + "YearOfProduction is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.Picture == actualEntry.Picture, errorMessagePrefix + " " + "Picture is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllAvailableWheelRims_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "WheelRimService GetAllAvailableWheelRims() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            this.wheelRimService = new WheelRimService(context);

            List<WheelRimServiceModel> actualResults = await this.wheelRimService.GetAllAvailableWheelRims().ToListAsync();

            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }
    }
}

