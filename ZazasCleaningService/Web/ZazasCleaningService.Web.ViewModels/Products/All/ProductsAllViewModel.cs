namespace ZazasCleaningService.Web.ViewModels.Products.All
{
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models;

    public class ProductsAllViewModel : IMapFrom<ProductsServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Desription { get; set; }
    }
}
