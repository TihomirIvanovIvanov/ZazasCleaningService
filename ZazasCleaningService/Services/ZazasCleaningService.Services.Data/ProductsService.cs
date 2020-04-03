namespace ZazasCleaningService.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Products;

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

            var product = AutoMapperConfig.MapperInstance.Map<Product>(productsServiceModel);
            product.ProductType = productTypesNameFromDb;

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

        public async Task<int> Edit(int id, ProductsServiceModel productsServiceModel)
        {
            var productTypeNameFromDb = await this.dbContext.ProductTypes
                .FirstOrDefaultAsync(productType => productType.Name == productsServiceModel.ProductType.Name);

            if (productTypeNameFromDb == null)
            {
                throw new ArgumentNullException(nameof(productTypeNameFromDb));
            }

            var product = await this.dbContext.Products.FirstOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            product.Name = productsServiceModel.Name;
            product.Picture = productsServiceModel.Picture;
            product.Description = productsServiceModel.Description;
            product.ProductType = productTypeNameFromDb;

            this.dbContext.Products.Update(product);
            await this.dbContext.SaveChangesAsync();

            return product.Id;
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
