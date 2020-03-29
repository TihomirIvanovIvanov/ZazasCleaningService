namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

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

        public async Task<int> CreateOrder(OrdersServiceModel ordersServiceModel)
        {
            var order = ordersServiceModel.To<Order>();

            await this.dbContext.Orders.AddAsync(order);
            await this.dbContext.SaveChangesAsync();

            return order.Id;
        }
    }
}
