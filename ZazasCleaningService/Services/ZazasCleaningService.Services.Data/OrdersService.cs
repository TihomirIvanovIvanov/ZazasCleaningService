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

        public async Task<int> CompleteProductOrdersAsync(int productOrderId)
        {
            var productOrderFromDb = await this.GetProductOrderById(productOrderId);

            if (productOrderFromDb.Status.Name != GlobalConstants.StatusActive)
            {
                throw new ArgumentNullException(nameof(productOrderFromDb));
            }

            productOrderFromDb.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(status => status.Name == GlobalConstants.StatusCompleted);

            this.dbContext.ProductOrders.Update(productOrderFromDb);
            await this.dbContext.SaveChangesAsync();

            return productOrderFromDb.Id;
        }

        public async Task<int> CompleteServiceOrdersAsync(int serviceOrderId)
        {
            var serviceOrderFromDb = await this.GetServiceOrderById(serviceOrderId);

            // TODO: Validate that the requisted order is existent and with status "Active"
            serviceOrderFromDb.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(status => status.Name == GlobalConstants.StatusCompleted);

            this.dbContext.ServiceOrders.Update(serviceOrderFromDb);
            await this.dbContext.SaveChangesAsync();

            return serviceOrderFromDb.Id;
        }

        public async Task<int> CreateProductOrderAsync(OrderProductsServiceModel orderProductsServiceModel)
        {
            var orderProducts = orderProductsServiceModel.To<ProductOrder>();

            orderProducts.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(orderStatus => orderStatus.Name == GlobalConstants.StatusActive);

            await this.dbContext.ProductOrders.AddAsync(orderProducts);
            await this.dbContext.SaveChangesAsync();

            return orderProducts.Id;
        }

        public async Task<int> CreateServiceOrderAsync(OrderServicesServiceModel orderServicesServiceModel)
        {
            var orderServices = orderServicesServiceModel.To<ServiceOrder>();
            this.IsInService(orderServices);

            orderServices.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(orderStatus => orderStatus.Name == GlobalConstants.StatusActive);

            await this.dbContext.ServiceOrders.AddAsync(orderServices);
            await this.dbContext.SaveChangesAsync();

            return orderServices.Id;
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

        public async Task<OrderProductsServiceModel> GetProductOrdersByIdAsync(int id)
        {
            var productOrderById = await this.dbContext.ProductOrders
                .To<OrderProductsServiceModel>()
                .FirstOrDefaultAsync(productOrder => productOrder.Id == id);

            if (productOrderById == null)
            {
                throw new ArgumentNullException(nameof(productOrderById));
            }

            return productOrderById;
        }

        public async Task<OrderServicesServiceModel> GetServiceOrdersByIdAsync(int id)
        {
            var serviceOrderById = await this.dbContext.ServiceOrders
                .To<OrderServicesServiceModel>()
                .FirstOrDefaultAsync(serviceOrder => serviceOrder.Id == id);

            return serviceOrderById;
        }

        public async Task SetProductOrdersToReceiptAsync(ProductReceipt productReceipt)
        {
            productReceipt.ProductOrders = await this.dbContext.ProductOrders
                .Where(order => order.Status.Name == GlobalConstants.StatusActive
                && order.IssuerId == productReceipt.RecipientId)
                .ToListAsync();
        }

        public async Task SetServiceOrdersToReceiptAsync(ServiceReceipt serviceReceipt)
        {
            serviceReceipt.ServiceOrders = await this.dbContext.ServiceOrders
                .Where(order => order.Status.Name == GlobalConstants.StatusActive
                && order.IssuerId == serviceReceipt.RecipientId)
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

        private void IsInService(ServiceOrder orderServices)
        {
            var allServiceOrders = this.GetAllServiceOrdersAsync<OrderServicesServiceModel>();

            foreach (var reservedDateTime in allServiceOrders)
            {
                // FROM - 1 TO - 5
                if (orderServices.From >= reservedDateTime.From && orderServices.To <= reservedDateTime.To)
                {
                    throw new Exception();
                }

                // 12-14 + 12-13(CAN)
                else if (orderServices.From <= reservedDateTime.From && orderServices.To > reservedDateTime.From)
                {
                    throw new Exception();
                }

                // 16 - 18 + 17-18(CAN)
                else if (orderServices.From <= reservedDateTime.To && orderServices.To >= reservedDateTime.To)
                {
                    throw new Exception();
                }
            }
        }
    }
}
