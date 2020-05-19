namespace ZazasCleaningService.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Common;
    using ZazasCleaningService.Data.Models;

    public class StatusesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.OrderStatuses.Any())
            {
                dbContext.OrderStatuses.Add(new OrderStatus
                {
                    Name = GlobalConstants.StatusActive,
                });

                dbContext.OrderStatuses.Add(new OrderStatus
                {
                    Name = GlobalConstants.StatusCompleted,
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
