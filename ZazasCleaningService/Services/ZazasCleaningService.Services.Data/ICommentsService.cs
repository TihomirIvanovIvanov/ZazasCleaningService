namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Comments;

    public interface ICommentsService
    {
        Task<T> CreateCommentsAsync<T>(CommentsServiceModel commentsServiceModel, int? parentId = null);

        Task<bool> IsInCommentIdAsync(int parentId, int commentId);

        IQueryable<T> GetAllCommentsAsync<T>();
    }
}
