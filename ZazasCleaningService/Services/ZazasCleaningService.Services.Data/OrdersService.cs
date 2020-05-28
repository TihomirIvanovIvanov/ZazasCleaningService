namespace ZazasCleaningService.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Common;
    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext dbContext;

        public OrdersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> CompleteProductOrdersAsync<T>(int productOrderId)
        {
            var productOrderFromDb = await this.GetProductOrderById(productOrderId);

            // TODO: Validate that the requisted order is existent and with status "Active"
            productOrderFromDb.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(status => status.Name == GlobalConstants.StatusCompleted);

            this.dbContext.ProductOrders.Update(productOrderFromDb);
            await this.dbContext.SaveChangesAsync();

            return productOrderFromDb.Id.To<T>();
        }

        public async Task<T> CompleteServiceOrdersAsync<T>(int serviceOrderId)
        {
            var serviceOrderFromDb = await this.GetServiceOrderById(serviceOrderId);

            // TODO: Validate that the requisted order is existent and with status "Active"
            serviceOrderFromDb.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(status => status.Name == GlobalConstants.StatusCompleted);

            this.dbContext.ServiceOrders.Update(serviceOrderFromDb);
            await this.dbContext.SaveChangesAsync();

            return serviceOrderFromDb.Id.To<T>();
        }

        public async Task<T> CreateProductOrderAsync<T>(OrderProductsServiceModel orderProductsServiceModel)
        {
            var orderProducts = orderProductsServiceModel.To<ProductOrder>();

            orderProducts.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(orderStatus => orderStatus.Name == GlobalConstants.StatusActive);

            await this.dbContext.ProductOrders.AddAsync(orderProducts);
            await this.dbContext.SaveChangesAsync();

            return orderProducts.Id.To<T>();
        }

        public async Task<T> CreateServiceOrderAsync<T>(OrderServicesServiceModel orderServicesServiceModel)
        {
            var orderServices = orderServicesServiceModel.To<ServiceOrder>();

            orderServices.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(orderStatus => orderStatus.Name == GlobalConstants.StatusActive);

            await this.dbContext.ServiceOrders.AddAsync(orderServices);
            await this.dbContext.SaveChangesAsync();

            return orderServices.Id.To<T>();
        }

        public IQueryable<T> GetAllProductOrdersAsync<T>()
        {
            var productOrders = this.dbContext.ProductOrders
                .Where(productOrder => productOrder.Status.Name == GlobalConstants.StatusActive)
                .OrderBy(productOrder => productOrder.Issuer.UserName)
                .ThenBy(productOrder => productOrder.CreatedOn)
                .To<T>();

            return productOrders;
        }

        public IQueryable<T> GetAllServiceOrdersAsync<T>()
        {
            var serviceOrders = this.dbContext.ServiceOrders
                .Where(serviceOrder => serviceOrder.Status.Name == GlobalConstants.StatusActive)
                .OrderBy(serviceOrder => serviceOrder.Issuer.UserName)
                .ThenBy(serviceOrder => serviceOrder.CreatedOn)
                .To<T>();

            return serviceOrders;
        }

        public async Task<string> GetRecipientIdForOrdersAsync()
        {
            var issuerId = await this.dbContext.ProductOrders
                .Select(p => p.IssuerId)
                .FirstOrDefaultAsync();

            return issuerId;
        }

        public async Task<T> GetProductOrdersByIdAsync<T>(int id)
        {
            var productOrderById = await this.dbContext.ProductOrders
                .FirstOrDefaultAsync(productOrder => productOrder.Id == id);

            return productOrderById.To<T>();
        }

        public async Task<T> GetServiceOrdersByIdAsync<T>(int id)
        {
            var serviceOrderById = await this.dbContext.ServiceOrders
                .FirstOrDefaultAsync(serviceOrder => serviceOrder.Id == id);

            return serviceOrderById.To<T>();
        }

        public async Task SetProductOrdersToReceiptAsync(ProductReceipt productReceipt)
        {
            productReceipt.ProductOrders = await this.dbContext.ProductOrders
                .Where(order => order.Status.Name == GlobalConstants.StatusActive)
                .ToListAsync();
        }

        public async Task SetServiceOrdersToReceiptAsync(ServiceReceipt serviceReceipt)
        {
            serviceReceipt.ServiceOrders = await this.dbContext.ServiceOrders
                .Where(order => order.Status.Name == GlobalConstants.StatusActive)
                .ToListAsync();
        }

        private async Task<ProductOrder> GetProductOrderById(int productOrderId)
        {
            var productOrder = await this.dbContext.ProductOrders
                .FirstOrDefaultAsync(order => order.Id == productOrderId);

            if (productOrder == null)
            {
                throw new ArgumentNullException(nameof(productOrder));
            }

            return productOrder;
        }

        private async Task<ServiceOrder> GetServiceOrderById(int serviceOrderId)
        {
            var serviceOrder = await this.dbContext.ServiceOrders
                .FirstOrDefaultAsync(order => order.Id == serviceOrderId);

            if (serviceOrder == null)
            {
                throw new ArgumentNullException(nameof(serviceOrder));
            }

            return serviceOrder;
        }
    }
}
