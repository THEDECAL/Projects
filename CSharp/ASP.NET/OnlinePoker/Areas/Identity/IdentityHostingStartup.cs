using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlinePoker.Models;

[assembly: HostingStartup(typeof(OnlinePoker.Areas.Identity.IdentityHostingStartup))]
namespace OnlinePoker.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OnlinePokerContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OnlinePokerContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<OnlinePokerContext>();
            });
        }
    }
}