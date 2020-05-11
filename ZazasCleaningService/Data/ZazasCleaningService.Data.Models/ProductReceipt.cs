namespace ZazasCleaningService.Data.Models
{
    using System.Collections.Generic;

    public class ProductReceipt : Receipt
    {
        public ProductReceipt()
        {
            this.ProductOrders = new List<ProductOrder>();
        }

        public virtual List<ProductOrder> ProductOrders { get; set; }
    }
}
