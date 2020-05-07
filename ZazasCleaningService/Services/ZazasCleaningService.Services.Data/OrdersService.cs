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

        public async Task<int> CreateProductOrderAsync(OrderProductsServiceModel orderProductsServiceModel)
        {
            var orderProducts = orderProductsServiceModel.To<ProductOrder>();

            await this.dbContext.ProductOrders.AddAsync(orderProducts);
            await this.dbContext.SaveChangesAsync();

            return orderProducts.Id;
        }

        public async Task<int> CreateServiceOrderAsync(OrderServicesServiceModel orderServicesServiceModel)
        {
            var orderServices = orderServicesServiceModel.To<ServiceOrder>();

            await this.dbContext.ServiceOrders.AddAsync(orderServices);
            await this.dbContext.SaveChangesAsync();

            return orderServices.Id;
        }

        public IQueryable<OrderProductsServiceModel> GetAllProductOrdersAsync()
        {
            var productOrders = this.dbContext.ProductOrders.To<OrderProductsServiceModel>();

            return productOrders;
        }

        public IQueryable<OrderServicesServiceModel> GetAllServiceOrdersAsync()
        {
            var serviceOrders = this.dbContext.ServiceOrders
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
    }
}
