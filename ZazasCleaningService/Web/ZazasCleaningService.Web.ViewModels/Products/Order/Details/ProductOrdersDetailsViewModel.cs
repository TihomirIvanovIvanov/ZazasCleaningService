namespace ZazasCleaningService.Web.ViewModels.Products.Order.Details
{
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class ProductOrdersDetailsViewModel : IMapFrom<OrderProductsServiceModel>
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductPicture { get; set; }

        public int Quantity { get; set; }

        public string ProductDescription { get; set; }

        public string StatusName { get; set; }
    }
}
