using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorControlsSandbox
{
    using Microsoft.AspNetCore.Components.WebAssembly.Infrastructure;
    using Microsoft.JSInterop;
    using Services;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<ISvgItemService, SvgItemService>();
           // builder.Services.AddScoped<BrowserService>();
           //builder.Services.AddScoped<IJSRuntime, JSRunTime>();

            await builder.Build().RunAsync();
        }
    }
}
