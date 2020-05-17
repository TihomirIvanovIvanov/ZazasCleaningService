namespace ZazasCleaningService.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Web.ViewModels.Receipts.Details;

    [Authorize]
    public class ReceiptsController : BaseController
    {
        private readonly IReceiptsService receiptsService;

        public ReceiptsController(IReceiptsService receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var receiptProductsServiceModel = (await this.receiptsService.GetProductByReceiptIdAsync(id))
                .To<ProductReceiptDetailsViewModel>();

            return this.View(receiptProductsServiceModel);
        }
    }
}