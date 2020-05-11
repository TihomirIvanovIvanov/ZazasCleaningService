namespace ZazasCleaningService.Data.Models
{
    using System.Collections.Generic;

    using ZazasCleaningService.Data.Common.Models;

    public class Receipt : BaseDeletableModel<int>
    {
        public Receipt()
        {
            this.ProductOrders = new List<ProductOrder>();
        }

        public string IssuedOnPicture { get; set; }

        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; }

        public List<ProductOrder> ProductOrders { get; set; }
    }
}
