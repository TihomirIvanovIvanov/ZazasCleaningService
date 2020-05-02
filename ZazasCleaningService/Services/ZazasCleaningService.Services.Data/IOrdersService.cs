namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Orders;

    public interface IOrdersService
    {
        // TODO: Complete thesesteps
        // 1. Add service models
        // 2. Add binding models
        // 3. Add view models and methods for extracting (GetAllServiceOrders() / GetAllProductOrders) (dont forget lazy)
        Task<int> CreateProductOrderAsync();

        Task<int> CreateServiceOrderAsync();

        Task<int> CreateOrderAsync(OrdersServiceModel ordersServiceModel);
    }
}
