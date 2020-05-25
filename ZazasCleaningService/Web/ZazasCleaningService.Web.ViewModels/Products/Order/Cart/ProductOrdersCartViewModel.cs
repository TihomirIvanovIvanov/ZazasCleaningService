namespace ZazasCleaningService.Web.ViewModels.Products.Order.Cart
{
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class ProductOrdersCartViewModel : IMapFrom<OrderProductsServiceModel>
    {
        public int Id { get; set; }

        public string ProductPicture { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int Quantity { get; set; }

        public string IssuerUserName { get; set; }
    }
}
