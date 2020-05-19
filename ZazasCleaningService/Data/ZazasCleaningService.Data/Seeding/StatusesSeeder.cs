namespace ZazasCleaningService.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ZazasCleaningService.Data.Models;

    public class StatusesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.OrderStatuses.Any())
            {
                dbContext.OrderStatuses.Add(new OrderStatus
                {
                    Name = "Active",
                });

                dbContext.OrderStatuses.Add(new OrderStatus
                {
                    Name = "Completed",
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
