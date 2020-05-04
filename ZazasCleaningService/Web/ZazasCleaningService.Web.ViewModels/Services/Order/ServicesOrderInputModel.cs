namespace ZazasCleaningService.Web.ViewModels.Services.Order
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;
    using ZazasCleaningService.Services.Models.Services;

    public class ServicesOrderInputModel : IMapFrom<ServicesServiceModel>, IMapTo<OrderServicesServiceModel>, IHaveCustomMappings
    {
        public int ServiceId { get; set; }

        public string Name { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ServicesServiceModel, ServicesOrderInputModel>()
                .ForMember(
                    destionation => destionation.ServiceId,
                    options => options.MapFrom(origin => origin.Id));
        }
    }
}
