namespace ZazasCleaningService.Data.Models
{
    public class Product : BaseModel<int>
    {
        public int ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
    }
}
