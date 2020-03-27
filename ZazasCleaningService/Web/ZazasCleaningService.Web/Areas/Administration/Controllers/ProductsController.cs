namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Create()
        {
            var allProductTypes = await this.productsService.GetAllProductTypes().ToListAsync();

            this.ViewData["types"] = allProductTypes.Select(productTypes => new ProductCreateProductTypesViewModel
            {
                Name = productTypes.Name,
            }).ToList();

            return this.View();
        }
    }
}
