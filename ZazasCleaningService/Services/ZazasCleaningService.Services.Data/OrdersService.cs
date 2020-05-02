﻿namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class OrdersService : IOrdersService
    {
        private readonly ApplicationDbContext dbContext;

        public OrdersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateProductOrderAsync(OrderProductsServiceModel orderProductsServiceModel)
        {
            var orderProducts = orderProductsServiceModel.To<ProductOrder>();

            /// TODO: Map other data

            await this.dbContext.ProductOrders.AddAsync(orderProducts);
            await this.dbContext.SaveChangesAsync();

            return orderProducts.Id;
        }
    }
}
