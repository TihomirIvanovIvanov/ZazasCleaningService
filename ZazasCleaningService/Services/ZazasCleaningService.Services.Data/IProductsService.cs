namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Products;

    public interface IProductsService
    {
        Task<int> CreateProductTypeAsync(string name);

        IQueryable<T> GetAllProductTypesAsync<T>();

        Task<int> CreateProductAsync(ProductsServiceModel productsServiceModel);

        IQueryable<T> GetAllProductsAsync<T>(int? take = null, int skip = 0);

        int GetCountProducts();

        Task<ProductsServiceModel> GetProductByIdAsync(int id);

        Task<int> EditAsync(int id, ProductsServiceModel productsServiceModel);

        Task<bool> DeleteByIdAsync(int id);
    }
}
