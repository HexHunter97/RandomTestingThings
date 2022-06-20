using Microsoft.AspNetCore.HttpLogging;

namespace ArmaReforger.WorkshopBrowser.Server
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddLogging();
            builder.Services.AddHttpForwarder();
            builder.Services.AddCors(
                options =>
                {
                    options.AddDefaultPolicy(
                        cors =>
                            cors.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                    );
                });
            builder.Services.AddHttpLogging(x => x.LoggingFields = HttpLoggingFields.All);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseHttpLogging();
            app.UseMiddleware<ProxyMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseCors();
            app.MapFallbackToFile("index.html");

            await app.RunAsync();
        }
    }
}