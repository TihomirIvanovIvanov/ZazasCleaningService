namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    using ZazasCleaningService.Data;
    using ZazasCleaningService.Services.Models.Orders;

    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext dbContext;

        public OrdersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateOrderAsync(OrdersServiceModel ordersServiceModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> CreateProductOrderAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> CreateServiceOrderAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
