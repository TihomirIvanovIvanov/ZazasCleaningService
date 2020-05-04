namespace ZazasCleaningService.Web.ViewModels
{
    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class AllProductServiceOrdersViewModel : IMapFrom<OrderProductsServiceModel>, IHaveCustomMappings
    {
        public int ProductOrderId { get; set; }

        public string ProductName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<OrderProductsServiceModel, AllProductServiceOrdersViewModel>()
                .ForMember(
                    destination => destination.ProductOrderId,
                    options => options.MapFrom(origin => origin.Id))
                .ForMember(
                    destination => destination.ProductName,
                    options => options.MapFrom(origin => origin.Product.Name));
        }
    }
}
