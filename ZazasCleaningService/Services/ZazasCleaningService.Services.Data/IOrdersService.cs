namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Models.Orders;

    public interface IOrdersService
    {
        Task<T> CreateProductOrderAsync<T>(OrderProductsServiceModel orderProductsServiceModel);

        Task<T> CreateServiceOrderAsync<T>(OrderServicesServiceModel orderServicesServiceModel);

        IQueryable<T> GetAllProductOrdersAsync<T>();

        IQueryable<T> GetAllServiceOrdersAsync<T>();

        Task<T> GetProductOrdersByIdAsync<T>(int id);

        Task<T> GetServiceOrdersByIdAsync<T>(int id);

        Task SetProductOrdersToReceiptAsync(ProductReceipt productReceipt);

        Task<T> CompleteProductOrdersAsync<T>(int productOrderId);

        Task SetServiceOrdersToReceiptAsync(ServiceReceipt serviceReceipt);

        Task<T> CompleteServiceOrdersAsync<T>(int serviceOrderId);
    }
}
