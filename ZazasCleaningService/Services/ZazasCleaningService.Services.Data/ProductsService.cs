﻿namespace ZazasCleaningService.Services.Data
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
            var productTypesNameFromDb = await this.GetProductTypeByName(productsServiceModel);

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

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var product = await this.GetProductById(id);
            var productOrder = await this.GetProductOrderByProductId(id);

            if (productOrder != null)
            {
                this.dbContext.ProductOrders.Remove(productOrder);
            }

            product.DeletedOn = DateTime.UtcNow;
            product.IsDeleted = true;

            this.dbContext.Products.Update(product);
            await this.dbContext.SaveChangesAsync();

            return product.IsDeleted;
        }

        public async Task<int> EditAsync(int id, ProductsServiceModel productsServiceModel)
        {
            var productTypeNameFromDb = await this.GetProductTypeByName(productsServiceModel);
            var product = await this.GetProductById(id);

            product.Name = productsServiceModel.Name;
            product.Picture = productsServiceModel.Picture;
            product.Description = productsServiceModel.Description;
            product.ProductType = productTypeNameFromDb;

            this.dbContext.Products.Update(product);
            await this.dbContext.SaveChangesAsync();

            return product.Id;
        }

        public IQueryable<T> GetAllProducts<T>(int? take = null, int skip = 0)
        {
            var allProducts = this.dbContext.Products
                .OrderByDescending(product => product.CreatedOn)
                .Skip(skip);

            if (allProducts == null)
            {
                throw new ArgumentNullException(nameof(allProducts));
            }

            if (take.HasValue)
            {
                allProducts = allProducts.Take(take.Value);
            }

            return allProducts.To<T>();
        }

        public IQueryable<T> GetAllProductTypes<T>()
        {
            var productTypes = this.dbContext.ProductTypes
                .OrderByDescending(type => type.CreatedOn)
                .To<T>();

            if (productTypes == null)
            {
                throw new ArgumentNullException(nameof(productTypes));
            }

            return productTypes;
        }

        public async Task<ProductsServiceModel> GetProductByIdAsync(int id)
        {
            var product = await this.dbContext.Products.To<ProductsServiceModel>()
                .FirstOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            return product;
        }

        public int GetCountProducts()
        {
            var products = this.dbContext.Products.Count();
            return products;
        }

        private async Task<ProductType> GetProductTypeByName(ProductsServiceModel productsServiceModel)
        {
            var productTypeNameFromDb = await this.dbContext.ProductTypes
                .FirstOrDefaultAsync(productType => productType.Name == productsServiceModel.ProductType.Name);

            if (productTypeNameFromDb == null)
            {
                throw new ArgumentNullException(nameof(productTypeNameFromDb));
            }

            return productTypeNameFromDb;
        }

        private async Task<ProductOrder> GetProductOrderByProductId(int productId)
        {
            var productOrder = await this.dbContext.ProductOrders
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            return productOrder;
        }

        private async Task<Product> GetProductById(int id)
        {
            var product = await this.dbContext.Products
                .FirstOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            return product;
        }
    }
}
