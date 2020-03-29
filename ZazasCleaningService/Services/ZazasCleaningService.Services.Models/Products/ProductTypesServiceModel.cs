namespace ZazasCleaningService.Services.Models.Products
{
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;

    public class ProductTypesServiceModel : IMapFrom<ProductType>, IMapTo<ProductType>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
