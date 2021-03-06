﻿namespace ZazasCleaningService.Services.Models.Products
{
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;

    public class ProductsServiceModel : IMapFrom<Product>, IMapTo<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductTypeId { get; set; }

        public ProductTypesServiceModel ProductType { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
    }
}
