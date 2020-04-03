namespace ZazasCleaningService.Services.Data
{
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Services;

    public interface IServicesService
    {
        Task<int> CreateServiceAsync(ServicesServiceModel servicesServiceModel);
    }
}
