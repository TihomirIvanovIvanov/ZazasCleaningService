namespace ZazasCleaningService.Web.ViewModels.Receipts.Details
{
    using System;

    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Receipts;

    public class ProductReceiptDetailsViewModel : IMapFrom<ReceiptProductsServiceModel>
    {
        public int Id { get; set; }

        public string IssuedOnPicture { get; set; }

        public string RecipientUserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
