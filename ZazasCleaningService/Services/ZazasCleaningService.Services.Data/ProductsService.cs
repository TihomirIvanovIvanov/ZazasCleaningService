namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    using ZazasCleaningService.Data;

    public class ProductsService : IProductsService
    {
        public ProductsService(ApplicationDbContext dbContext)
        {

        }

        public Task<int> CreateProductType()
        {
            throw new System.NotImplementedException();
        }
    }
}
