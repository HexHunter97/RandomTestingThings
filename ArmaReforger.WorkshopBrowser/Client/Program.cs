using ArmaReforger.WorkshopBrowser.Client.Interfaces;
using ArmaReforger.WorkshopBrowser.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Threading.Tasks;

namespace ArmaReforger.WorkshopBrowser.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            Helpers.Version = builder.Configuration.GetValue<string>("version");
            
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddLogging();

            builder.Services.AddHttpClient();
            builder.Services.AddHttpClient(Constants.Clients.Host, client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddHttpClient(
                Constants.Clients.Echo,
                client =>
                {
                    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                    client.DefaultRequestHeaders.Add(WorkshopBrowser.Shared.Constants.ProxyHeaderName, "");
                });

            builder.Services.AddScoped<IWorkshopReader, WorkshopReader>();
            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}