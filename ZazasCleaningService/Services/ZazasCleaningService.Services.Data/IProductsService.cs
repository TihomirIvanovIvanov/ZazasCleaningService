namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Products;

    public interface IProductsService
    {
        Task<T> CreateProductTypeAsync<T>(string name);

        IQueryable<T> GetAllProductTypesAsync<T>();

        Task<T> CreateProductAsync<T>(ProductsServiceModel productsServiceModel);

        IQueryable<T> GetAllProductsAsync<T>(int? take = null, int skip = 0);

        int GetCountProducts();

        Task<ProductsServiceModel> GetProductByIdAsync(int id);

        Task<T> EditAsync<T>(int id, ProductsServiceModel productsServiceModel);

        Task<T> DeleteByIdAsync<T>(int id);
    }
}
