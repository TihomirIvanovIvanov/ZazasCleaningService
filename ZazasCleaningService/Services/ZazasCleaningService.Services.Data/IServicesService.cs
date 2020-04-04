namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Services;

    public interface IServicesService
    {
        Task<int> CreateServiceAsync(ServicesServiceModel servicesServiceModel);

        IQueryable<ServicesServiceModel> GetAllServicesAsync();

        Task<ServicesServiceModel> GetByIdAsync(int id);
    }
}
