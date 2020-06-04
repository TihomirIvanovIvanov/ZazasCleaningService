namespace ZazasCleaningService.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using ZazasCleaningService.Common;
    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Data.Tests.Common;
    using ZazasCleaningService.Services.Models.Orders;

    public class OrdersServiceTests
    {
        private IOrdersService ordersService;

        public OrdersServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task CreateProductOrder_WithCorrectData_ShouldSuccessfullyCreateOrder()
        {
            var errorMessagePrefix = "OrderService CreateProductOrderAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.ordersService = new OrdersService(dbContext);

            var testReceipt = new OrderProductsServiceModel();
            var actualResult = await this.ordersService.CreateProductOrderAsync(testReceipt);

            Assert.True(actualResult == 1, errorMessagePrefix);
        }

        //[Fact]
        //public async Task GetAllProductOrders_WithZeroData_ShouldReturnEmptyResults()
        //{
        //    var errorMessagePrefix = "OrderService GetAllProductOrdersAsync() method does not work properly.";

        //    var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
        //    this.ordersService = new OrdersService(dbContext);

        //    var actualResult = await this.ordersService.GetAllProductOrdersAsync<OrderProductsServiceModel>().ToListAsync();

        //    Assert.True(actualResult.Count == 0, errorMessagePrefix);
        //}

        //[Fact]
        //public async Task GetAllProductOrders_WithDummyData_ShouldReturnCorrectResult()
        //{
        //    var errorMessagePrefix = "OrderService GetAllProductOrdersAsync() method does not work properly.";

        //    var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
        //    await this.SeedData(dbContext);
        //    this.ordersService = new OrdersService(dbContext);

        //    var actualResult = await this.ordersService.GetAllProductOrdersAsync<OrderProductsServiceModel>().ToListAsync();
        //    var expectedResult = this.GetDummyData().To<OrderProductsServiceModel>().ToList();

        //    Assert.True(actualResult.Count == expectedResult.Count, errorMessagePrefix);

        //    //for (int i = 0; i < expectedResult.Count; i++)
        //    //{
        //    //    var expectedEntry = expectedResult[i];
        //    //    var actualEntry = actualResult[i];

        //    //    Assert.True(expectedEntry.Quantity == actualEntry.Quantity, errorMessagePrefix + " " + "Quantity is not returned properly.");
        //    //    Assert.True(expectedEntry.Status.Name == actualEntry.Status.Name, errorMessagePrefix + " " + "Status is not returned properly.");
        //    //}
        //}

        [Fact]
        public async Task CompleteProductOrders_WithExistentId_ShouldSuccessfullyCompleteOrder()
        {
            var errorMessagePrefix = "OrderService CompleteProductOrdersAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.ordersService = new OrdersService(dbContext);

            var testId = dbContext.ProductOrders.First().Id;
            await this.ordersService.CompleteProductOrdersAsync(testId);
            var testOrder = dbContext.ProductOrders.First();

            Assert.True(testOrder.Status.Name == "Completed", errorMessagePrefix);
        }

        [Fact]
        public async Task CompleteProductOrders_WithNonExistentId_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.ordersService = new OrdersService(dbContext);

            var testId = 0;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                  await this.ordersService.CompleteProductOrdersAsync(testId));
        }

        [Fact]
        public async Task CompleteProductOrders_WithNonActiveStatus_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.ordersService = new OrdersService(dbContext);

            var testId = dbContext.ProductOrders
                .FirstOrDefault(order => order.Status.Name != GlobalConstants.StatusActive).Id;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                  await this.ordersService.CompleteProductOrdersAsync(testId));
        }

        [Fact]
        public async Task SetProductOrdersToReceipt_WithCorrectData_ShouldSuccessfullySetOrdersToReceipt()
        {
            var errorMessagePrefix = "OrderService SetProductOrdersToReceiptAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();

            await dbContext.ProductOrders.AddAsync(new ProductOrder
            {
                IssuerId = "1",
                Status = new OrderStatus
                {
                    Name = "Active",
                },
            });
            await dbContext.ProductReceipts.AddAsync(new ProductReceipt
            {
                RecipientId = "1",
            });
            await dbContext.SaveChangesAsync();

            this.ordersService = new OrdersService(dbContext);

            var testReceipt = dbContext.ProductReceipts.First();
            await this.ordersService.SetProductOrdersToReceiptAsync(testReceipt);

            var expectedCountOfOrders = 1;
            var actualCountOfOrders = dbContext.ProductReceipts.First().ProductOrders.Count();

            Assert.True(expectedCountOfOrders == actualCountOfOrders, errorMessagePrefix);
        }

        [Fact]
        public async Task SetProductOrdersToReceipt_WithDifferentOrderRecipientId_ShouldOnlyAddOrdersWithSameIssuerId()
        {
            var errorMessagePrefix = "OrderService SetProductOrdersToReceiptAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();

            await dbContext.ProductOrders.AddAsync(new ProductOrder
            {
                IssuerId = "1",
                Status = new OrderStatus
                {
                    Name = "Active",
                },
            });
            await dbContext.ProductOrders.AddAsync(new ProductOrder
            {
                IssuerId = "2",
                Status = new OrderStatus
                {
                    Name = "Active",
                },
            });
            await dbContext.ProductReceipts.AddAsync(new ProductReceipt
            {
                RecipientId = "1",
            });
            await dbContext.SaveChangesAsync();

            this.ordersService = new OrdersService(dbContext);

            var testReceipt = dbContext.ProductReceipts.First();
            await this.ordersService.SetProductOrdersToReceiptAsync(testReceipt);

            var expectedCountOfOrders = 1;
            var actualCountOfOrders = dbContext.ProductReceipts.First().ProductOrders.Count();

            Assert.True(expectedCountOfOrders == actualCountOfOrders, errorMessagePrefix);
        }

        [Fact]
        public async Task SetProductOrdersToReceipt_WithCompletedOrderStatus_ShouldOnlyAddOrdersWithActiveStatus()
        {
            var errorMessagePrefix = "OrderService SetProductOrdersToReceiptAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();

            await dbContext.ProductOrders.AddAsync(new ProductOrder
            {
                IssuerId = "1",
                Status = new OrderStatus
                {
                    Name = "Active",
                },
            });
            await dbContext.ProductOrders.AddAsync(new ProductOrder
            {
                IssuerId = "1",
                Status = new OrderStatus
                {
                    Name = "Completed",
                },
            });
            await dbContext.ProductReceipts.AddAsync(new ProductReceipt
            {
                RecipientId = "1",
            });
            await dbContext.SaveChangesAsync();

            this.ordersService = new OrdersService(dbContext);

            var testReceipt = dbContext.ProductReceipts.First();
            await this.ordersService.SetProductOrdersToReceiptAsync(testReceipt);

            var expectedCountOfOrders = 1;
            var actualCountOfOrders = dbContext.ProductReceipts.First().ProductOrders.Count();

            Assert.True(expectedCountOfOrders == actualCountOfOrders, errorMessagePrefix);
        }

        [Fact]
        public async Task GetProductOrdersById_WithCorrectId_ShouldReturnSuccessfullyProductOrderId()
        {
            var errorMessagePrefix = "OrderService GetProductOrdersByIdAsync() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.ordersService = new OrdersService(dbContext);

            var testId = dbContext.ProductOrders.First().Id;
            var expectedResult = this.ordersService.GetProductOrdersByIdAsync(testId).Id;
            var actualResult = dbContext.ProductOrders.First().Id;

            Assert.True(expectedResult == actualResult, errorMessagePrefix);
        }

        [Fact]
        public async Task GetProductOrdersById_WithInCorrectId_ShouldThrowArgumentNullException()
        {
            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            this.ordersService = new OrdersService(dbContext);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                  await this.ordersService.GetProductOrdersByIdAsync(0));
        }

        private async Task SeedData(ApplicationDbContext dbContext)
        {
            await dbContext.AddRangeAsync(this.GetDummyData());
            await dbContext.SaveChangesAsync();
        }

        private List<ProductOrder> GetDummyData()
        {
            return new List<ProductOrder>()
            {
                new ProductOrder
                {
                    Quantity = 1,
                    Status = new OrderStatus
                    {
                        Name = "Active",
                    },
                },
                new ProductOrder
                {
                    Quantity = 2,
                    Status = new OrderStatus
                    {
                        Name = "Completed",
                    },
                },
                new ProductOrder
                {
                    Quantity = 3,
                    Status = new OrderStatus
                    {
                        Name = "NonExistent",
                    },
                },
            };
        }
    }
}
