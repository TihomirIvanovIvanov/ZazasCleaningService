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
    using ZazasCleaningService.Services.Models.Products;

    public class ProductsServiceTests
    {
        private IProductsService productsService;

        public ProductsServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task GetAllProducts_WithDummyData_ShouldReturnCorrectResults()
        {
            var errorMessagePrefix = "ProductsService GetAllProductsAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProductsAsync<ProductsServiceModel>().ToListAsync();
            var expectedResult = this.GetDummyData().To<ProductsServiceModel>().ToList();

            for (int i = 0; i < expectedResult.Count; i++)
            {
                var expectedEntry = expectedResult[i];
                var actualEntry = actualResult[i];

                Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not return properly.");
                Assert.True(expectedEntry.Description == actualEntry.Description, errorMessagePrefix + " " + "Description is not return properly.");
                Assert.True(expectedEntry.Picture == actualEntry.Picture, errorMessagePrefix + " " + "Picture is not return properly.");
                Assert.True(expectedEntry.ProductType.Name == actualEntry.ProductType.Name, errorMessagePrefix + " " + "ProductType Name is not return properly.");
            }
        }

        [Fact]
        public async Task GetAllProducts_WithZeroData_ShouldReturnEmptyResults()
        {
            var errorMessagePrefix = "ProductsService GetAllProductsAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProductsAsync<ProductsServiceModel>().ToListAsync();

            Assert.True(actualResult.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetById_WithExistentId_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService GetProductByIdAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var expectedResult = dbContext.Products.First().To<ProductsServiceModel>();
            var actualResult = await this.productsService.GetProductByIdAsync(expectedResult.Id);

            Assert.True(expectedResult.Id == actualResult.Id, errorMessagePrefix + " " + "Id is not return properly.");
            Assert.True(expectedResult.Name == actualResult.Name, errorMessagePrefix + " " + "Name is not return properly.");
            Assert.True(expectedResult.Description == actualResult.Description, errorMessagePrefix + " " + "Description is not return properly.");
            Assert.True(expectedResult.Picture == actualResult.Picture, errorMessagePrefix + " " + "Picture is not return properly.");
            Assert.True(expectedResult.ProductType.Name == actualResult.ProductType.Name, errorMessagePrefix + " " + "ProductType Name is not return properly.");
        }

        [Fact]
        public async Task GetById_WithNonExistentId_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.productsService.GetProductByIdAsync(0));
        }

        [Fact]
        public async Task Create_WithCorrectData_ShouldSuccsessfullyCreate()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var testProductService = new ProductsServiceModel
            {
                Name = "cleaning",
                Description = "cleaning desc",
                Picture = "default",
                ProductType = new ProductTypesServiceModel
                {
                    Name = "cleaning",
                },
            };

            var expectedResultId = 3;
            var actualResultId = await this.productsService.CreateProductAsync(testProductService);

            Assert.Equal(actualResultId, expectedResultId);
        }

        [Fact]
        public async Task Create_WithNonExistentProductType_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var testProductService = new ProductsServiceModel
            {
                Name = "cleaning",
                Description = "cleaning desc",
                Picture = "default",
                ProductType = new ProductTypesServiceModel
                {
                    Name = "nonExistent",
                },
            };

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                  await this.productsService.CreateProductAsync(testProductService));
        }

        private async Task SeedData(ApplicationDbContext dbContext)
        {
            await dbContext.AddRangeAsync(this.GetDummyData());
            await dbContext.SaveChangesAsync();
        }

        private List<Product> GetDummyData()
        {
            return new List<Product>()
            {
                new Product
                {
                    Name = "cleaning product",
                    Picture = "default",
                    Description = "cleaning product desc",
                    ProductType = new ProductType
                    {
                        Name = "cleaning",
                    },
                },
                new Product
                {
                    Name = "food product",
                    Picture = "default",
                    Description = "food product desc",
                    ProductType = new ProductType
                    {
                        Name = "food",
                    },
                },
            };
        }
    }
}
