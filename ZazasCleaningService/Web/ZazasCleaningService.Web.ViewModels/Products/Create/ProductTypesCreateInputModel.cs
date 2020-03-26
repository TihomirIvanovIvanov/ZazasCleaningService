namespace ZazasCleaningService.Web.ViewModels.Products.Create
{
    using System.ComponentModel.DataAnnotations;

    public class ProductTypesCreateInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}
