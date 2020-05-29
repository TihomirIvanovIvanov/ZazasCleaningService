namespace ZazasCleaningService.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Services.Models.Services;

    public interface IServicesService
    {
        Task<T> CreateServiceAsync<T>(ServicesServiceModel servicesServiceModel);

        IQueryable<T> GetAllServicesAsync<T>(int? take = null, int skip = 0);

        int GetCountServices();

        Task<ServicesServiceModel> GetServiceByIdAsync(int id);

        Task<T> EditAsync<T>(int id, ServicesServiceModel servicesServiceModel);

        Task<T> DeleteByIdAsync<T>(int id);
    }
}
