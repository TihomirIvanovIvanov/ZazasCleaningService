namespace ZazasCleaningService.Web.ViewModels.Products.Order
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;
    using ZazasCleaningService.Services.Models.Products;

    public class ProductsOrderInputModel : IMapTo<OrdersServiceModel>, IHaveCustomMappings
    {
        public int ProductId { get; set; }

        public int ProductTypeId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ProductsOrderInputModel, OrdersServiceModel>()
                .ForMember(
                    destination => destination.Product,
                    options => options.MapFrom(origin => new ProductsServiceModel
                    {
                        Id = origin.ProductId,
                    }));

            configuration
                .CreateMap<ProductsOrderInputModel, OrdersServiceModel>()
                .ForMember(
                    destination => destination.ProductType,
                    options => options.MapFrom(origin => new ProductTypesServiceModel
                    {
                        Id = origin.ProductTypeId,
                    }));
        }
    }
}
