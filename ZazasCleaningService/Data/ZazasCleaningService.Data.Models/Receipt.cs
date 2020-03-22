namespace ZazasCleaningService.Data.Models
{
    public class Receipt : BaseModel<int>
    {
        public string IssuedOnPicture { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
