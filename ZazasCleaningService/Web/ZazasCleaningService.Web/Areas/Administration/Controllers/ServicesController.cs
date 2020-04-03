namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ZazasCleaningService.Web.ViewModels.Services;

    public class ServicesController : AdministrationController
    {
        public IActionResult Create()
        {
            return this.View();
        }

        public async Task<IActionResult> Create(CreateServicesInputModel createServicesInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createServicesInputModel);
            }

            return this.View();
        }
    }
}
