namespace ZazasCleaningService.Web.ViewModels.Services.Order.Details
{
    using System;

    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class ServiceOrdersDetailsViewModel : IMapFrom<OrderServicesServiceModel>
    {
        private const string DateFormat = "MM/dd/yyyy HH:mm";

        public int Id { get; set; }

        public string ServiceName { get; set; }

        public string ServicePicture { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string ServiceDescription { get; set; }

        public string StatusName { get; set; }

        public string FromFormatted => this.From.ToString(DateFormat);

        public string ToFormatted => this.To.ToString(DateFormat);
    }
}
