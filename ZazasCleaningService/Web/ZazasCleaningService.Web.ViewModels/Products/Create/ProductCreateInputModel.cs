namespace ZazasCleaningService.Web.ViewModels.Products.Create
{
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public string ProductType { get; set; }
    }
}
