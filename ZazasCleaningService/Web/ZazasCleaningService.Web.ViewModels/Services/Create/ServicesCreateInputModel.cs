namespace ZazasCleaningService.Web.ViewModels.Services.Create
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;

    public class ServicesCreateInputModel : IMapTo<ServicesServiceModel>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
