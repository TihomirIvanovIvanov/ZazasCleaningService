﻿namespace ZazasCleaningService.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : BaseController
    {
        public IActionResult All()
        {
            return this.View();
        }
    }
}
