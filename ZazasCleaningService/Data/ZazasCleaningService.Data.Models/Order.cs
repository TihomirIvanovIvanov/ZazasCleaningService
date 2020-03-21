namespace ZazasCleaningService.Data.Models
{
    using System;

    public class Order : BaseModel<int>
    {
        public DateTime IssuedOn { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
