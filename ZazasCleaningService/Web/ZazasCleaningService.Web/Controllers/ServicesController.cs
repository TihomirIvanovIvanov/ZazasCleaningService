namespace ZazasCleaningService.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Web.ViewModels.Services.All;
    using ZazasCleaningService.Web.ViewModels.Services.Details;

    public class ServicesController : BaseController
    {
        private readonly IServicesService servicesService;

        public ServicesController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }

        public async Task<IActionResult> All()
        {
            var allServices = await this.servicesService.GetAllServicesAsync()
                .To<ServicesAllViewModel>().ToListAsync();

            return this.View(allServices);
        }

        public async Task<IActionResult> Details(int id)
        {
            var serviceDetailsViewModel = (await this.servicesService.GetByIdAsync(id)).To<ServicesDetailsViewModel>();

            return this.View(serviceDetailsViewModel);
        }
    }
}
