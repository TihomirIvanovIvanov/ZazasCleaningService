﻿namespace ZazasCleaningService.Web.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ZazasCleaningService.Services.Data;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Orders;
    using ZazasCleaningService.Web.ViewModels.Products.Order;
    using ZazasCleaningService.Web.ViewModels.Services.Order;

    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;

        private readonly IProductsService productsService;

        private readonly IServicesService servicesService;

        public OrdersController(
            IOrdersService ordersService,
            IProductsService productsService,
            IServicesService servicesService)
        {
            this.ordersService = ordersService;
            this.productsService = productsService;
            this.servicesService = servicesService;
        }

        public async Task<IActionResult> CreateOrderProducts(int id)
        {
            var productView = (await this.productsService.GetByIdAsync(id))
                .To<ProductsOrderInputModel>();

            this.ViewData["productId"] = productView.ProductId;
            this.ViewData["name"] = productView.Name;

            return this.View(productView);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderProducts(ProductsOrderInputModel productsOrderInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.CreateOrderProducts));
            }

            var orderProductsServiceModel = productsOrderInputModel.To<OrderProductsServiceModel>();
            orderProductsServiceModel.IssuerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.ordersService.CreateProductOrderAsync(orderProductsServiceModel);

            return this.Redirect("/");
        }

        public async Task<IActionResult> CreateOrderServices(int id)
        {
            var serviceView = (await this.servicesService.GetByIdAsync(id))
                .To<ServicesOrderInputModel>();

            this.ViewData["serviceId"] = serviceView.ServiceId;
            this.ViewData["name"] = serviceView.Name;

            return this.View(serviceView);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderServices(int id, ServicesOrderInputModel servicesOrderInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.CreateOrderServices));
            }

            var orderServicesServiceModel = servicesOrderInputModel.To<OrderServicesServiceModel>();
            orderServicesServiceModel.IssuerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.ordersService.CreateServiceOrderAsync(orderServicesServiceModel);

            return this.Redirect("/");
        }

        public async Task<IActionResult> AllProductsOrders()
        {
            var productsOrder = await this.ordersService.GetAllProductOrdersAsync()
                   .To<AllProductsOrdersViewModel>().ToListAsync();

            this.ViewData["productsData"] = productsOrder.Select(productOrder => new AllProductsOrdersViewModel
            {
                ProductOrderId = productOrder.ProductOrderId,
                ProductName = productOrder.ProductName,
            }).ToList();

            return this.View();
        }

        public async Task<IActionResult> ProductOrdersDetails(int id)
        {
            var productOrdersDetailsView = (await this.ordersService.GetProductOrdersByIdAsync(id))
                .To<ProductOrdersDetailsViewModel>();

            return this.View(productOrdersDetailsView);
        }

        public async Task<IActionResult> AllServicesOrders()
        {
            var servicesOrder = await this.ordersService.GetAllServiceOrdersAsync()
                   .To<AllServicesOrdersViewModel>().ToListAsync();

            this.ViewData["servicesData"] = servicesOrder.Select(serviceOrder => new AllServicesOrdersViewModel
            {
                ServiceOrderId = serviceOrder.ServiceOrderId,
                ServiceName = serviceOrder.ServiceName,
            }).ToList();

            return this.View();
        }
    }
}
