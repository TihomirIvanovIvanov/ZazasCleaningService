namespace ZazasCleaningService.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Web.ViewModels.Services.All;
    using ZazasCleaningService.Web.ViewModels.Services.Details;

    [Authorize]
    public class ServicesController : BaseController
    {
        private const int ItemsPerPage = 4;

        private readonly IServicesService servicesService;

        public ServicesController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }

        public async Task<IActionResult> All(int page = 1)
        {
            var allServicesView = this.servicesService
                .GetAllServicesAsync(ItemsPerPage, (page - 1) * ItemsPerPage)
                .To<ServicesAllViewModel>();

            var count = this.servicesService.GetCountServices();
            var servicesPerPage = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (servicesPerPage == 0)
            {
                servicesPerPage = 1;
            }

            allServicesView.Select(service => service.PagesCount == servicesPerPage && service.CurrentPage == page);

            return this.View(await allServicesView.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var serviceDetailsViewModel = (await this.servicesService.GetServiceByIdAsync(id)).To<ServicesDetailsViewModel>();

            return this.View(serviceDetailsViewModel);
        }
    }
}
