namespace ZazasCleaningService.Data.Models
{
    using ZazasCleaningService.Data.Common.Models;

    public class Service : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}
