namespace ZazasCleaningService.Web.ViewModels.Services.Edit
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;

    public class ServicesEditInputModel : IMapFrom<ServicesServiceModel>, IMapTo<ServicesServiceModel>, IHaveCustomMappings
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ServicesServiceModel, ServicesEditInputModel>()
                .ForMember(
                    destination => destination.Picture,
                    options => options.Ignore());
        }
    }
}
