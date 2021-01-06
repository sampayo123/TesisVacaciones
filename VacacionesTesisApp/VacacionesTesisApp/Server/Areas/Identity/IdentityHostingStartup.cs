using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VacacionesTesisApp.Server.Data;
using VacacionesTesisApp.Server.Models;

[assembly: HostingStartup(typeof(VacacionesTesisApp.Server.Areas.Identity.IdentityHostingStartup))]
namespace VacacionesTesisApp.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}