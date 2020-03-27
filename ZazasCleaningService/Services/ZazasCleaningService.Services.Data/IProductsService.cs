namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models;

    public interface IProductsService
    {
        Task<int> CreateProductTypeAsync(string name);

        IQueryable<ProductTypesServiceModel> GetAllProductTypes();
    }
}
