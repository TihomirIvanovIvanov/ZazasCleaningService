namespace ZazasCleaningService.Web.ViewModels.Receipts.Details
{
    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Receipts;

    public class ServiceReceiptDetailsViewModel : IMapFrom<ReceiptServicesServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string IssuedOnPicture { get; set; }

        public string RecipientName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ReceiptServicesServiceModel, ServiceReceiptDetailsViewModel>()
                .ForMember(
                    destination => destination.RecipientName,
                    options => options.MapFrom(origin => origin.Recipient.UserName));
        }
    }
}
