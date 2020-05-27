namespace ZazasCleaningService.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Comments;

    public class CreateCommentsInputModel : IMapTo<CommentsServiceModel>, IMapFrom<CommentsServiceModel>
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
