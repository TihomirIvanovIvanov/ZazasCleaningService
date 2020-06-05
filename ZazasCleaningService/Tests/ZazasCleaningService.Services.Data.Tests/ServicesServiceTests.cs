namespace ZazasCleaningService.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Data.Tests.Common;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;

    public class ServicesServiceTests
    {
        private IServicesService servicesService;

        public ServicesServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task GetAllServices_WithDummyData_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ServicesService GetAllServicesAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>().ToListAsync();
            var expectedResult = this.GetDummyData().To<ServicesServiceModel>().ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);

            // TODO:
            // for (int i = 0; i < expectedResult.Count; i++)
            // {
            //     var expectedEntry = expectedResult[i];
            //     var actualEntry = actualResult[i];
            //     Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not return  properly.");
            //     Assert.True(expectedEntry.Description == actualEntry.Description, errorMessagePrefix + " " + "Description is  not return properly.");
            //     Assert.True(expectedEntry.Picture == actualEntry.Picture, errorMessagePrefix + " " + "Picture is not return  properly.");
            //     Assert.True(expectedEntry.ProductType.Name == actualEntry.ProductType.Name, errorMessagePrefix + " " +  "ProductType Name is not return properly.");
            // }
        }

        // TODO: ShouldThrowException
        [Fact]
        public async Task GetAllServices_WithZeroData_ShouldReturnEmptyResult()
        {
            var errorMessagePrefix = "ServicesService GetAllServicesAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.servicesService = new ServicesService(dbContext);

            var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>().ToListAsync();

            Assert.True(actualResult.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllServices_WithDummyDataTakeOneSkipOne_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ServicesService GetAllServicesAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>(1, 1).ToListAsync();
            var expectedResult = this.GetDummyData().To<ServicesServiceModel>().Skip(1).Take(1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllServices_WithDummyDataTakeOneSkipZero_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ServicesService ServicesServiceModel() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>(1, 0).ToListAsync();
            var expectedResult = this.GetDummyData().To<ServicesServiceModel>().Take(1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllServices_WithDummyDataTakeZeroSkipOne_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ServicesService GetAllServicesAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>(0, 1).ToListAsync();
            var expectedResult = this.GetDummyData().To<ServicesServiceModel>().Take(0).Skip(1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllServices_WithDummyDataTakeZeroSkipZero_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ServicesService GetAllServicesAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>(0, 0).ToListAsync();
            var expectedResult = this.GetDummyData().To<ServicesServiceModel>().Take(0).Skip(0).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllServices_WithDummyDataNegativeTakeAndNegativeSkip_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ServicesService GetAllServicesAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>(-1, -1).ToListAsync();
            var expectedResult = this.GetDummyData().To<ServicesServiceModel>().Take(-1).Skip(-1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllServices_WithDummyDataNegativeTakeAndSkipOne_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ServicesService GetAllServicesAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>(-1, 1).ToListAsync();
            var expectedResult = this.GetDummyData().To<ServicesServiceModel>().Take(-1).Skip(1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllServices_WithDummyDataTakeOneAndNegativeSkip_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ServicesService GetAllServicesAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>(1, -1).ToListAsync();
            var expectedResult = this.GetDummyData().To<ServicesServiceModel>().Take(1).Skip(-1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        private async Task SeedData(ApplicationDbContext dbContext)
        {
            await dbContext.AddRangeAsync(this.GetDummyData());
            await dbContext.SaveChangesAsync();
        }

        private List<Service> GetDummyData()
        {
            return new List<Service>()
            {
                new Service
                {
                    Name = "cleaning product",
                    Picture = "default",
                    Description = "cleaning product desc",
                },
                new Service
                {
                    Name = "food product",
                    Picture = "default",
                    Description = "food product desc",
                },
            };
        }
    }
}
