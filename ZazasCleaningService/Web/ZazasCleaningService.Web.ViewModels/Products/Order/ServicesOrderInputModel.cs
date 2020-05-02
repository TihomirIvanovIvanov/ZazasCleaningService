namespace ZazasCleaningService.Web.ViewModels.Products.Order
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class ServicesOrderInputModel : IMapFrom<OrderServicesServiceModel>
    {
        public int ServiceId { get; set; }

        [Required]
        public DateTime From { get; set; }

        [Required]
        public DateTime To { get; set; }
    }
}
