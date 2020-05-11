namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Web.ViewModels.Products.Order.Cart;
    using ZazasCleaningService.Web.ViewModels.Services.Order.Cart;

    public class OrdersController : AdministrationController
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public async Task<IActionResult> ProductsCart()
        {
            var productCartViewModel = await this.ordersService.GetAllProductOrdersAsync()
                .To<ProductOrdersCartViewModel>()
                .ToListAsync();

            return this.View(productCartViewModel);
        }

        [HttpPost]
        public IActionResult ProductsCartComplete()
        {
            return this.View();
        }

        public async Task<IActionResult> ServicesCart()
        {
            var serviceCartViewModel = await this.ordersService.GetAllServiceOrdersAsync()
                .To<ServiceOrdersCartViewModel>()
                .ToListAsync();

            return this.View(serviceCartViewModel);
        }
    }
}
