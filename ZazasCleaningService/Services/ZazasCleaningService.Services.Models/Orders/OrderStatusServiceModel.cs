namespace ZazasCleaningService.Services.Models.Orders
{
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;

    public class OrderStatusServiceModel : IMapFrom<OrderStatus>, IMapTo<OrderStatus>
    {
        public string Name { get; set; }
    }
}
