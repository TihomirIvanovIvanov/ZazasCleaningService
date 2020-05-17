namespace ZazasCleaningService.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Web.ViewModels.Receipts.Details;
    using ZazasCleaningService.Web.ViewModels.Receipts.Profile;

    [Authorize]
    public class ReceiptsController : BaseController
    {
        private readonly IReceiptsService receiptsService;

        private readonly IOrdersService ordersService;

        public ReceiptsController(IReceiptsService receiptsService, IOrdersService ordersService)
        {
            this.receiptsService = receiptsService;
            this.ordersService = ordersService;
        }

        public async Task<IActionResult> ProductsProfile()
        {
            var recipientId = await this.ordersService.GetRecipientIdForOrdersAsync();

            var receiptsViewModel = await this.receiptsService
                .GetAllProductReceiptsByRecipientId(recipientId)
                .Select(receipt => receipt.To<ProductReceiptsProfileViewModel>())
                .ToListAsync();

            return this.View(receiptsViewModel);
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var receiptProductsServiceModel = (await this.receiptsService.GetProductByReceiptIdAsync(id))
                .To<ProductReceiptDetailsViewModel>();

            return this.View(receiptProductsServiceModel);
        }
    }
}
