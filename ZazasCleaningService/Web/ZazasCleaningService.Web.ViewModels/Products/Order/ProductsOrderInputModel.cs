namespace ZazasCleaningService.Web.ViewModels.Products.Order
{
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models;

    public class ProductsOrderInputModel : IMapTo<OrdersServiceModel>
    {
        public int ProductId { get; set; }
    }
}
