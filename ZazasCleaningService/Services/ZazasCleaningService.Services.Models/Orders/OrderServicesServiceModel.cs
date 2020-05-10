namespace ZazasCleaningService.Services.Models.Orders
{
    using System;

    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;

    public class OrderServicesServiceModel : IMapFrom<ServiceOrder>, IMapTo<ServiceOrder>
    {
        public int Id { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int ServiceId { get; set; }

        public ServicesServiceModel Service { get; set; }

        public string IssuerId { get; set; }

        public ApplicationUserServiceModel Issuer { get; set; }

        public int StatusId { get; set; }

        public OrderStatusServiceModel Status { get; set; }
    }
}
