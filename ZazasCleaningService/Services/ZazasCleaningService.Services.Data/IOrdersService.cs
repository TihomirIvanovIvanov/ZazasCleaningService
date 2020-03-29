namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Orders;

    public interface IOrdersService
    {
        Task<int> CreateOrder(OrdersServiceModel ordersServiceModel);
    }
}
