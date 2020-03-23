namespace ZazasCleaningService.Data.Models
{
    using ZazasCleaningService.Data.Common.Models;

    public class Receipt : BaseDeletableModel<int>
    {
        public string IssuedOnPicture { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
