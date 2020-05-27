namespace ZazasCleaningService.Web.ViewModels.Comments
{
    using System;

    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Comments;

    public class CommentsViewModel : IMapFrom<CommentsServiceModel>, IMapTo<CommentsServiceModel>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string CreatedOnFormatted => this.CreatedOn.ToString("O");
    }
}
