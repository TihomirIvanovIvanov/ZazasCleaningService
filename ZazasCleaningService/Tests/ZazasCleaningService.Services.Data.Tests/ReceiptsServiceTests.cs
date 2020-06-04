namespace ZazasCleaningService.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Xunit;
    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Data.Tests.Common;

    public class ReceiptsServiceTests
    {
        private IReceiptsService receiptsService;

        public ReceiptsServiceTests()
        {
            MapperInitializer.InitializeMapper();
        }

        [Fact]
        public async Task GetAllProductReceiptsByRecipientId_WithDummyData_ShouldReturnCorrectResult()
        {
            var errorMessagePrefix = "ReceiptsService GetAllProductReceiptsByRecipientId() method does not work properly.";

            var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
            await this.SeedData(dbContext);
            this.receiptsService = new ReceiptsService(dbContext, new OrdersService(dbContext));

            var testId = dbContext.ProductReceipts.First().RecipientId;
            this.receiptsService.GetAllProductReceiptsByRecipientId(testId);
            var testReceipt = dbContext.ProductReceipts.First();

            Assert.True(testReceipt.RecipientId == testId, errorMessagePrefix);
        }

        //[Fact]
        //public async Task GetAllProductReceiptsByRecipientId_WithNonExistentId_ShouldThrowArgumentNullException()
        //{
        //    var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();
        //    await this.SeedData(dbContext);
        //    this.receiptsService = new ReceiptsService(dbContext, new OrdersService(dbContext));

        //    Assert.Throws<ArgumentNullException>(() =>
        //         this.receiptsService.GetAllProductReceiptsByRecipientId("3"));
        //}

        //[Fact]
        //public async Task GetAllProductReceiptsByRecipientId_WithCorrectData_ShouldReturnCorrectResult()
        //{
        //    var errorMessagePrefix = "ReceiptsService GetAllProductReceiptsByRecipientId() method does not work properly.";

        //    var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();

        //    await dbContext.Users.AddAsync(new ApplicationUser());
        //    await dbContext.SaveChangesAsync();

        //    await dbContext.ProductReceipts.AddAsync(new ProductReceipt
        //    {
        //        Recipient = dbContext.Users.First(),
        //    });
        //    await dbContext.ProductReceipts.AddAsync(new ProductReceipt
        //    {
        //        Recipient = dbContext.Users.First(),
        //    });
        //    await dbContext.SaveChangesAsync();

        //    this.receiptsService = new ReceiptsService(dbContext, new OrdersService(dbContext));

        //    var testId = dbContext.Users.First().Id;
        //    var actualResult = this.receiptsService.GetAllProductReceiptsByRecipientId(testId).To<ReceiptProductsServiceModel>().ToList();

        //    Assert.True(actualResult.Count == 2, errorMessagePrefix);
        //}

        //[Fact]
        //public async Task GetAllProductReceiptsByRecipientId_WithDifferentRecipientIds_ShouldOnlyReturnThoseWithGivenId()
        //{
        //    var errorMessagePrefix = "ReceiptsService GetAllProductReceiptsByRecipientId() method does not work properly.";

        //    var dbContext = ApplicationDbContextInMemoryFactory.InitializeContext();

        //    await dbContext.Users.AddAsync(new ApplicationUser());
        //    await dbContext.Users.AddAsync(new ApplicationUser());
        //    await dbContext.SaveChangesAsync();

        //    await dbContext.ProductReceipts.AddAsync(new ProductReceipt
        //    {
        //        Recipient = dbContext.Users.First(),
        //    });
        //    await dbContext.ProductReceipts.AddAsync(new ProductReceipt
        //    {
        //        Recipient = dbContext.Users.Last(),
        //    });
        //    await dbContext.SaveChangesAsync();

        //    this.receiptsService = new ReceiptsService(dbContext, new OrdersService(dbContext));

        //    var testId = dbContext.Users.First().Id;
        //    var actualResult = this.receiptsService.GetAllProductReceiptsByRecipientId(testId).ToList().To<ReceiptProductsServiceModel>();

        //    Assert.True(actualResult.Count() == 1, errorMessagePrefix);
        //}

        private async Task SeedData(ApplicationDbContext dbContext)
        {
            await dbContext.AddRangeAsync(this.GetDummyData());
            await dbContext.SaveChangesAsync();
        }

        private List<ProductReceipt> GetDummyData()
        {
            return new List<ProductReceipt>()
            {
                new ProductReceipt
                {
                    IssuedOnPicture = "default",
                    RecipientId = "1",
                },
                new ProductReceipt
                {
                    IssuedOnPicture = "default2",
                    RecipientId = "2",
                },
            };
        }
    }
}
