namespace ZazasCleaningService.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;
    using ZazasCleaningService.Web.ViewModels.Products.Order;
    using ZazasCleaningService.Web.ViewModels.Products.Order.Details;
    using ZazasCleaningService.Web.ViewModels.Services.Order;
    using ZazasCleaningService.Web.ViewModels.Services.Order.Details;

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

        [HttpGet("/Orders/Create/CreateOrderProducts/{id}")]
        public async Task<IActionResult> CreateOrderProducts(int id)
        {
            var productView =
                (await this.productsService.GetProductByIdAsync(id)).To<ProductsOrderInputModel>();

            this.ViewData["productId"] = productView.ProductId;
            this.ViewData["name"] = productView.Name;

            return this.View("Create/CreateOrderProducts", productView);
        }

        [HttpPost("/Orders/Create/CreateOrderProducts/{id}")]
        public async Task<IActionResult> CreateOrderProducts(ProductsOrderInputModel productsOrderInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.CreateOrderProducts));
            }

            var orderProductsServiceModel = productsOrderInputModel.To<OrderProductsServiceModel>();
            orderProductsServiceModel.IssuerId = this.GetCurrentUserId();

            await this.ordersService.CreateProductOrderAsync(orderProductsServiceModel);

            return this.RedirectToAction(nameof(this.AllProductsOrders));
        }

        [HttpGet("/Orders/Create/CreateOrderServices/{id}")]
        public async Task<IActionResult> CreateOrderServices(int id)
        {
            var serviceView =
                (await this.servicesService.GetServiceByIdAsync(id)).To<ServicesOrderInputModel>();

            this.ViewData["serviceId"] = serviceView.ServiceId;
            this.ViewData["name"] = serviceView.Name;

            return this.View("Create/CreateOrderServices", serviceView);
        }

        [HttpPost("/Orders/Create/CreateOrderServices/{id}")]
        public async Task<IActionResult> CreateOrderServices(int id, ServicesOrderInputModel servicesOrderInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.CreateOrderServices));
            }

            var orderServicesServiceModel = servicesOrderInputModel.To<OrderServicesServiceModel>();
            orderServicesServiceModel.IssuerId = this.GetCurrentUserId();

            await this.ordersService.CreateServiceOrderAsync(orderServicesServiceModel);

            return this.RedirectToAction(nameof(this.AllServicesOrders));
        }

        [HttpGet("/Orders/All/AllProductsOrders")]
        public async Task<IActionResult> AllProductsOrders()
        {
            var userId = this.GetCurrentUserId();

            var productsOrder = await this.ordersService
                .GetAllProductOrdersAsync<OrderProductsServiceModel>()
                .Where(order => order.IssuerId == userId)
                .To<AllProductsOrdersViewModel>().ToListAsync();

            this.ViewData["productsData"] = productsOrder.Select(productOrder => new AllProductsOrdersViewModel
            {
                ProductOrderId = productOrder.ProductOrderId,
                ProductName = productOrder.ProductName,
            }).ToList();

            return this.View("All/AllProductsOrders");
        }

        [HttpGet("/Orders/Details/ProductOrdersDetails/{id}")]
        public async Task<IActionResult> ProductOrdersDetails(int id)
        {
            var productOrdersDetailsView =
                (await this.ordersService.GetProductOrdersByIdAsync(id)).To<ProductOrdersDetailsViewModel>();

            return this.View("Details/ProductOrdersDetails", productOrdersDetailsView);
        }

        [HttpGet("/Orders/All/AllServicesOrders")]
        public async Task<IActionResult> AllServicesOrders()
        {
            var userId = this.GetCurrentUserId();

            var servicesOrder = await this.ordersService
                .GetAllServiceOrdersAsync<OrderServicesServiceModel>()
                .Where(order => order.IssuerId == userId)
                .To<AllServicesOrdersViewModel>().ToListAsync();

            this.ViewData["servicesData"] = servicesOrder.Select(serviceOrder => new AllServicesOrdersViewModel
            {
                ServiceOrderId = serviceOrder.ServiceOrderId,
                ServiceName = serviceOrder.ServiceName,
            }).ToList();

            return this.View("All/AllServicesOrders");
        }

        [HttpGet("/Orders/Details/ServiceOrdersDetails/{id}")]
        public async Task<IActionResult> ServiceOrdersDetails(int id)
        {
            var serviceOrdersDetailsView =
                (await this.ordersService.GetServiceOrdersByIdAsync(id)).To<ServiceOrdersDetailsViewModel>();

            return this.View("Details/ServiceOrdersDetails", serviceOrdersDetailsView);
        }

        [NonAction]
        private string GetCurrentUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
