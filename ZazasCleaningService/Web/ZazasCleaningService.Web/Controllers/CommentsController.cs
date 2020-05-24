namespace ZazasCleaningService.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Post()
        {
            var commentsViewModel = await this.commentsService.GetAllCommentsAsync()
                .To<CommentsViewModel>()
                .ToListAsync();

            return this.View(commentsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentsInputModel createCommentsInputModel)
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
