namespace ZazasCleaningService.Data.Models
{
    using System;

    public class Kid : BaseModel<int>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime TimeForTakingCare { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
