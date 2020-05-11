namespace ZazasCleaningService.Data.Models
{
    public class ProductOrder : Order
    {
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public int StatusId { get; set; }

        public virtual OrderStatus Status { get; set; }
    }
}
