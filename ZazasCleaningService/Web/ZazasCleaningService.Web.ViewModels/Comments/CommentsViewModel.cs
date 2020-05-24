namespace ZazasCleaningService.Web.ViewModels.Comments
{
    using System;
    using System.Collections.Generic;

    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Comments;

    public class CommentsViewModel : IMapFrom<CommentsServiceModel>, IMapTo<CommentsServiceModel>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public IEnumerable<CommentParentsViewModel> Parents { get; set; }
    }
}
