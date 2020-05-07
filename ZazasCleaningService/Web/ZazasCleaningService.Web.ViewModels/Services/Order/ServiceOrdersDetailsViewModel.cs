namespace ZazasCleaningService.Web.ViewModels.Services.Order
{
    using System;

    using AutoMapper;

    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class ServiceOrdersDetailsViewModel : IMapFrom<OrderServicesServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<OrderServicesServiceModel, ServiceOrdersDetailsViewModel>()
                .ForMember(
                    destionation => destionation.Name,
                    options => options.MapFrom(origin => origin.Service.Name))
                .ForMember(
                    destionation => destionation.Picture,
                    options => options.MapFrom(origin => origin.Service.Picture))
                .ForMember(
                    destionation => destionation.Description,
                    options => options.MapFrom(origin => origin.Service.Description));
        }
    }
}
