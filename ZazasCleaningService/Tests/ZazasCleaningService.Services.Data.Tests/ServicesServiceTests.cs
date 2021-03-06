﻿namespace ZazasCleaningService.Services.Data.Tests
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
        }

        [Fact]
        public async Task GetAllServices_WithDummyData_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();

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

        [Fact]
        public async Task GetAllServicesCount_WithDummyData_ShoultReturnCorrectResult()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var expectedResult = dbContext.Services.Count();
            var actualResult = this.servicesService.GetCountServices();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetAllServicesCount_WithNoData_ShoultThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.servicesService = new ServicesService(dbContext);

            Assert.Throws<ArgumentNullException>(() => this.servicesService.GetCountServices());
        }

        // TODO:
        // [Fact]
        //public async Task GetAllServices_ZeroData_ShouldThrowArgumentNullException()
        //{
        //    var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
        //    this.servicesService = new ServicesService(dbContext);
        //    await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        //          await this.servicesService.GetAllServicesAsync<ServicesServiceModel>().ToListAsync());
        //}

        [Fact]
        public async Task GetById_WithExistentId_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ServicesService GetServiceByIdAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var expectedResult = dbContext.Services.First().To<ServicesServiceModel>();
            var actualResult = await this.servicesService.GetServiceByIdAsync(expectedResult.Id);

            Assert.True(expectedResult.Id == actualResult.Id, errorMessagePrefix + " " + "Id is not return properly.");
            Assert.True(expectedResult.Name == actualResult.Name, errorMessagePrefix + " " + "Name is not return properly.");
            Assert.True(expectedResult.Description == actualResult.Description, errorMessagePrefix + " " + "Description is not return properly.");
            Assert.True(expectedResult.Picture == actualResult.Picture, errorMessagePrefix + " " + "Picture is not return properly.");
        }

        [Fact]
        public async Task GetById_WithNonExistentId_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.servicesService.GetServiceByIdAsync(0));
        }

        [Fact]
        public async Task Create_WithCorrectData_ShouldSuccsessfullyCreate()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var testProductService = new ServicesServiceModel
            {
                Name = "cleaning",
                Description = "cleaning desc",
                Picture = "default",
            };

            var expectedResultId = 3;
            var actualResultId = await this.servicesService.CreateServiceAsync(testProductService);

            Assert.Equal(actualResultId, expectedResultId);
        }

        [Fact]
        public async Task Create_WithNull_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.servicesService = new ServicesService(dbContext);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                  await this.servicesService.CreateServiceAsync(null));
        }

        [Fact]
        public async Task Edit_WithCorrectData_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ServicesService EditAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var expectedResult = dbContext.Services.First().To<ServicesServiceModel>();
            var actualResult = await this.servicesService.EditAsync(expectedResult.Id, expectedResult);

            Assert.True(expectedResult.Name == actualResult.To<ServicesServiceModel>().Name, errorMessagePrefix + " " + "Name is not return properly.");
            Assert.True(expectedResult.Description == actualResult.To<ServicesServiceModel>().Description, errorMessagePrefix + " " + "Description is not return properly.");
            Assert.True(expectedResult.Picture == actualResult.To<ServicesServiceModel>().Picture, errorMessagePrefix + " " + "Picture is not return properly.");
        }

        [Fact]
        public async Task Edit_WithCorrectData_ShouldEditServiceCorrectly()
        {
            var errorMessagePrefix = "ServicesService EditAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var expectedResult = dbContext.Services.First().To<ServicesServiceModel>();

            expectedResult.Name = "Name";
            expectedResult.Picture = "Picture";
            expectedResult.Description = "Description";

            await this.servicesService.EditAsync(expectedResult.Id, expectedResult);

            var actualResult = dbContext.Services.First().To<ServicesServiceModel>();

            Assert.True(expectedResult.Name == actualResult.Name, errorMessagePrefix + " " + "Name is not return properly.");
            Assert.True(expectedResult.Description == actualResult.Description, errorMessagePrefix + " " + "Description is not return properly.");
            Assert.True(expectedResult.Picture == actualResult.Picture, errorMessagePrefix + " " + "Picture is not return properly.");
        }

        [Fact]
        public async Task Edit_WithNonExistentServiceId_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var expectedResult = dbContext.Services.First().To<ServicesServiceModel>();

            expectedResult.Name = "Name";
            expectedResult.Picture = "Picture";
            expectedResult.Description = "Description";

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                  await this.servicesService.EditAsync(0, expectedResult));
        }

        [Fact]
        public async Task Delete_WithCorrectData_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ServicesService DeleteByIdAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var testId = dbContext.Services.First().To<ServicesServiceModel>().Id;
            var actualResult = await this.servicesService.DeleteByIdAsync(testId);

            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task Delete_WithCorrectData_ShouldDeleteSuccessfully()
        {
            var errorMessagePrefix = "ServicesService DeleteByIdAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            var testId = dbContext.Services.First().To<ServicesServiceModel>().Id;
            await this.servicesService.DeleteByIdAsync(testId);

            var expectedCount = 1;
            var actualCount = dbContext.Services.Count();

            Assert.True(expectedCount == actualCount, errorMessagePrefix);
        }

        [Fact]
        public async Task Delete_WithOrderData_ShouldDeleteSuccessfully()
        {
            var errorMessagePrefix = "ServicesService DeleteByIdAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            await dbContext.ServiceOrders.AddAsync(new ServiceOrder
            {
                ServiceId = 1,
            });
            await dbContext.SaveChangesAsync();
            this.servicesService = new ServicesService(dbContext);

            var testId = dbContext.Services.First().To<ServicesServiceModel>().Id;

            await this.servicesService.DeleteByIdAsync(testId);

            var expectedCount = 1;
            var actualCount = dbContext.Services.Count();

            Assert.True(expectedCount == actualCount, errorMessagePrefix);
        }

        [Fact]
        public async Task Delete_WithNonExistentServiceId_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.servicesService = new ServicesService(dbContext);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.servicesService.DeleteByIdAsync(3));
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
