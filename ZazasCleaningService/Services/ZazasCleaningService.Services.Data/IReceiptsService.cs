namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Receipts;

    public interface IReceiptsService
    {
        Task<int> CreateProductReceiptAsync(string recipientId);

        Task<ReceiptProductsServiceModel> GetProductByReceiptIdAsync(int id);

        Task<int> SetIssuedOnPictureToReceiptAsync(ReceiptProductsServiceModel receiptProductsServiceModel);

        Task<int> CreateServiceReceiptAsync(string recipientId);
    }
}
