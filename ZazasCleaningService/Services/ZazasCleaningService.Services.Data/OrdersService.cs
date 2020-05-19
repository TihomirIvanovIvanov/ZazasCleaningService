namespace ZazasCleaningService.Services.Data
{
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
            var productOrderFromDb = await this.dbContext.ProductOrders
                .FirstOrDefaultAsync(order => order.Id == productOrderId);

            // TODO: Validate that the requisted order is existent and with status "Active"
            productOrderFromDb.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(status => status.Name == GlobalConstants.StatusCompleted);

            this.dbContext.ProductOrders.Update(productOrderFromDb);
            await this.dbContext.SaveChangesAsync();

            return productOrderFromDb.Id;
        }

        public async Task<int> CompleteServiceOrdersAsync(int serviceOrderId)
        {
            var serviceOrderFromDb = await this.dbContext.ServiceOrders
                .FirstOrDefaultAsync(order => order.Id == serviceOrderId);

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

            orderServices.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(orderStatus => orderStatus.Name == GlobalConstants.StatusActive);

            await this.dbContext.ServiceOrders.AddAsync(orderServices);
            await this.dbContext.SaveChangesAsync();

            return orderServices.Id;
        }

        public IQueryable<OrderProductsServiceModel> GetAllProductOrdersAsync()
        {
            var productOrders = this.dbContext.ProductOrders
                .Where(productOrders => productOrders.Status.Name == GlobalConstants.StatusActive)
                .OrderBy(productOrders => productOrders.CreatedOn)
                .To<OrderProductsServiceModel>();

            return productOrders;
        }

        public IQueryable<OrderServicesServiceModel> GetAllServiceOrdersAsync()
        {
            var serviceOrders = this.dbContext.ServiceOrders
                .Where(productOrders => productOrders.Status.Name == GlobalConstants.StatusActive)
                .OrderBy(service => service.CreatedOn)
                .To<OrderServicesServiceModel>();

            return serviceOrders;
        }

        public async Task<string> GetRecipientIdForOrdersAsync()
        {
            var issuerId = await this.dbContext.ProductOrders
                .Select(p => p.IssuerId)
                .FirstOrDefaultAsync();

            return issuerId;
        }

        public async Task<OrderProductsServiceModel> GetProductOrdersByIdAsync(int id)
        {
            var productOrderById = await this.dbContext.ProductOrders.To<OrderProductsServiceModel>()
                .FirstOrDefaultAsync(productOrder => productOrder.Id == id);

            return productOrderById;
        }

        public async Task<OrderServicesServiceModel> GetServiceOrdersByIdAsync(int id)
        {
            var serviceOrderById = await this.dbContext.ServiceOrders.To<OrderServicesServiceModel>()
                .FirstOrDefaultAsync(serviceOrder => serviceOrder.Id == id);

            return serviceOrderById;
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
    }
}
