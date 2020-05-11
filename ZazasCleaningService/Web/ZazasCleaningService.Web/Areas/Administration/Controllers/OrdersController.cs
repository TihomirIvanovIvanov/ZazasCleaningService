namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Web.ViewModels.Products.Order.Cart;

    public class OrdersController : AdministrationController
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public async Task<IActionResult> ProductsCart()
        {
            var viewModel = await this.ordersService.GetAllProductOrdersAsync()
                .To<ProductOrdersCartViewModel>()
                .ToListAsync();

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult ProductsCartComplete()
        {
            return this.View();
        }
    }
}