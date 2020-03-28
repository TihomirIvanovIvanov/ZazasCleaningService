namespace ZazasCleaningService.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Web.ViewModels.Products.All;

    public class ProductsController : BaseController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            var allProducts = await this.productsService.GetAllProducts()
                .To<ProductsAllViewModel>().ToListAsync();

            return this.View(allProducts);
        }
    }
}
