namespace ZazasCleaningService.Web.ViewModels.Services.All
{
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;

    public class ServicesAllViewModel : IMapFrom<ServicesServiceModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public int PagesCount { get; set; }

        public int CurrentPage { get; set; }
    }
}
