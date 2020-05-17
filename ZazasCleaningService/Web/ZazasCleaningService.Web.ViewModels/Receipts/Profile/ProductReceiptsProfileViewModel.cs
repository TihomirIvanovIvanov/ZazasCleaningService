namespace ZazasCleaningService.Web.ViewModels.Receipts.Profile
{
    using AutoMapper;
    using System;
    using System.Linq;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Receipts;

    public class ProductReceiptsProfileViewModel : IMapFrom<ReceiptProductsServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Products { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ReceiptProductsServiceModel, ProductReceiptsProfileViewModel>()
                .ForMember(
                    destination => destination.Products,
                    options => options.MapFrom(origin => origin.OrderProducts.Sum(order => order.Quantity)));
        }
    }
}
