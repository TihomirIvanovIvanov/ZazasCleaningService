namespace ZazasCleaningService.Web.ViewModels.Products.Details
{
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models;

    public class ProductsDetailsViewModel : IMapFrom<ProductsServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}
