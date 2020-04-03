namespace ZazasCleaningService.Services.Models.Services
{
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;

    public class ServicesServiceModel : IMapFrom<Service>, IMapTo<Service>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}
