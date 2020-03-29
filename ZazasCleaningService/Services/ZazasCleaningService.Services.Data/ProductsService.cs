namespace ZazasCleaningService.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
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

        public async Task<int> CreateProductAsync(ProductsServiceModel productsServiceModel)
        {
            var productTypesNameFromDb = await this.dbContext.ProductTypes
                .FirstOrDefaultAsync(producType => producType.Name == productsServiceModel.ProductType.Name);

            if (productTypesNameFromDb == null)
            {
                throw new ArgumentNullException(nameof(productTypesNameFromDb));
            }

            var product = new Product
            {
                Description = productsServiceModel.Description,
                Picture = productsServiceModel.Picture,
                ProductType = productTypesNameFromDb,
            };

            await this.dbContext.Products.AddAsync(product);
            await this.dbContext.SaveChangesAsync();

            return product.Id;
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

        public IQueryable<ProductsServiceModel> GetAllProducts()
        {
            var allProducts = this.dbContext.Products.To<ProductsServiceModel>();

            return allProducts;
        }

        public IQueryable<ProductTypesServiceModel> GetAllProductTypes()
        {
            var productTypes = this.dbContext.ProductTypes.To<ProductTypesServiceModel>();

            return productTypes;
        }

        public async Task<ProductsServiceModel> GetById(int id)
        {
            var product = await this.dbContext.Products.To<ProductsServiceModel>()
                .FirstOrDefaultAsync(product => product.Id == id);

            return product;
        }
    }
}
