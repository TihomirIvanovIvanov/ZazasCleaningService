namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Web.ViewModels.Products.Create;

    public class ProductsController : AdministrationController
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/Administration/Products/Type/Create")]
        public IActionResult CreateType()
        {
            return this.View("Type/Create");
        }

        [HttpPost("/Administration/Products/Type/Create")]
        public async Task<IActionResult> CreateType(ProductTypesCreateInputModel productTypesCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(productTypesCreateInputModel);
            }

            await this.productsService.CreateProductTypeAsync(productTypesCreateInputModel.Name);

            return this.RedirectToAction(nameof(this.CreateType));
        }
    }
}
