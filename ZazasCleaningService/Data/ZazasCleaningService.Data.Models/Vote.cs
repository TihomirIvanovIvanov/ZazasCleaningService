namespace ZazasCleaningService.Data.Models
{
    using ZazasCleaningService.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
