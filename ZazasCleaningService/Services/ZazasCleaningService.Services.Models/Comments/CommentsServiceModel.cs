namespace ZazasCleaningService.Services.Models.Comments
{
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;

    public class CommentsServiceModel : IMapFrom<Comment>, IMapTo<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int? ParentId { get; set; }

        public CommentsServiceModel Parent { get; set; }

        public string UserId { get; set; }

        public ApplicationUserServiceModel User { get; set; }
    }
}
