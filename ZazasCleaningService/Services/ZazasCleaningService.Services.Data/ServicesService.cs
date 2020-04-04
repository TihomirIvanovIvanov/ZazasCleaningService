namespace ZazasCleaningService.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Data;
    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Services;

    public class ServicesService : IServicesService
    {
        private readonly ApplicationDbContext dbContext;

        public ServicesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateServiceAsync(ServicesServiceModel servicesServiceModel)
        {
            var service = AutoMapperConfig.MapperInstance.Map<Service>(servicesServiceModel);

            await this.dbContext.Services.AddAsync(service);
            await this.dbContext.SaveChangesAsync();

            return service.Id;
        }

        public IQueryable<ServicesServiceModel> GetAllServicesAsync()
        {
            var allServices = this.dbContext.Services.To<ServicesServiceModel>();

            return allServices;
        }

        public async Task<ServicesServiceModel> GetByIdAsync(int id)
        {
            var service = await this.dbContext.Services.To<ServicesServiceModel>()
                .FirstOrDefaultAsync(service => service.Id == id);

            return service;
        }
    }
}
