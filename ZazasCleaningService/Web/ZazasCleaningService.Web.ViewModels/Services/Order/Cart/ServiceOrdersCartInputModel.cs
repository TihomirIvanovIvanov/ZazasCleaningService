namespace ZazasCleaningService.Web.ViewModels.Services.Order.Cart
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Receipts;

    public class ServiceOrdersCartInputModel : IMapTo<ReceiptServicesServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public IFormFile IssuedOnPicture { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ReceiptServicesServiceModel, ServiceOrdersCartInputModel>()
                .ForMember(
                    destination => destination.Id,
                    options => options.MapFrom(origin => origin.Id))
                .ForMember(
                    destination => destination.IssuedOnPicture,
                    options => options.MapFrom(origin => origin.IssuedOnPicture));
        }
    }
}
