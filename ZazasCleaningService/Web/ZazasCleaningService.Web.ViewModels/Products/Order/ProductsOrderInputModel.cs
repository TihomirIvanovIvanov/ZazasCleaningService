namespace ZazasCleaningService.Web.ViewModels.Products.Order
{
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class ProductsOrderInputModel : IMapTo<OrdersServiceModel>
    {
        public int ProductId { get; set; }
    }
}
