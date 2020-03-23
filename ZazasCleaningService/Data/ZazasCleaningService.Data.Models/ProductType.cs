namespace ZazasCleaningService.Data.Models
{
    using ZazasCleaningService.Data.Common.Models;

    public class ProductType : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
