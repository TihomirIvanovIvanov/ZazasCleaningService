﻿namespace ZazasCleaningService.Web.Controllers
{
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
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
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

        [HttpPost]
        public IActionResult Order(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.Details));
            }

            return this.View();
        }
    }
}
