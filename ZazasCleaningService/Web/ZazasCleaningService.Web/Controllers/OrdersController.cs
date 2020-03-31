namespace ZazasCleaningService.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;
    using ZazasCleaningService.Web.ViewModels.Products.Order;

    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;

        private readonly IProductsService productsService;

        public OrdersController(IOrdersService ordersService, IProductsService productsService)
        {
            this.ordersService = ordersService;
            this.productsService = productsService;
        }

        public async Task<IActionResult> Create(int id)
        {
            var productView = await this.productsService.GetById(id);

            return this.View(productView);
        }

        [HttpPost]
        public async Task<IActionResult> Order(ProductsOrderInputModel productsOrderInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.Create));
            }

            var ordersServiceModel = productsOrderInputModel.To<OrdersServiceModel>();
            ordersServiceModel.IssuerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.ordersService.CreateOrder(ordersServiceModel);

            return this.RedirectToAction("/");
        }
    }
}
