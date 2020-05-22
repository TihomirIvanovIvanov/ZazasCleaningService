namespace ZazasCleaningService.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Comments;
    using ZazasCleaningService.Web.ViewModels.Comments;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public IActionResult Post()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCommentsInputModel createCommentsInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createCommentsInputModel);
            }

            var commentsServiceModel = AutoMapperConfig.MapperInstance.Map<CommentsServiceModel>(createCommentsInputModel);
            commentsServiceModel.UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.commentsService.CreateCommentsAsync(commentsServiceModel);

            return this.RedirectToAction(nameof(this.Post));
        }
    }
}
