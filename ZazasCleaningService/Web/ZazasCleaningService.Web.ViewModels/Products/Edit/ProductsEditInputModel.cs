namespace ZazasCleaningService.Web.ViewModels.Products.Edit
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Products;

    public class ProductsEditInputModel : IMapFrom<ProductsServiceModel>, IMapTo<ProductsServiceModel>, IHaveCustomMappings
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [IgnoreMap]
        public IFormFile Picture { get; set; }

        [Required]
        public string ProductTypeName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            // TODO: Swap Source Destination
            configuration
                .CreateMap<ProductsServiceModel, ProductsEditInputModel>()
                .ForMember(
                    destination => destination.ProductTypeName,
                    options => options.MapFrom(origin => origin.ProductType.Name));
        }
    }
}
