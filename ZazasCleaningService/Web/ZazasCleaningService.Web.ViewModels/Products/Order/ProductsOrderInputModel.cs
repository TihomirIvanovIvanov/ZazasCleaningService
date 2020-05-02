namespace ZazasCleaningService.Web.ViewModels.Products.Order
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;
    using ZazasCleaningService.Services.Models.Products;

    public class ProductsOrderInputModel : IMapFrom<ProductsServiceModel>, IMapTo<OrderProductsServiceModel>, IHaveCustomMappings
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ProductsServiceModel, ProductsOrderInputModel>()
                .ForMember(
                    destination => destination.ProductId,
                    options => options.MapFrom(origin => origin.Id));
        }
    }
}
