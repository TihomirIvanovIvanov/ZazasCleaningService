namespace ZazasCleaningService.Services.Models
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class ApplicationUserServiceModel : IdentityUser, IMapFrom<ApplicationUser>
    {
        public List<OrderProductsServiceModel> Orders { get; set; }
    }
}
