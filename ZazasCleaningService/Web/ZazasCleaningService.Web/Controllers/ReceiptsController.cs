namespace ZazasCleaningService.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Web.ViewModels.Receipts;
    using ZazasCleaningService.Web.ViewModels.Receipts.Details;

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

        public async Task<IActionResult> ProductReceipts(string recipientId)
        {
            var productReceiptsViews = await this.receiptsService
                .GetAllProductReceiptsByRecipientId(recipientId)
                .Select(receipt => receipt.To<ProductReceiptsViewModel>())
                .ToListAsync();

            return this.View(productReceiptsViews);
        }

        [HttpGet("/Receipts/Details/ProductDetails/{id}")]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var productReceiptDetailsView = (await this.receiptsService.GetProductByReceiptIdAsync(id))
                .To<ProductReceiptDetailsViewModel>();

            return this.View("Details/ProductDetails", productReceiptDetailsView);
        }

        public async Task<IActionResult> ServiceReceipts()
        {
            var recipientId = await this.ordersService.GetRecipientIdForOrdersAsync();

            var serviceReceiptsViews = await this.receiptsService
                .GetAllServiceReceiptsByRecipientId(recipientId)
                .Select(receipt => receipt.To<ServiceReceiptsViewModel>())
                .ToListAsync();

            return this.View(serviceReceiptsViews);
        }

        [HttpGet("/Receipts/Details/ServiceDetails/{id}")]
        public async Task<IActionResult> ServiceDetails(int id)
        {
            var serviceReceiptDetailsView = (await this.receiptsService.GetServiceByReceiptIdAsync(id))
                .To<ServiceReceiptDetailsViewModel>();

            return this.View("Details/ServiceDetails", serviceReceiptDetailsView);
        }
    }
}
