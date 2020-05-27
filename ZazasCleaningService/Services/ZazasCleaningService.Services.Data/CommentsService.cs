namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
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

        public async Task<int> CreateCommentsAsync(CommentsServiceModel commentsServiceModel, int? parentId = null)
        {
            var comments = AutoMapperConfig.MapperInstance.Map<Comment>(commentsServiceModel);
            comments.ParentId = parentId;

            this.dbContext.Comments.Add(comments);
            await this.dbContext.SaveChangesAsync();

            return comments.Id;
        }

        public IQueryable<CommentsServiceModel> GetAllCommentsAsync()
        {
            var comments = this.dbContext.Comments.To<CommentsServiceModel>();

            return comments;
        }

        public async Task<bool> IsInCommentIdAsync(int parentId, int commentId)
        {
            var commentParentId = await this.dbContext.Comments
                .Where(comment => comment.Id == parentId)
                .Select(comment => comment.Id)
                .FirstOrDefaultAsync();

            return commentParentId == commentId;
        }
    }
}
