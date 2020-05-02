namespace ZazasCleaningService.Data.Models
{
    using ZazasCleaningService.Data.Common.Models;

    public abstract class Order : BaseModel<int>
    {
        public string IssuerId { get; set; }

        public virtual ApplicationUser Issuer { get; set; }
    }
}
