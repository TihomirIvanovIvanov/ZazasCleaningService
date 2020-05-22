namespace ZazasCleaningService.Data.Models
{
    using ZazasCleaningService.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public int? ParrentId { get; set; }

        public virtual Comment Parrent { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
