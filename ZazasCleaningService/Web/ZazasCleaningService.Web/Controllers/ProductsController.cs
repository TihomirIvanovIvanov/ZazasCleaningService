namespace ZazasCleaningService.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Products;
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
            var allProductsView = await this.productsService
                .GetAllProductsAsync<ProductsServiceModel>(ItemsPerPage, (page - 1) * ItemsPerPage)
                .To<ProductsAllViewModel>()
                .ToListAsync();

            var count = this.productsService.GetCountProducts();
            var productsPerPage = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (productsPerPage == 0)
            {
                productsPerPage = 1;
            }

            foreach (var products in allProductsView)
            {
                products.PagesCount = productsPerPage;
                products.CurrentPage = page;
            }

            return this.View(allProductsView);
        }

        public async Task<IActionResult> Details(int id)
        {
            var productDetailsViewModel = (await this.productsService.GetProductByIdAsync(id)).To<ProductsDetailsViewModel>();

            return this.View(productDetailsViewModel);
        }
    }
}
