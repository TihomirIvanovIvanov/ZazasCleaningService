﻿namespace ZazasCleaningService.Services.Models.Orders
{
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Products;

    public class OrdersServiceModel : IMapFrom<Order>, IMapTo<Order>
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public ProductsServiceModel Product { get; set; }

        public int ProductTypeId { get; set; }

        public ProductTypesServiceModel ProductType { get; set; }

        public string IssuerId { get; set; }

        public ApplicationUserServiceModel Issuer { get; set; }
    }
}