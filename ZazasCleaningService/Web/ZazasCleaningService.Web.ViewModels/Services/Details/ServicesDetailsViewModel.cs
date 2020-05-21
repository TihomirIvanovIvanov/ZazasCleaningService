namespace ZazasCleaningService.Web.ViewModels.Services.Details
{
    using System.Linq;

    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;

    public class ServicesDetailsViewModel : IMapFrom<ServicesServiceModel>, IMapTo<ServicesServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public int VotesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ServicesServiceModel, ServicesDetailsViewModel>()
                .ForMember(
                    destination => destination.VotesCount,
                    options => options.MapFrom(origin => origin.Votes.Sum(votes => (int)votes.Type)));
        }
    }
}
