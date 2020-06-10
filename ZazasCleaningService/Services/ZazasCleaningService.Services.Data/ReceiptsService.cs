namespace ZazasCleaningService.Services.Data
{
    using System;
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

            await this.dbContext.ProductReceipts.AddAsync(productReceipt);
            await this.dbContext.SaveChangesAsync();

            return productReceipt.Id;
        }

        public async Task<int> CreateServiceReceiptAsync(string recipientId)
        {
            var serviceReceipt = new ServiceReceipt
            {
                IssuedOnPicture = null,
                RecipientId = recipientId,
            };

            await this.ordersService.SetServiceOrdersToReceiptAsync(serviceReceipt);

            foreach (var serviceOrder in serviceReceipt.ServiceOrders)
            {
                await this.ordersService.CompleteServiceOrdersAsync(serviceOrder.Id);
            }

            await this.dbContext.ServiceReceipts.AddAsync(serviceReceipt);
            await this.dbContext.SaveChangesAsync();

            return serviceReceipt.Id;
        }

        public IQueryable<ReceiptProductsServiceModel> GetAllProductReceiptsByRecipientIdAsync(string recipientId)
        {
            var receipts = this.dbContext.ProductReceipts
                .Where(receipt => receipt.RecipientId == recipientId)
                .OrderBy(receipt => receipt.CreatedOn)
                .To<ReceiptProductsServiceModel>();

            if (receipts == null)
            {
                throw new ArgumentNullException(nameof(receipts));
            }

            return receipts;
        }

        public IQueryable<ReceiptServicesServiceModel> GetAllServiceReceiptsByRecipientIdAsync(string recipientId)
        {
            var receipts = this.dbContext.ServiceReceipts
                .Where(receipt => receipt.RecipientId == recipientId)
                .OrderBy(receipt => receipt.CreatedOn)
                .To<ReceiptServicesServiceModel>();

            if (receipts == null)
            {
                throw new ArgumentNullException(nameof(receipts));
            }

            return receipts;
        }

        public async Task<ReceiptProductsServiceModel> GetProductByReceiptIdAsync(int id)
        {
            var productReceipt = await this.dbContext.ProductReceipts.To<ReceiptProductsServiceModel>()
                .FirstOrDefaultAsync(receipt => receipt.Id == id);

            if (productReceipt == null)
            {
                throw new ArgumentNullException(nameof(productReceipt));
            }

            return productReceipt;
        }

        public async Task<ReceiptServicesServiceModel> GetServiceByReceiptIdAsync(int id)
        {
            var serviceReceipt = await this.dbContext.ServiceReceipts.To<ReceiptServicesServiceModel>()
                .FirstOrDefaultAsync(receipt => receipt.Id == id);

            if (serviceReceipt == null)
            {
                throw new ArgumentNullException(nameof(serviceReceipt));
            }

            return serviceReceipt;
        }

        public async Task<int> SetIssuedOnPictureToProductReceiptsAsync(ReceiptProductsServiceModel serviceModel)
        {
            var productReceipt = await this.GetProductReceiptById(serviceModel.Id);
            productReceipt.IssuedOnPicture = serviceModel.IssuedOnPicture;

            this.dbContext.ProductReceipts.Update(productReceipt);
            await this.dbContext.SaveChangesAsync();

            return productReceipt.Id;
        }

        public async Task<int> SetIssuedOnPictureToServiceReceiptsAsync(ReceiptServicesServiceModel serviceModel)
        {
            var serviceReceipt = await this.GetServiceReceiptById(serviceModel.Id);
            serviceReceipt.IssuedOnPicture = serviceModel.IssuedOnPicture;

            this.dbContext.ServiceReceipts.Update(serviceReceipt);
            await this.dbContext.SaveChangesAsync();

            return serviceReceipt.Id;
        }

        private async Task<ProductReceipt> GetProductReceiptById(int productsServiceId)
        {
            var productReceipt = await this.dbContext.ProductReceipts
                .FirstOrDefaultAsync(productReceipt => productReceipt.Id == productsServiceId);

            if (productReceipt == null)
            {
                throw new ArgumentNullException(nameof(productReceipt));
            }

            return productReceipt;
        }

        private async Task<ServiceReceipt> GetServiceReceiptById(int servicesServiceId)
        {
            var serviceReceipt = await this.dbContext.ServiceReceipts
                .FirstOrDefaultAsync(serviceReceipt => serviceReceipt.Id == servicesServiceId);

            if (serviceReceipt == null)
            {
                throw new ArgumentNullException(nameof(serviceReceipt));
            }

            return serviceReceipt;
        }
    }
}
