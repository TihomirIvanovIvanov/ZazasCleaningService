namespace ZazasCleaningService.Data.Models
{
    public class Room : BaseModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int HomeId { get; set; }

        public virtual Home Home { get; set; }
    }
}
