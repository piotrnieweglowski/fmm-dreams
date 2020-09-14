using fmmApp.Models;
using fmmApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Essentials;

namespace fmmApp
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static void Init()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            string[] names = executingAssembly.GetManifestResourceNames();
            using (var stream = executingAssembly.GetManifestResourceStream("fmmApp.appsettings.json"))
            {
                var host = new HostBuilder()
                   .ConfigureHostConfiguration(c =>
                   {
                       c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                       c.AddJsonStream(stream);
                   })
                   .ConfigureServices((c, x) =>
                   {
                       ConfigureServices(c, x);
                   })
                   .Build();
               ServiceProvider = host.Services;
            }
        }

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddTransient<IDataStore<Dreamer>, DreamersDataStore>();
            services.AddTransient<IDataStore<Sponsor>, SponsorsDataStore>();
            services.AddHttpClient<FmmClient>(x => x.BaseAddress = new Uri(ctx.Configuration.GetValue<string>("ApiEndpoint")));
            services.AddSingleton<JsonSerializer>();
        }
    }
}
