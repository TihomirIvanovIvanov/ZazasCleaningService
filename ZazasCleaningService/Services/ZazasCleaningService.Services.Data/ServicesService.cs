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

            await this.dbContext.Services.AddAsync(service);
            await this.dbContext.SaveChangesAsync();

            return service.Id;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var service = await this.dbContext.Services.FirstOrDefaultAsync(service => service.Id == id);

            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            // TODO: Did i need GetServiceOrderByProductId into orderService?
            var serviceOrder = this.dbContext.ServiceOrders
                .FirstOrDefault(s => s.ServiceId == service.Id);

            if (serviceOrder == null)
            {
                throw new ArgumentNullException(nameof(serviceOrder));
            }

            this.dbContext.ServiceOrders.Remove(serviceOrder);

            service.DeletedOn = DateTime.UtcNow;
            service.IsDeleted = true;

            await this.dbContext.SaveChangesAsync();
            return service.IsDeleted;
        }

        public async Task<int> EditAsync(int id, ServicesServiceModel servicesServiceModel)
        {
            var service = await this.dbContext.Services.FirstOrDefaultAsync(service => service.Id == id);

            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            service.Name = servicesServiceModel.Name;
            service.Picture = servicesServiceModel.Picture;
            service.Description = servicesServiceModel.Description;

            this.dbContext.Services.Update(service);
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
