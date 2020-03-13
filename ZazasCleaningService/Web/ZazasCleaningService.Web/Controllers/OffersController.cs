namespace ZazasCleaningService.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OffersController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
