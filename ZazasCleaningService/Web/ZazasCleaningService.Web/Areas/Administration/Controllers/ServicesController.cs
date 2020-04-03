namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ServicesController : AdministrationController
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
