namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Receipts;

    public interface IReceiptsService
    {
        Task<int> CreateProductReceiptAsync(string recipientId);

        Task<ReceiptProductsServiceModel> GetProductByReceiptIdAsync(int id);

        Task<int> SetIssuedOnPictureToProductReceiptsAsync(ReceiptProductsServiceModel receiptProductsServiceModel);

        Task<int> CreateServiceReceiptAsync(string recipientId);

        Task<ReceiptServicesServiceModel> GetServiceByReceiptIdAsync(int id);

        Task<int> SetIssuedOnPictureToServiceReceiptsAsync(ReceiptServicesServiceModel receiptServicesServiceModel);

        IQueryable<ReceiptProductsServiceModel> GetAllProductReceiptsByRecipientIdAsync(string recipientId);

        IQueryable<ReceiptServicesServiceModel> GetAllServiceReceiptsByRecipientIdAsync(string recipientId);
    }
}
