namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Models.Orders;
    using ZazasCleaningService.Services.Models.Receipts;

    public interface IOrdersService
    {
        // TODO: Complete thesesteps
        // 1. Add service models
        // 2. Add binding models
        // 3. Add view models and methods for extracting (GetAllServiceOrders() / GetAllProductOrders) (dont forget lazy)
        Task<int> CreateProductOrderAsync(OrderProductsServiceModel orderProductsServiceModel);

        Task<int> CreateServiceOrderAsync(OrderServicesServiceModel orderServicesServiceModel);

        IQueryable<OrderProductsServiceModel> GetAllProductOrdersAsync();

        IQueryable<OrderServicesServiceModel> GetAllServiceOrdersAsync();

        Task<OrderProductsServiceModel> GetProductOrdersByIdAsync(int id);

        Task<OrderServicesServiceModel> GetServiceOrdersByIdAsync(int id);

        Task SetProductOrdersToReceiptAsync(ProductReceipt productReceipt);

        Task<int> CompleteProductOrdersAsync(int productOrderId);
    }
}
