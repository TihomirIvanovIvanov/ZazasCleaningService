﻿namespace ZazasCleaningService.Web.ViewModels.Products.Create
{
    using System.ComponentModel.DataAnnotations;

    public class ProductTypeCreateInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}
