namespace ZazasCleaningService.Services.Models.Receipts
{
    using System;
    using System.Collections.Generic;

    using ZazasCleaningService.Data.Models;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;

    public class ReceiptProductsServiceModel : IMapFrom<ProductReceipt>, IMapTo<ProductReceipt>
    {
        public int Id { get; set; }

        public string IssuedOnPicture { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<OrderProductsServiceModel> ProductOrders { get; set; }

        public string RecipientId { get; set; }

        public ApplicationUserServiceModel Recipient { get; set; }
    }
}
