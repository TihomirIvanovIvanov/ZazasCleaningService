namespace ZazasCleaningService.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;
    using ZazasCleaningService.Web.ViewModels.Products.Order;

    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;

        private readonly IProductsService productsService;

        private readonly IServicesService servicesService;

        public OrdersController(
            IOrdersService ordersService,
            IProductsService productsService,
            IServicesService servicesService)
        {
            this.ordersService = ordersService;
            this.productsService = productsService;
            this.servicesService = servicesService;
        }

        public async Task<IActionResult> CreateOrderProducts(int id)
        {
            var productView = (await this.productsService.GetByIdAsync(id))
                .To<ProductsOrderInputModel>();

            return this.View(productView);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderProducts(ProductsOrderInputModel productsOrderInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.CreateOrderProducts));
            }

            var ordersServiceModel = productsOrderInputModel.To<OrderProductsServiceModel>();
            ordersServiceModel.IssuerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.ordersService.CreateProductOrderAsync(ordersServiceModel);

            return this.Redirect("/");
        }

        public async Task<IActionResult> CreateOrderServices(int id)
        {
            var productView = (await this.servicesService.GetByIdAsync(id))
                .To<ServicesOrderInputModel>();

            return this.View(productView);
        }
    }
}
