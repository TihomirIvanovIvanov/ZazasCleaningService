namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;
    using ZazasCleaningService.Web.ViewModels.Services.Create;
    using ZazasCleaningService.Web.ViewModels.Services.Delete;
    using ZazasCleaningService.Web.ViewModels.Services.Edit;

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
            servicesServiceModel.Picture = pictureUrl;

            await this.servicesService.CreateServiceAsync(servicesServiceModel);

            return this.Redirect("/Services/All");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var servicesEditInputModel =
                (await this.servicesService.GetServiceByIdAsync(id)).To<ServicesEditInputModel>();

            if (servicesEditInputModel == null)
            {
                return this.Redirect("/");
            }

            return this.View(servicesEditInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ServicesEditInputModel servicesEditInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(servicesEditInputModel);
            }

            var pictureUrl = await this.cloudinaryService
                .UploadPictureAsync(servicesEditInputModel.Picture, servicesEditInputModel.Name);

            var servicesServiceModel = AutoMapperConfig.MapperInstance.Map<ServicesServiceModel>(servicesEditInputModel);
            servicesServiceModel.Picture = pictureUrl;

            await this.servicesService.EditAsync(id, servicesServiceModel);

            return this.Redirect("/Services/All");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var servicesDeleteViewModel =
                (await this.servicesService.GetServiceByIdAsync(id)).To<ServicesDeleteViewModel>();

            if (servicesDeleteViewModel == null)
            {
                return this.Redirect("/");
            }

            return this.View(servicesDeleteViewModel);
        }

        [HttpPost("/Administration/Services/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await this.servicesService.DeleteByIdAsync(id);

            return this.Redirect("/Services/All");
        }
    }
}
