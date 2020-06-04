namespace ZazasCleaningService.Services.Data.Tests.Common
{
    using System.Reflection;

    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Products;
    using ZazasCleaningService.Services.Models.Receipts;

    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(ProductsServiceModel).GetTypeInfo().Assembly,
                typeof(Product).GetTypeInfo().Assembly,
                typeof(ReceiptProductsServiceModel).GetTypeInfo().Assembly,
                typeof(ProductReceipt).GetTypeInfo().Assembly,
                typeof(Receipt).GetTypeInfo().Assembly);
        }
    }
}
