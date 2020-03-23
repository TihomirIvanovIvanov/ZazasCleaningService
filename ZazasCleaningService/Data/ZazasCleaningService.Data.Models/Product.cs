namespace ZazasCleaningService.Data.Models
{
    using ZazasCleaningService.Data.Common.Models;

    public class Product : BaseDeletableModel<int>
    {
        public int ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
    }
}
