namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Models.Orders;

    public interface IOrdersService
    {
        Task<int> CreateProductOrderAsync(OrderProductsServiceModel orderProductsServiceModel);

        Task<int> CreateServiceOrderAsync(OrderServicesServiceModel orderServicesServiceModel);

        IQueryable<T> GetAllProductOrdersAsync<T>();

        IQueryable<T> GetAllServiceOrdersAsync<T>();

        Task<T> GetProductOrdersByIdAsync<T>(int id);

        Task<T> GetServiceOrdersByIdAsync<T>(int id);

        Task SetProductOrdersToReceiptAsync(ProductReceipt productReceipt);

        Task<int> CompleteProductOrdersAsync(int productOrderId);

        Task SetServiceOrdersToReceiptAsync(ServiceReceipt serviceReceipt);

        Task<int> CompleteServiceOrdersAsync(int serviceOrderId);
    }
}
