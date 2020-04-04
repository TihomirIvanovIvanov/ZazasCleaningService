namespace ZazasCleaningService.Web.ViewModels.Services.Delete
{
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;

    public class ServicesDeleteViewModel : IMapFrom<ServicesServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}
