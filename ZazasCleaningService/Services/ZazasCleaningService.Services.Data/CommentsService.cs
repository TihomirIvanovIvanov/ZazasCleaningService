namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly ApplicationDbContext dbContext;

        public CommentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateCommentsAsync(CommentsServiceModel commentsServiceModel)
        {
            var comments = AutoMapperConfig.MapperInstance.Map<Comment>(commentsServiceModel);
            comments.ParentId = commentsServiceModel.ParentId;

            this.dbContext.Comments.Add(comments);
            await this.dbContext.SaveChangesAsync();

            return comments.Id;
        }
    }
}
