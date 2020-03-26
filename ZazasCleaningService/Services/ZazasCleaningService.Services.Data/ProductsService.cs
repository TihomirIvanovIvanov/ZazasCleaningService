namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;

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
    }
}
