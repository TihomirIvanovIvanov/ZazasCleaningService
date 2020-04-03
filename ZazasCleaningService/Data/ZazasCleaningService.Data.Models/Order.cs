namespace ZazasCleaningService.Data.Models
{
    using ZazasCleaningService.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string IssuerId { get; set; }

        public virtual ApplicationUser Issuer { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}
