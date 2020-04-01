namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Products;
    using ZazasCleaningService.Web.ViewModels.Products.Create;

    public class ProductsController : AdministrationController
    {
        private readonly IProductsService productsService;

        private readonly ICloudinaryService cloudinaryService;

        public ProductsController(IProductsService productsService, ICloudinaryService cloudinaryService)
        {
            this.productsService = productsService;
            this.cloudinaryService = cloudinaryService;
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

        [HttpPost]
        public async Task<IActionResult> Create(ProductsCreateInputModel productsCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.RedirectToAction(nameof(this.Create));
            }

            var pictureUrl = await this.cloudinaryService
                .UploadPictureAsync(productsCreateInputModel.Picture, productsCreateInputModel.Name);

            var productsServiceModel = AutoMapperConfig.MapperInstance.Map<ProductsServiceModel>(productsCreateInputModel);

            await this.productsService.CreateProductAsync(productsServiceModel);

            return this.Redirect(nameof(this.Create));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var productsEditInputModel = (await this.productsService.GetById(id)).To<ProductsEditInputModel>();

            if (productsEditInputModel == null)
            {
                // TODO: Error handling
                return this.RedirectToAction("/");
            }

            await this.Create();

            return this.View(productsEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductsEditInputModel productsEditInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                await this.Create();
                return this.View(productsEditInputModel);
            }

            var pictureUrl = await this.cloudinaryService
                .UploadPictureAsync(productsEditInputModel.Picture, productsEditInputModel.Name);

            var productsServiceModel = AutoMapperConfig.MapperInstance.Map<ProductsServiceModel>(productsEditInputModel);
            productsServiceModel.Picture = pictureUrl;

            await this.productsService.Edit(id, productsServiceModel);
            return this.Redirect("/");
        }
    }
}
