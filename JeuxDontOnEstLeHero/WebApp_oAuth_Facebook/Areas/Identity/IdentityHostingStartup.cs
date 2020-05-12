using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp_oAuth_Facebook.Areas.Identity.Data;
using WebApp_oAuth_Facebook.Data;

[assembly: HostingStartup(typeof(WebApp_oAuth_Facebook.Areas.Identity.IdentityHostingStartup))]
namespace WebApp_oAuth_Facebook.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebApp_oAuth_FacebookContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebApp_oAuth_FacebookContextConnection")));

                services.AddDefaultIdentity<WebApp_oAuth_FacebookUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WebApp_oAuth_FacebookContext>();
            });
        }
    }
}