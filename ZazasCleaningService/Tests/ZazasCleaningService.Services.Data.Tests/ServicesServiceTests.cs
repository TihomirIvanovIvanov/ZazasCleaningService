namespace ZazasCleaningService.Services.Data.Tests
{
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

<<<<<<< HEAD
        //[Fact]
        //public async Task GetAllServices_WithDummyData_ShouldReturnCorrectResult()
        //{
        //    var errorMessagePrefix = "ServicesService GetAllServicesAsync() method does not work properly.";

        //    var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
        //    await this.SeedData(dbContext);
        //    this.servicesService = new ServicesService(dbContext);

        //    var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>().ToListAsync();
        //    var expectedResult = this.GetDummyData().To<ServicesServiceModel>().ToList();

        //    Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);

        //    // TODO:
        //    // for (int i = 0; i < expectedResult.Count; i++)
        //    // {
        //    //     var expectedEntry = expectedResult[i];
        //    //     var actualEntry = actualResult[i];
        //    //     Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not return  properly.");
        //    //     Assert.True(expectedEntry.Description == actualEntry.Description, errorMessagePrefix + " " + "Description is  not return properly.");
        //    //     Assert.True(expectedEntry.Picture == actualEntry.Picture, errorMessagePrefix + " " + "Picture is not return  properly.");
        //    // }
        //}

        // TODO: ShouldThrowException
        //[Fact]
        //public async Task GetAllProducts_WithZeroData_ShouldReturnEmptyResult()
        //{
        //    var errorMessagePrefix = "ServicesService GetAllServicesAsync() method does not work properly.";

        //    var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
        //    this.servicesService = new ServicesService(dbContext);

        //    var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>().ToListAsync();

        //    Assert.True(actualResult.Count == 0, errorMessagePrefix);
        //}

        //[Fact]
        //public async Task GetAllServices_WithDummyDataTakeOneSkipOne_ReturnCorrectResult()
        //{
        //    var errorMessagePrefix = "ServicesService GetAllServicesAsync() method does not work properly.";

        //    var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
        //    await this.SeedData(dbContext);
        //    this.servicesService = new ServicesService(dbContext);

        //    var actualResult = await this.servicesService.GetAllServicesAsync<ServicesServiceModel>(1, 1).ToListAsync();
        //    var expectedResult = this.GetDummyData().To<ServicesServiceModel>().Skip(1).Take(1).ToList();

        //    Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        //}
=======
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
>>>>>>> d6348306decbd02373a7241aa6a727327bba353d

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
