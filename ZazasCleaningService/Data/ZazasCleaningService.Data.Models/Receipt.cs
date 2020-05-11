namespace ZazasCleaningService.Data.Models
{
    using ZazasCleaningService.Data.Common.Models;

    public abstract class Receipt : BaseModel<int>
    {
        public string IssuedOnPicture { get; set; }

        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; }
    }
}
