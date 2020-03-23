namespace ZazasCleaningService.Data.Models
{
    using System;

    using ZazasCleaningService.Data.Common.Models;

    public class Kid : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime TimeForTakingCare { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
