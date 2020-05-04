namespace ZazasCleaningService.Web.ViewModels.Products.Order
{
    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class AllProductsOrdersViewModel : IMapFrom<OrderProductsServiceModel>, IHaveCustomMappings
    {
        public int ProductOrderId { get; set; }

        public string ProductName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<OrderProductsServiceModel, AllProductsOrdersViewModel>()
                .ForMember(
                    destination => destination.ProductOrderId,
                    options => options.MapFrom(origin => origin.Id));
        }
    }
}
