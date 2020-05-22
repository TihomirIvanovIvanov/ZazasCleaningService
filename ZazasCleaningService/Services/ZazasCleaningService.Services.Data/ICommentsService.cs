namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Comments;

    public interface ICommentsService
    {
        Task<int> CreateCommentsAsync(CommentsServiceModel commentsServiceModel);
    }
}
