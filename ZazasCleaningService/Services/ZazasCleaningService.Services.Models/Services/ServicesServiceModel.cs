namespace ZazasCleaningService.Services.Models.Services
{
    using System.Collections.Generic;

    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Votes;

    public class ServicesServiceModel : IMapFrom<Service>, IMapTo<Service>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public ICollection<VotesServiceModel> Votes { get; set; }
    }
}
