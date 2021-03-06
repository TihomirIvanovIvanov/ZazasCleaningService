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
    using ZazasCleaningService.Services.Models.Products;

    public class ProductsServiceTests
    {
        private IProductsService productsService;

        public ProductsServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task GetAllProducts_WithDummyData_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService GetAllProductsAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProducts<ProductsServiceModel>().ToListAsync();
            var expectedResult = this.GetDummyData().To<ProductsServiceModel>().ToList();

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
        public async Task GetAllProducts_WithZeroData_ShouldReturnEmptyResult()
        {
            var errorMessagePrefix = "ProductsService GetAllProductsAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProducts<ProductsServiceModel>().ToListAsync();

            Assert.True(actualResult.Count == 0, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllProducts_WithDummyDataTakeOneSkipOne_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService GetAllProductsAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProducts<ProductsServiceModel>(1, 1).ToListAsync();
            var expectedResult = this.GetDummyData().To<ProductsServiceModel>().Skip(1).Take(1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllProducts_WithDummyDataTakeOneSkipZero_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService GetAllProductsAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProducts<ProductsServiceModel>(1, 0).ToListAsync();
            var expectedResult = this.GetDummyData().To<ProductsServiceModel>().Take(1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllProducts_WithDummyDataTakeZeroSkipOne_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService GetAllProductsAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProducts<ProductsServiceModel>(0, 1).ToListAsync();
            var expectedResult = this.GetDummyData().To<ProductsServiceModel>().Take(0).Skip(1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllProducts_WithDummyDataTakeZeroSkipZero_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService GetAllProductsAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProducts<ProductsServiceModel>(0, 0).ToListAsync();
            var expectedResult = this.GetDummyData().To<ProductsServiceModel>().Take(0).Skip(0).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllProducts_WithDummyDataNegativeTakeAndNegativeSkip_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService GetAllProductsAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProducts<ProductsServiceModel>(-1, -1).ToListAsync();
            var expectedResult = this.GetDummyData().To<ProductsServiceModel>().Take(-1).Skip(-1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllProducts_WithDummyDataNegativeTakeAndSkipOne_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService GetAllProductsAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProducts<ProductsServiceModel>(-1, 1).ToListAsync();
            var expectedResult = this.GetDummyData().To<ProductsServiceModel>().Take(-1).Skip(1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        [Fact]
        public async Task GetAllProducts_WithDummyDataTakeOneAndNegativeSkip_ReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService GetAllProductsAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProducts<ProductsServiceModel>(1, -1).ToListAsync();
            var expectedResult = this.GetDummyData().To<ProductsServiceModel>().Take(1).Skip(-1).ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);
        }

        // TODO:
        // [Fact]
        // public async Task GetAllProducts_ZeroData_ShouldThrowArgumentNullException()
        // {
        //     var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
        //     this.productsService = new ProductsService(dbContext);
        //     await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        //           await this.productsService.GetAllProductsAsync<ProductsServiceModel>().ToListAsync());
        // }
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

        [Fact]
        public async Task GetAllProductTypes_WithDummyData_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService GetAllProductTypesAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProductTypes<ProductTypesServiceModel>().ToListAsync();
            var expectedResult = this.GetDummyData().Select(p => p.ProductType).To<ProductTypesServiceModel>().ToList();

            Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);

            // TODO:
            // for (int i = 0; i < expectedResult.Count; i++)
            // {
            //     var expectedEntry = expectedResult[i];
            //     var actualEntry = actualResult[i];
            //     Assert.True(expectedEntry.Name == actualEntry.Name, errorMessagePrefix + " " + "Name is not returned  properly.");
            // }
        }

        [Fact]
        public async Task GetAllProductTypes_WithZeroData_ShouldReturnEmptyResult()
        {
            var errorMessagePrefix = "ProductsService GetAllProductTypesAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.GetAllProductTypes<ProductTypesServiceModel>().ToListAsync();

            Assert.True(actualResult.Count == 0, errorMessagePrefix);
        }

        //[Fact]
        //public async Task GetAllProductTypes_WithZeroData_ShouldThrowArgumentNullException()
        //{
        //    var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
        //    this.productsService = new ProductsService(dbContext);

        //    await Assert.ThrowsAsync<ArgumentNullException>(async () =>
        //          await this.productsService.GetAllProductTypesAsync<ProductTypesServiceModel>().ToListAsync());
        //}

        [Fact]
        public async Task CreateProductTypes_WithCorrectData_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService CreateProductTypeAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.CreateProductTypeAsync("food");

            Assert.True(actualResult == 1, errorMessagePrefix);
        }

        [Fact]
        public async Task CreateProductTypes_WithEmptyData_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService CreateProductTypeAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.CreateProductTypeAsync(string.Empty);

            Assert.True(actualResult == 1, errorMessagePrefix);
        }

        [Fact]
        public async Task CreateProductTypes_WithNull_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService CreateProductTypeAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.productsService = new ProductsService(dbContext);

            var actualResult = await this.productsService.CreateProductTypeAsync(null);

            Assert.True(actualResult == 1, errorMessagePrefix);
        }

        //[Fact]
        //public async Task Edit_WithCorrectData_ShouldReturnCorrectResult()
        //{
        //    var errorMessagePrefix = "ProductsService EditAsync() method does not work properly.";

        //    var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
        //    await this.SeedData(dbContext);
        //    this.productsService = new ProductsService(dbContext);

        //    var expectedResult = dbContext.Products.First().To<ProductsServiceModel>();
        //    var actualResult = await this.productsService.EditAsync(expectedResult.Id, expectedResult);

        //    Assert.True(expectedResult.Id == actualResult.To<ProductsServiceModel>().Id, errorMessagePrefix + " " + "Id is not return properly.");
        //    Assert.True(expectedResult.Name == actualResult.To<ProductsServiceModel>().Name, errorMessagePrefix + " " + "Name is not return properly.");
        //    Assert.True(expectedResult.Description == actualResult.To<ProductsServiceModel>().Description, errorMessagePrefix + " " + "Description is not return properly.");
        //    Assert.True(expectedResult.Picture == actualResult.To<ProductsServiceModel>().Picture, errorMessagePrefix + " " + "Picture is not return properly.");
        //    Assert.True(expectedResult.ProductType.Name == actualResult.To<ProductsServiceModel>().ProductType.Name, errorMessagePrefix + " " + "ProductType Name is not return properly.");
        //}

        [Fact]
        public async Task Edit_WithCorrectData_ShouldEditProductCorrectly()
        {
            var errorMessagePrefix = "ProductsService EditAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var expectedResult = dbContext.Products.First().To<ProductsServiceModel>();

            expectedResult.Name = "Name";
            expectedResult.Picture = "Picture";
            expectedResult.Description = "Description";
            expectedResult.ProductType = dbContext.ProductTypes.Last().To<ProductTypesServiceModel>();

            await this.productsService.EditAsync(expectedResult.Id, expectedResult);

            var actualResult = dbContext.Products.First().To<ProductsServiceModel>();

            Assert.True(expectedResult.Name == actualResult.Name, errorMessagePrefix + " " + "Name is not return properly.");
            Assert.True(expectedResult.Description == actualResult.Description, errorMessagePrefix + " " + "Description is not return properly.");
            Assert.True(expectedResult.Picture == actualResult.Picture, errorMessagePrefix + " " + "Picture is not return properly.");
            Assert.True(expectedResult.ProductType.Name == actualResult.ProductType.Name, errorMessagePrefix + " " + "ProductType Name is not return properly.");
        }

        [Fact]
        public async Task Edit_WithNonExistentProductType_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var expectedResult = dbContext.Products.First().To<ProductsServiceModel>();

            expectedResult.Name = "Name";
            expectedResult.Picture = "Picture";
            expectedResult.Description = "Description";
            expectedResult.ProductType = new ProductTypesServiceModel
            {
                Name = "NonExistent",
            };

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                  await this.productsService.EditAsync(expectedResult.Id, expectedResult));
        }

        [Fact]
        public async Task Edit_WithNonExistentProductId_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var expectedResult = dbContext.Products.First().To<ProductsServiceModel>();

            expectedResult.Name = "Name";
            expectedResult.Picture = "Picture";
            expectedResult.Description = "Description";
            expectedResult.ProductType = dbContext.ProductTypes.Last().To<ProductTypesServiceModel>();

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                  await this.productsService.EditAsync(3, expectedResult));
        }

        [Fact]
        public async Task Delete_WithCorrectData_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ProductsService DeleteByIdAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var testId = dbContext.Products.First().To<ProductsServiceModel>().Id;
            var actualResult = await this.productsService.DeleteByIdAsync(testId);

            Assert.True(actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task Delete_WithCorrectData_ShouldDeleteSuccessfully()
        {
            var errorMessagePrefix = "ProductsService DeleteByIdAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var testId = dbContext.Products.First().To<ProductsServiceModel>().Id;
            await this.productsService.DeleteByIdAsync(testId);

            var expectedCount = 1;
            var actualCount = dbContext.Products.Count();

            Assert.True(expectedCount == actualCount, errorMessagePrefix);
        }

        [Fact]
        public async Task Delete_WithOrderData_ShouldDeleteSuccessfully()
        {
            var errorMessagePrefix = "ProductsService DeleteByIdAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            await dbContext.ProductOrders.AddAsync(new ProductOrder
            {
                ProductId = 1,
            });
            await dbContext.SaveChangesAsync();
            this.productsService = new ProductsService(dbContext);

            var testId = dbContext.Products.First().To<ProductsServiceModel>().Id;

            await this.productsService.DeleteByIdAsync(testId);

            var expectedCount = 1;
            var actualCount = dbContext.Products.Count();

            Assert.True(expectedCount == actualCount, errorMessagePrefix);
        }

        [Fact]
        public async Task Delete_WithNonExistentProductId_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.productsService.DeleteByIdAsync(3));
        }

        [Fact]
        public async Task GetAllProductsCount_WithDummyData_ShoultReturnCorrectResult()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.productsService = new ProductsService(dbContext);

            var expectedResult = dbContext.Products.Count();
            var actualResult = this.productsService.GetCountProducts();

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetAllProductsCount_WithNoData_ShoultThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.productsService = new ProductsService(dbContext);

            Assert.Throws<ArgumentNullException>(() => this.productsService.GetCountProducts());
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
                        CreatedOn = DateTime.UtcNow.AddDays(10),
                    },
                    CreatedOn = DateTime.UtcNow.AddDays(5),
                },
                new Product
                {
                    Name = "food product",
                    Picture = "default",
                    Description = "food product desc",
                    ProductType = new ProductType
                    {
                        Name = "food",
                        CreatedOn = DateTime.UtcNow.AddDays(15),
                    },
                    CreatedOn = DateTime.UtcNow.AddDays(10),
                },
            };
        }
    }
}
