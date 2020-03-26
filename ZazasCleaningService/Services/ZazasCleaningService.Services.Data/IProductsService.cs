namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    public interface IProductsService
    {
        Task<int> CreateProductType();
    }
}
