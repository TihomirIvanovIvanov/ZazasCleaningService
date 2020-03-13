namespace ZazasCleaningService.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ServicesController : BaseController
    {
        public IActionResult All()
        {
            return this.View();
        }
    }
}
