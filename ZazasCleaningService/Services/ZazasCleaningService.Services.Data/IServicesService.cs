namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Services;

    public interface IServicesService
    {
        Task<int> CreateServiceAsync(ServicesServiceModel servicesServiceModel);

        IQueryable<ServicesServiceModel> GetAllServicesAsync(int? take = null, int skip = 0);

        int GetCountServices();

        Task<ServicesServiceModel> GetServiceByIdAsync(int id);

        Task<int> EditAsync(int id, ServicesServiceModel servicesServiceModel);

        Task<bool> DeleteByIdAsync(int id);
    }
}
