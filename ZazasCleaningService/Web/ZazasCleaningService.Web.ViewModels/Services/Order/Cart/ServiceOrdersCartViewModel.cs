namespace ZazasCleaningService.Web.ViewModels.Services.Order.Cart
{
    using System;

    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class ServiceOrdersCartViewModel : IMapFrom<OrderServicesServiceModel>
    {
        public int Id { get; set; }

        public string ServicePicture { get; set; }

        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public string IssuerUserName { get; set; }
    }
}
