namespace ZazasCleaningService.Web.ViewModels.Products.Delete
{
    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Products;

    public class ProductsDeleteViewModel : IMapFrom<ProductsServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string ProductTypeName { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ProductsDeleteViewModel, ProductsServiceModel>()
                .ForMember(
                    destination => destination.ProductType,
                    options => options.MapFrom(origin => new ProductTypesServiceModel
                    {
                        Name = origin.ProductTypeName,
                    }));
        }
    }
}
