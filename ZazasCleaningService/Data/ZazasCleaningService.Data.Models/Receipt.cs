namespace ZazasCleaningService.Data.Models
{
    using System.Collections.Generic;

    using ZazasCleaningService.Data.Common.Models;

    public class Receipt : BaseDeletableModel<int>
    {
        public Receipt()
        {
            this.Orders = new HashSet<Order>();
        }

        public string IssuedOnPicture { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; }
    }
}
