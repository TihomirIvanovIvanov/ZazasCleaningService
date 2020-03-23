namespace ZazasCleaningService.Data.Models
{
    using System.Collections.Generic;

    using ZazasCleaningService.Data.Common.Models;

    public class Home : BaseDeletableModel<int>
    {
        public Home()
        {
            this.Rooms = new HashSet<Room>();
        }

        public string Address { get; set; }

        public int Floor { get; set; }

        public int ApartmentNumber { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
