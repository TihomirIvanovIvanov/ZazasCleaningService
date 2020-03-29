namespace ZazasCleaningService.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;
    using ZazasCleaningService.Web.ViewModels.Products.All;
    using ZazasCleaningService.Web.ViewModels.Products.Details;
    using ZazasCleaningService.Web.ViewModels.Products.Order;

    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;

        private readonly IOrdersService ordersService;

        public ProductsController(IProductsService productsService, IOrdersService ordersService)
        {
            this.productsService = productsService;
            this.ordersService = ordersService;
        }

        public async Task<IActionResult> All()
        {
            var allProducts = await this.productsService.GetAllProducts()
                .To<ProductsAllViewModel>().ToListAsync();

            return this.View(allProducts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var productView = (await this.productsService.GetById(id)).To<ProductsDetailsViewModel>();

            return this.View(productView);
        }

        public async Task<IActionResult> Order(int id)
        {
            var productView = await this.productsService.GetById(id);

            return this.View(productView);
        }

        [HttpPost]
        public async Task<IActionResult> Order(ProductsOrderInputModel productsOrderInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.Details));
            }

            var ordersServiceModel = productsOrderInputModel.To<OrdersServiceModel>();
            ordersServiceModel.IssuerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.ordersService.CreateOrder(ordersServiceModel);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
