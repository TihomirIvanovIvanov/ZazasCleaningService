﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ZazasCleaningService.Web.Areas.Identity.IdentityHostingStartup))]

namespace ZazasCleaningService.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
