namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models;

    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext dbContext;

        public ProductsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateProductTypeAsync(string name)
        {
            var productType = new ProductType
            {
                Name = name,
            };

            await this.dbContext.AddAsync(productType);
            await this.dbContext.SaveChangesAsync();

            return productType.Id;
        }

        public IQueryable<ProductTypesServiceModel> GetAllProductTypes()
        {
            var productTypes = this.dbContext.ProductTypes.To<ProductTypesServiceModel>();

            return productTypes;
        }
    }
}
