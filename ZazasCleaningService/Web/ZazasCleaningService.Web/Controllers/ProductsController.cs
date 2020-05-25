namespace ZazasCleaningService.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Web.ViewModels.Products.All;
    using ZazasCleaningService.Web.ViewModels.Products.Details;

    [Authorize]
    public class ProductsController : BaseController
    {
        private const int ItemsPerPage = 4;

        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public async Task<IActionResult> All(int page = 1)
        {
            var allProductsView = this.productsService
                .GetAllProductsAsync(ItemsPerPage, (page - 1) * ItemsPerPage)
                .To<ProductsAllViewModel>();

            var count = this.productsService.GetCountProducts();
            var productsPerPage = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (productsPerPage == 0)
            {
                productsPerPage = 1;
            }

            allProductsView.Select(product => product.PagesCount == productsPerPage && product.CurrentPage == page);

            return this.View(await allProductsView.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var productDetailsViewModel = (await this.productsService.GetProductByIdAsync(id)).To<ProductsDetailsViewModel>();

            return this.View(productDetailsViewModel);
        }
    }
}
