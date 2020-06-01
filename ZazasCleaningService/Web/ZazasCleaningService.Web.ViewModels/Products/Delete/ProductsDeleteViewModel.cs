namespace ZazasCleaningService.Web.ViewModels.Products.Delete
{
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Products;

    public class ProductsDeleteViewModel : IMapFrom<ProductsServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string ProductTypeName { get; set; }

        public string Description { get; set; }
    }
}
