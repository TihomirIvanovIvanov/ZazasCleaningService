﻿namespace ZazasCleaningService.Web.ViewModels.Receipts.Details
{
    using System;

    using ZazasCleaningService.Common;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Receipts;

    public class ServiceReceiptDetailsViewModel : IMapFrom<ReceiptServicesServiceModel>
    {
        public int Id { get; set; }

        public string IssuedOnPicture { get; set; }

        public string RecipientUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnFormatted => this.CreatedOn.ToString(GlobalConstants.DateFormat);
    }
}
