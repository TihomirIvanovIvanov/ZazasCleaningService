namespace ZazasCleaningService.Data.Models
{
    using System.Collections.Generic;

    public class Receipt : BaseModel<int>
    {
        public Receipt()
        {
            this.Orders = new HashSet<Order>();
        }

        public string IssuedOnPicture { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
