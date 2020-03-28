namespace ZazasCleaningService.Web.ViewModels.Products.Create
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models;

    public class ProductsCreateInputModel : IMapTo<ProductsServiceModel>, IHaveCustomMappings
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public string ProductType { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ProductsCreateInputModel, ProductsServiceModel>()
                .ForMember(
                    destination => destination.ProductType,
                    options => options.MapFrom(origin => new ProductTypesServiceModel
                    {
                        Name = origin.ProductType,
                    }));
        }
    }
}
