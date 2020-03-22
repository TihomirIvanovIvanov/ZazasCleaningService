namespace ZazasCleaningService.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ZazasCleaningService.Data.Models;

    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> receipt)
        {
            receipt
                .HasOne(x => x.Order)
                .WithOne(x => x.Receipt)
                .HasForeignKey<Receipt>(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
