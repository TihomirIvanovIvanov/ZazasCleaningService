namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Products;

    public interface IProductsService
    {
        Task<int> CreateProductTypeAsync(string name);

        IQueryable<ProductTypesServiceModel> GetAllProductTypesAsync();

        Task<int> CreateProductAsync(ProductsServiceModel productsServiceModel);

        IQueryable<T> GetAllProductsAsync<T>();

        Task<ProductsServiceModel> GetByIdAsync(int id);

        Task<int> EditAsync(int id, ProductsServiceModel productsServiceModel);

        Task<bool> DeleteByIdAsync(int id);
    }
}
