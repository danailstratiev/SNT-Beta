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
    public class MotorOilServiceTests
    {
        private IMotorOilService motorOilService;

        private List<MotorOil> GetDummyData()
        {
            return new List<MotorOil>()
            {
                new MotorOil
                {
                    Model = "AntOil96",
                    Brand = "Pym Oils",
                    Viscosity = "40awd",
                    Price = 150.59M,
                    Type = "synthetic",
                    Picture = "src/pics/somethingfunny/tyre",
                    Volume = 6,
                    Status = Models.Enums.AvailabilityStatus.InStock,
                    Description = "For the queen !"
                },
                new MotorOil
                {
                    Model = "Atom Ant",
                    Brand = "Palmer Tech",
                    Viscosity = "35awd",
                    Price = 189.59M,
                    Type = "natural",
                    Picture = "src/pics/somethingfunny/atomant",
                    Volume = 9,
                    Status = Models.Enums.AvailabilityStatus.OutOfStock,
                    Description = "Wield the oil of Atom Ant!"
                }
            };
        }

        private async Task SeedData(SntDbContext context)
        {
            context.AddRange(GetDummyData());
            await context.SaveChangesAsync();
        }

        public MotorOilServiceTests()
        {
            MapInitializer.InitializeMapper();
        }

        [Fact]
        public async Task GetAllOils_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "MotorOilService GetAllOils() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.motorOilService = new MotorOilService(context);

            List<MotorOilServiceModel> actualResults = await this.motorOilService.GetAllOils().ToListAsync();
            List<MotorOilServiceModel> expectedResults = GetDummyData().To<MotorOilServiceModel>().ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Model == actualEntry.Model, errorMessagePrefix + " " + "Model is not returned properly.");
                Assert.True(expectedEntry.Brand == actualEntry.Brand, errorMessagePrefix + " " + "Brand is not returned properly.");
                Assert.True(expectedEntry.Viscosity == actualEntry.Viscosity, errorMessagePrefix + " " + "Viscosity is not returned properly.");
                Assert.True(expectedEntry.Status == actualEntry.Status, errorMessagePrefix + " " + "Status is not returned properly.");
                Assert.True(expectedEntry.Volume == actualEntry.Volume, errorMessagePrefix + " " + "Volume is not returned properly.");
                Assert.True(expectedEntry.Type == actualEntry.Type, errorMessagePrefix + " " + "Type is not returned properly.");
                Assert.True(expectedEntry.Description == actualEntry.Description, errorMessagePrefix + " " + "Description is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.Picture == actualEntry.Picture, errorMessagePrefix + " " + "Picture is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllOils_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "MotorOilService GetAllOils() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            this.motorOilService = new MotorOilService(context);

            List<MotorOilServiceModel> actualResults = await this.motorOilService.GetAllOils().ToListAsync();

            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetMotorilId_WithExistentId_ShouldReturnCorrectResult()
        {
            string errorMessagePrefix = "MotorOilService GetMotorOilById() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.motorOilService = new MotorOilService(context);

            MotorOilServiceModel expectedData = context.MotorOils.First().To<MotorOilServiceModel>();
            MotorOilServiceModel actualData = this.motorOilService.GetMotorOilById(expectedData.Id);

            Assert.True(expectedData.Model == actualData.Model, errorMessagePrefix + " " + "Model is not returned properly.");
            Assert.True(expectedData.Brand == actualData.Brand, errorMessagePrefix + " " + "Brand is not returned properly.");
            Assert.True(expectedData.Viscosity == actualData.Viscosity, errorMessagePrefix + " " + "Viscosity is not returned properly.");
            Assert.True(expectedData.Status == actualData.Status, errorMessagePrefix + " " + "Status is not returned properly.");
            Assert.True(expectedData.Volume == actualData.Volume, errorMessagePrefix + " " + "Volume is not returned properly.");
            Assert.True(expectedData.Type == actualData.Type, errorMessagePrefix + " " + "Type is not returned properly.");
            Assert.True(expectedData.Description == actualData.Description, errorMessagePrefix + " " + "Description is not returned properly.");
            Assert.True(expectedData.Price == actualData.Price, errorMessagePrefix + " " + "Price is not returned properly.");
            Assert.True(expectedData.Picture == actualData.Picture, errorMessagePrefix + " " + "Picture is not returned properly.");
        }

        [Fact]
        public async Task GetMotorilId_WithNonExistentId_ShouldReturnNull()
        {
            string errorMessagePrefix = "MotorOilService GetMotorOilById() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.motorOilService = new MotorOilService(context);

            MotorOilServiceModel actualData = this.motorOilService.GetMotorOilById("stamat");

            Assert.True(actualData == null, errorMessagePrefix);
        }

        public async Task Create_WithCorrectData_ShouldSuccessfullyCreate()
        {
            string errorMessagePrefix = "MotorOilService Create() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.motorOilService = new MotorOilService(context);

            MotorOilServiceModel testProduct = new MotorOilServiceModel
            {
                Model = "Atom Wym",
                Brand = "Wym Tech",
                Viscosity = "35awd",
                Price = 209.59M,
                Type = "unnatural",
                Picture = "src/pics/somethingfunny/atomant",
                Volume = 26,
                Status = Models.Enums.AvailabilityStatus.OutOfStock,
                Description = "Wield the oil of Atom Wym!"
            };

            bool actualResult = await this.motorOilService.Create(testProduct);
            Assert.True(actualResult, errorMessagePrefix);
        }



        [Fact]
        public async Task EditMotorOil_WithCorrectData_ShouldPassSuccessfully()
        {
            string errorMessagePrefix = "MotorOilService EditMotorOil() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.motorOilService = new MotorOilService(context);

            MotorOilServiceModel expectedData = context.MotorOils.First().To<MotorOilServiceModel>();

            bool actualData = await this.motorOilService.EditMotorOil(expectedData);

            Assert.True(actualData, errorMessagePrefix);
        }

        [Fact]
        public async Task EditMotorOil_WithCorrectData_ShouldEditProductCorrectly()
        {
            string errorMessagePrefix = "MotorOilService EditMotorOil() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.motorOilService = new MotorOilService(context);

            MotorOilServiceModel expectedData = context.MotorOils.First().To<MotorOilServiceModel>();

            expectedData.Model = "EdittedModelame";
            expectedData.Price = 0.01M;
            expectedData.Volume = 6;
            expectedData.Picture = "Editted_Picture";

            await this.motorOilService.EditMotorOil(expectedData);

            MotorOilServiceModel actualData = context.Tyres.First().To<MotorOilServiceModel>();

            Assert.True(actualData.Model == expectedData.Model, errorMessagePrefix + " " + "Model not editted properly.");
            Assert.True(actualData.Price == expectedData.Price, errorMessagePrefix + " " + "Price not editted properly.");
            Assert.True(actualData.Volume == expectedData.Volume, errorMessagePrefix + " " + "Volume not editted properly.");
            Assert.True(actualData.Picture == expectedData.Picture, errorMessagePrefix + " " + "Picture not editted properly.");

        }

        [Fact]
        public async Task EditMotorOil_WithNonExistentTyreId_ShouldThrowArgumentNullException()
        {
            string errorMessagePrefix = "MotorOilService EditMotorOil() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.motorOilService = new MotorOilService(context);

            MotorOilServiceModel expectedData = context.MotorOils.First().To<MotorOilServiceModel>();


            expectedData.Id = "1";
            expectedData.Model = "EdittedModelame";
            expectedData.Price = 0.01M;
            expectedData.Volume = 6;
            expectedData.Picture = "Editted_Picture";

            await Assert.ThrowsAsync<ArgumentNullException>(() => this.motorOilService.EditMotorOil(expectedData));
        }

        [Fact]
        public async Task GetAllAvailableOils_WithDummyData_ShouldReturnCorrectResults()
        {
            string errorMessagePrefix = "MotorOilService GetAllAvailableOils() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            await SeedData(context);
            this.motorOilService = new MotorOilService(context);

            List<MotorOilServiceModel> actualResults = await this.motorOilService.GetAllAvailableOils().ToListAsync();
            List<MotorOilServiceModel> expectedResults = GetDummyData().To<MotorOilServiceModel>().ToList();

            for (int i = 0; i < expectedResults.Count; i++)
            {
                var expectedEntry = expectedResults[i];
                var actualEntry = actualResults[i];

                Assert.True(expectedEntry.Model == actualEntry.Model, errorMessagePrefix + " " + "Model is not returned properly.");
                Assert.True(expectedEntry.Brand == actualEntry.Brand, errorMessagePrefix + " " + "Brand is not returned properly.");
                Assert.True(expectedEntry.Viscosity == actualEntry.Viscosity, errorMessagePrefix + " " + "Viscosity is not returned properly.");
                Assert.True(expectedEntry.Status == actualEntry.Status, errorMessagePrefix + " " + "Status is not returned properly.");
                Assert.True(expectedEntry.Volume == actualEntry.Volume, errorMessagePrefix + " " + "Volume is not returned properly.");
                Assert.True(expectedEntry.Type == actualEntry.Type, errorMessagePrefix + " " + "Offset is not returned properly.");
                Assert.True(expectedEntry.Description == actualEntry.Description, errorMessagePrefix + " " + "Description is not returned properly.");
                Assert.True(expectedEntry.Price == actualEntry.Price, errorMessagePrefix + " " + "Price is not returned properly.");
                Assert.True(expectedEntry.Picture == actualEntry.Picture, errorMessagePrefix + " " + "Picture is not returned properly.");
            }
        }

        [Fact]
        public async Task GetAllAvailableOils_WithZeroData_ShouldReturnEmptyResults()
        {
            string errorMessagePrefix = "MotorOilService GetAllAvailableOils() method does not work properly.";

            var context = SntDbContextInMemoryFactory.InitializeContext();
            this.motorOilService = new MotorOilService(context);

            List<MotorOilServiceModel> actualResults = await this.motorOilService.GetAllAvailableOils().ToListAsync();

            Assert.True(actualResults.Count == 0, errorMessagePrefix);
        }
    }

}
