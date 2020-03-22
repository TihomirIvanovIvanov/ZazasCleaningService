namespace ZazasCleaningService.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ZazasCleaningService.Data.Models;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> order)
        {
            order
                .HasOne(x => x.Receipt)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.ReceiptId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
