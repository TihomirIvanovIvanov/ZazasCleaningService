namespace ZazasCleaningService.Services.Models
{
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;

    public class ProductsServiceModel : IMapFrom<Product>, IMapTo<Product>
    {
        public int ProductTypeId { get; set; }

        public ProductTypesServiceModel ProductType { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
    }
}
