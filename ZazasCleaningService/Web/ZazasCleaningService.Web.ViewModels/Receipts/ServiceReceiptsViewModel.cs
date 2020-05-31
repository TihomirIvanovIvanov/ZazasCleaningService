namespace ZazasCleaningService.Web.ViewModels.Receipts
{
    using System;
    using System.Linq;

    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Receipts;

    public class ServiceReceiptsViewModel : IMapFrom<ReceiptServicesServiceModel>, IHaveCustomMappings
    {
        private const string DateFormat = "MM/dd/yyyy HH:mm";

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Services { get; set; }

        public string CreatedOnFormatted => this.CreatedOn.ToString(DateFormat);

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ReceiptServicesServiceModel, ServiceReceiptsViewModel>()
                .ForMember(
                    destination => destination.Services,
                    options => options.MapFrom(origin => origin.OrderServices.Sum(order => order.Service.Id)));
        }
    }
}
