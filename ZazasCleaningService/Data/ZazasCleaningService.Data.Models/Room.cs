namespace ZazasCleaningService.Data.Models
{
    using ZazasCleaningService.Data.Common.Models;

    public class Room : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int HomeId { get; set; }

        public virtual Home Home { get; set; }
    }
}
