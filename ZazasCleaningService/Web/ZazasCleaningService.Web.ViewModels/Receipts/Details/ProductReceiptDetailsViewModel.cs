﻿namespace ZazasCleaningService.Web.ViewModels.Receipts.Details
{
    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Receipts;

    public class ProductReceiptDetailsViewModel : IMapFrom<ReceiptProductsServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string IssuedOnPicture { get; set; }

        public string RecipientName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ReceiptProductsServiceModel, ProductReceiptDetailsViewModel>()
                .ForMember(
                    destination => destination.RecipientName,
                    options => options.MapFrom(origin => origin.Recipient.UserName));
        }
    }
}