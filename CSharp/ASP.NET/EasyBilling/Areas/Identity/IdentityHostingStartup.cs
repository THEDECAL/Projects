using System;
using EasyBilling.Data;
using EasyBilling.Models.Pocos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EasyBilling.Areas.Identity.IdentityHostingStartup))]
namespace EasyBilling.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BillingDbContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("HomeConnection"/*"DefaultConnection"*/)));
                services.AddDefaultIdentity<IdentityAccount>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<BillingDbContext>();
            });
        }
    }
}