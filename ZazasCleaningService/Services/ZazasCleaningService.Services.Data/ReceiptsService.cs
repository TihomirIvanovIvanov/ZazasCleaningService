namespace ZazasCleaningService.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Receipts;

    public class ReceiptsService : IReceiptsService
    {
        private readonly ApplicationDbContext dbContext;

        private readonly IOrdersService ordersService;

        public ReceiptsService(ApplicationDbContext dbContext, IOrdersService ordersService)
        {
            this.dbContext = dbContext;
            this.ordersService = ordersService;
        }

        public async Task<int> CreateProductReceiptAsync(string recipientId)
        {
            var productReceipt = new ProductReceipt
            {
                IssuedOnPicture = null,
                RecipientId = recipientId,
            };

            await this.ordersService.SetProductOrdersToReceiptAsync(productReceipt);

            foreach (var productOrder in productReceipt.ProductOrders)
            {
                await this.ordersService.CompleteProductOrdersAsync(productOrder.Id);
            }

            this.dbContext.ProductReceipts.Add(productReceipt);
            await this.dbContext.SaveChangesAsync();

            return productReceipt.Id;
        }

        public Task<int> CreateServiceReceiptAsync(string recipientId)
        {
            throw new NotImplementedException();
        }

        public async Task<ReceiptProductsServiceModel> GetProductByReceiptIdAsync(int id)
        {
            var productReceipt = await this.dbContext.ProductReceipts.To<ReceiptProductsServiceModel>()
                .FirstOrDefaultAsync(receipt => receipt.Id == id);

            return productReceipt;
        }

        public async Task<int> SetIssuedOnPictureToReceiptAsync(ReceiptProductsServiceModel receiptProductsServiceModel)
        {
            var productReceipt = await this.dbContext.ProductReceipts
                .FirstOrDefaultAsync(productReceipt => productReceipt.Id == receiptProductsServiceModel.Id);

            if (productReceipt == null)
            {
                throw new ArgumentNullException(nameof(productReceipt));
            }

            productReceipt.IssuedOnPicture = receiptProductsServiceModel.IssuedOnPicture;

            this.dbContext.ProductReceipts.Update(productReceipt);
            await this.dbContext.SaveChangesAsync();

            return productReceipt.Id;
        }
    }
}
