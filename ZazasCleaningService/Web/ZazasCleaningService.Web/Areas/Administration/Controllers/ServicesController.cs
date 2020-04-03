namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;
    using ZazasCleaningService.Web.ViewModels.Services.Create;

    public class ServicesController : AdministrationController
    {
        private readonly IServicesService servicesService;

        private readonly ICloudinaryService cloudinaryService;

        public ServicesController(IServicesService servicesService, ICloudinaryService cloudinaryService)
        {
            this.servicesService = servicesService;
            this.cloudinaryService = cloudinaryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicesCreateInputModel servicesCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(servicesCreateInputModel);
            }

            var pictureUrl = await this.cloudinaryService
                .UploadPictureAsync(servicesCreateInputModel.Picture, servicesCreateInputModel.Name);

            var servicesServiceModel = AutoMapperConfig.MapperInstance.Map<ServicesServiceModel>(servicesCreateInputModel);
            await this.servicesService.CreateServiceAsync(servicesServiceModel);

            return this.RedirectToAction(nameof(this.Create));
        }
    }
}
