namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
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
                .FirstOrDefaultAsync(status => status.Name == "Completed");

            this.dbContext.ProductOrders.Update(productOrderFromDb);
            await this.dbContext.SaveChangesAsync();

            return productOrderFromDb.Id;
        }

        public async Task<int> CreateProductOrderAsync(OrderProductsServiceModel orderProductsServiceModel)
        {
            var orderProducts = orderProductsServiceModel.To<ProductOrder>();

            orderProducts.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(orderStatus => orderStatus.Name == "Active");

            await this.dbContext.ProductOrders.AddAsync(orderProducts);
            await this.dbContext.SaveChangesAsync();

            return orderProducts.Id;
        }

        public async Task<int> CreateServiceOrderAsync(OrderServicesServiceModel orderServicesServiceModel)
        {
            var orderServices = orderServicesServiceModel.To<ServiceOrder>();

            orderServices.Status = await this.dbContext.OrderStatuses
                .FirstOrDefaultAsync(orderStatus => orderStatus.Name == "Active");

            await this.dbContext.ServiceOrders.AddAsync(orderServices);
            await this.dbContext.SaveChangesAsync();

            return orderServices.Id;
        }

        public IQueryable<OrderProductsServiceModel> GetAllProductOrdersAsync()
        {
            var productOrders = this.dbContext.ProductOrders
                .Where(productOrders => productOrders.Status.Name == "Active")
                .OrderBy(productOrders => productOrders.CreatedOn)
                .To<OrderProductsServiceModel>();

            return productOrders;
        }

        public IQueryable<OrderServicesServiceModel> GetAllServiceOrdersAsync()
        {
            var serviceOrders = this.dbContext.ServiceOrders
                .Where(productOrders => productOrders.Status.Name == "Active")
                .OrderBy(service => service.CreatedOn)
                .To<OrderServicesServiceModel>();

            return serviceOrders;
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
                .Where(order => order.Status.Name == "Active")
                .ToListAsync();
        }
    }
}
