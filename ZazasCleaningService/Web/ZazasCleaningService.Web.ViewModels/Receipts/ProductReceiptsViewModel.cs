﻿namespace ZazasCleaningService.Web.ViewModels.Receipts
{
    using System;
    using System.Linq;

    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Receipts;

    public class ProductReceiptsViewModel : IMapFrom<ReceiptProductsServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Products { get; set; }

        public string FormattedCreatedOn => this.CreatedOn.ToString("MM/dd/yyyy HH:mm");

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ReceiptProductsServiceModel, ProductReceiptsViewModel>()
                .ForMember(
                    destination => destination.Products,
                    options => options.MapFrom(origin => origin.OrderProducts.Sum(order => order.Quantity)));
        }
    }
}
