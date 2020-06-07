namespace ZazasCleaningService.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
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

            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            await this.dbContext.Services.AddAsync(service);
            await this.dbContext.SaveChangesAsync();

            return service.Id;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var service = await this.GetServiceById(id);
            var serviceOrder = await this.GetServiceOrderByServiceId(service.Id);

            if (serviceOrder != null)
            {
                this.dbContext.ServiceOrders.Remove(serviceOrder);
            }

            service.DeletedOn = DateTime.UtcNow;
            service.IsDeleted = true;

            this.dbContext.Services.Update(service);
            await this.dbContext.SaveChangesAsync();

            return service.IsDeleted;
        }

        public async Task<int> EditAsync(int id, ServicesServiceModel servicesServiceModel)
        {
            var service = await this.GetServiceById(id);

            service.Name = servicesServiceModel.Name;
            service.Picture = servicesServiceModel.Picture;
            service.Description = servicesServiceModel.Description;

            this.dbContext.Services.Update(service);
            await this.dbContext.SaveChangesAsync();

            return service.Id;
        }

        public IQueryable<T> GetAllServices<T>(int? take = null, int skip = 0)
        {
            var allServices = this.dbContext.Services
                .OrderByDescending(service => service.CreatedOn)
                .Skip(skip);

            if (take.HasValue)
            {
                allServices = allServices.Take(take.Value);
            }

            return allServices.To<T>();
        }

        public async Task<ServicesServiceModel> GetServiceByIdAsync(int id)
        {
            var service = await this.dbContext.Services.To<ServicesServiceModel>()
                .FirstOrDefaultAsync(service => service.Id == id);

            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            return service;
        }

        public int GetCountServices()
        {
            var services = this.dbContext.Services.Count();

            if (services == 0)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services;
        }

        private async Task<ServiceOrder> GetServiceOrderByServiceId(int serviceId)
        {
            // TODO: Did i need GetServiceOrderByProductId into orderService?
            var serviceOrder = await this.dbContext.ServiceOrders
                .FirstOrDefaultAsync(s => s.ServiceId == serviceId);

            return serviceOrder;
        }

        private async Task<Service> GetServiceById(int id)
        {
            var service = await this.dbContext.Services
                .FirstOrDefaultAsync(service => service.Id == id);

            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            return service;
        }
    }
}
