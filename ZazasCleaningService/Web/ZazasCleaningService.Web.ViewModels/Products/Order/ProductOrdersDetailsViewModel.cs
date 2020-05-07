namespace ZazasCleaningService.Web.ViewModels.Products.Order
{
    using AutoMapper;
    using System.Security.Cryptography;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class ProductOrdersDetailsViewModel : IMapFrom<OrderProductsServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<OrderProductsServiceModel, ProductOrdersDetailsViewModel>()
                .ForMember(
                    destionation => destionation.Name,
                    options => options.MapFrom(origin => origin.Product.Name))
                .ForMember(
                    destionation => destionation.Picture,
                    options => options.MapFrom(origin => origin.Product.Picture))
                .ForMember(
                    destionation => destionation.Description,
                    options => options.MapFrom(origin => origin.Product.Description));
        }
    }
}
