namespace ZazasCleaningService.Web.ViewModels.Receipts.Details
{
    using System;

    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Receipts;

    public class ProductReceiptDetailsViewModel : IMapFrom<ReceiptProductsServiceModel>
    {
        public int Id { get; set; }

        public string IssuedOnPicture { get; set; }

        public string RecipientUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FormattedCreatedOn => this.CreatedOn.ToString("MM/dd/yyyy HH:mm");

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration
        //        .CreateMap<ReceiptProductsServiceModel, ProductReceiptDetailsViewModel>()
        //        .ForMember(
        //            destination => destination.RecipientName,
        //            options => options.MapFrom(origin => origin.Recipient.UserName));
        //}
    }
}
