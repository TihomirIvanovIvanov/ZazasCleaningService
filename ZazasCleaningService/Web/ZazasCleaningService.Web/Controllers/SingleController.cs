namespace ZazasCleaningService.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SingleController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
