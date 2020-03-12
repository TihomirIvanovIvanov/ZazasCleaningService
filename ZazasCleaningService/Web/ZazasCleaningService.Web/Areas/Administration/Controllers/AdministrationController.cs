namespace ZazasCleaningService.Web.Areas.Administration.Controllers
{
    using ZazasCleaningService.Common;
    using ZazasCleaningService.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
