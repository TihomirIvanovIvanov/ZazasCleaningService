namespace ZazasCleaningService.Web.ViewModels.Receipts.Details
{
    using System;

    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Receipts;

    public class ProductReceiptDetailsViewModel : IMapFrom<ReceiptProductsServiceModel>
    {
        private const string DateFormat = "MM/dd/yyyy HH:mm";

        public int Id { get; set; }

        public string IssuedOnPicture { get; set; }

        public string RecipientUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnFormatted => this.CreatedOn.ToString(DateFormat);
    }
}
