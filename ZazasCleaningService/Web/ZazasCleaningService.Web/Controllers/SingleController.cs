namespace ZazasCleaningService.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SingleController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
