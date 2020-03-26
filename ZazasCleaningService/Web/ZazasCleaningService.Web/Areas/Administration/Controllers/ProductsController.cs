namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : AdministrationController
    {
        [HttpGet("/Administration/Products/Type/Create")]
        public IActionResult CreateType()
        {
            return this.View("Type/Create");
        }
    }
}