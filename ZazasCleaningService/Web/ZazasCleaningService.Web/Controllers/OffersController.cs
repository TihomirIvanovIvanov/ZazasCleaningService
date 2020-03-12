namespace ZazasCleaningService.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OffersController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
