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
    using ZazasCleaningService.Web.ViewModels.Services.Order;

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

            var orderProductsServiceModel = productsOrderInputModel.To<OrderProductsServiceModel>();
            orderProductsServiceModel.IssuerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.ordersService.CreateProductOrderAsync(orderProductsServiceModel);

            return this.Redirect("/");
        }

        public async Task<IActionResult> CreateOrderServices(int id)
        {
            var productView = (await this.servicesService.GetByIdAsync(id))
                .To<ServicesOrderInputModel>();

            this.ViewData["serviceId"] = productView.ServiceId;
            this.ViewData["name"] = productView.Name;

            return this.View(productView);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderServices(int id, ServicesOrderInputModel servicesOrderInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.CreateOrderServices));
            }

            var orderServicesServiceModel = servicesOrderInputModel.To<OrderServicesServiceModel>();
            orderServicesServiceModel.IssuerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.ordersService.CreateServiceOrderAsync(orderServicesServiceModel);

            return this.Redirect("/");
        }

        public async Task<IActionResult> All()
        {
            return this.View();
        }
    }
}
