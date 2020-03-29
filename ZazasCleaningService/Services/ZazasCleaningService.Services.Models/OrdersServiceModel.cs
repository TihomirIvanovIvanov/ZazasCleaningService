namespace ZazasCleaningService.Services.Models
{
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;

    public class OrdersServiceModel : IMapTo<Order>, IMapFrom<Order>
    {
        public int Id { get; set; }


    }
}
