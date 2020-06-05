namespace ZazasCleaningService.Services.Data.Tests.Common
{
    using System.Reflection;

    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Comments;
    using ZazasCleaningService.Services.Models.Products;
    using ZazasCleaningService.Services.Models.Receipts;
    using ZazasCleaningService.Services.Models.Services;
    using ZazasCleaningService.Services.Models.Votes;

    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(ProductsServiceModel).GetTypeInfo().Assembly,
                typeof(Product).GetTypeInfo().Assembly,
                typeof(ServicesServiceModel).GetTypeInfo().Assembly,
                typeof(Service).GetTypeInfo().Assembly,
                typeof(ReceiptProductsServiceModel).GetTypeInfo().Assembly,
                typeof(ProductReceipt).GetTypeInfo().Assembly,
                typeof(Receipt).GetTypeInfo().Assembly,
                typeof(VotesServiceModel).GetTypeInfo().Assembly,
                typeof(Vote).GetTypeInfo().Assembly,
                typeof(CommentsServiceModel).GetTypeInfo().Assembly,
                typeof(Comment).GetTypeInfo().Assembly);
        }
    }
}
