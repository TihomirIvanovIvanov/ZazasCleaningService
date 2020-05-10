namespace ZazasCleaningService.Data.Models
{
    using ZazasCleaningService.Data.Common.Models;

    public class OrderStatus : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
