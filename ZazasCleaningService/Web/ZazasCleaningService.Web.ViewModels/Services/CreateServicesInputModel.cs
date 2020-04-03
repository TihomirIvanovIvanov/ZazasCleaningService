namespace ZazasCleaningService.Web.ViewModels.Services
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreateServicesInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
