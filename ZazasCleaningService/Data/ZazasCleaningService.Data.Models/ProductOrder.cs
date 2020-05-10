namespace ZazasCleaningService.Data.Models
{
    public class ProductOrder : Order
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public int StatusId { get; set; }

        public OrderStatus Status { get; set; }
    }
}
