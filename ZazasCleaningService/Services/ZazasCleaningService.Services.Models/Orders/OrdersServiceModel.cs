namespace ZazasCleaningService.Services.Models.Orders
{
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Products;

    public class OrdersServiceModel : IMapTo<Order>, IMapFrom<Order>
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public ProductsServiceModel Product { get; set; }

        public string IssuerId { get; set; }

        public ApplicationUserServiceModel Issuer { get; set; }
    }
}
