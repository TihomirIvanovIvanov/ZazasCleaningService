namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;
    using ZazasCleaningService.Services.Models.Receipts;
    using ZazasCleaningService.Web.ViewModels.Products.Order.Cart;
    using ZazasCleaningService.Web.ViewModels.Services.Order.Cart;

    public class OrdersController : AdministrationController
    {
        private const string PictureName = "default";

        private readonly IOrdersService ordersService;

        private readonly IReceiptsService receiptsService;

        private readonly ICloudinaryService cloudinaryService;

        public OrdersController(
            IOrdersService ordersService,
            IReceiptsService receiptsService,
            ICloudinaryService cloudinaryService)
        {
            this.ordersService = ordersService;
            this.receiptsService = receiptsService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> ProductsCart()
        {
            var productCartViewModel = await this.ordersService
                .GetAllProductOrders<OrderProductsServiceModel>()
                .To<ProductOrdersCartViewModel>()
                .ToListAsync();

            return this.View(productCartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteProducts(string recipientId)
        {
            var receiptId = await this.receiptsService.CreateProductReceiptAsync(recipientId);

            return this.Redirect($"/Administration/Orders/CompleteProductCart/{receiptId}");
        }

        public async Task<IActionResult> CompleteProductCart(int id)
        {
            var completeProductCartView =
                (await this.receiptsService.GetProductByReceiptIdAsync(id)).To<ProductOrdersCartInputModel>();

            return this.View(completeProductCartView);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteProductCart(ProductOrdersCartInputModel productOrdersCartInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(productOrdersCartInputModel);
            }

            var pictureUrl = await this.cloudinaryService
                .UploadPictureAsync(productOrdersCartInputModel.IssuedOnPicture, PictureName);

            var receiptProductsServiceModel =
                AutoMapperConfig.MapperInstance.Map<ReceiptProductsServiceModel>(productOrdersCartInputModel);
            receiptProductsServiceModel.IssuedOnPicture = pictureUrl;

            var productReceiptId = await this.receiptsService
                .SetIssuedOnPictureToProductReceiptsAsync(receiptProductsServiceModel);

            return this.Redirect($"/Receipts/Details/ProductDetails/{productReceiptId}");
        }

        public async Task<IActionResult> ServicesCart()
        {
            var serviceCartViewModel = await this.ordersService
                .GetAllServiceOrders<OrderServicesServiceModel>()
                .To<ServiceOrdersCartViewModel>()
                .ToListAsync();

            return this.View(serviceCartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteServices(string recipientId)
        {
            var receiptId = await this.receiptsService.CreateServiceReceiptAsync(recipientId);

            return this.Redirect($"/Administration/Orders/CompleteServiceCart/{receiptId}");
        }

        public async Task<IActionResult> CompleteServiceCart(int id)
        {
            var completeServiceCartView =
                (await this.receiptsService.GetServiceByReceiptIdAsync(id)).To<ServiceOrdersCartInputModel>();

            return this.View(completeServiceCartView);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteServiceCart(ServiceOrdersCartInputModel serviceOrdersCartInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(serviceOrdersCartInputModel);
            }

            var pictureUrl = await this.cloudinaryService
                .UploadPictureAsync(serviceOrdersCartInputModel.IssuedOnPicture, PictureName);

            var receiptServicesServiceModel =
                AutoMapperConfig.MapperInstance.Map<ReceiptServicesServiceModel>(serviceOrdersCartInputModel);
            receiptServicesServiceModel.IssuedOnPicture = pictureUrl;

            var serviceReceiptId = await this.receiptsService
                .SetIssuedOnPictureToServiceReceiptsAsync(receiptServicesServiceModel);

            return this.Redirect($"/Receipts/Details/ServiceDetails/{serviceReceiptId}");
        }
    }
}
