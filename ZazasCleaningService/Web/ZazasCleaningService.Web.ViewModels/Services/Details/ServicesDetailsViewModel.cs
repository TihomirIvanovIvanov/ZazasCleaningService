namespace ZazasCleaningService.Web.ViewModels.Services.Details
{
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;

    public class ServicesDetailsViewModel : IMapFrom<ServicesServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}
