namespace ZazasCleaningService.Web.ViewModels.Products.Order
{
    using System.ComponentModel.DataAnnotations;

    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class ProductsOrderInputModel : IMapTo<OrderProductsServiceModel>
    {
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
