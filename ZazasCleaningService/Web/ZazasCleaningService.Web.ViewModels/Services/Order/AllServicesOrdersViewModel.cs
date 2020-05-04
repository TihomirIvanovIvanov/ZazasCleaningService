namespace ZazasCleaningService.Web.ViewModels.Services.Order
{
    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class AllServicesOrdersViewModel : IMapFrom<OrderServicesServiceModel>, IHaveCustomMappings
    {
        public int ServiceOrderId { get; set; }

        public string ServiceName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<OrderServicesServiceModel, AllServicesOrdersViewModel>()
                .ForMember(
                    destination => destination.ServiceOrderId,
                    options => options.MapFrom(origin => origin.Id));
        }
    }
}
