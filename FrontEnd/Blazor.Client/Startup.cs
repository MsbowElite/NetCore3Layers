using System.Net.Http;
using Blazor.Server;
using Blazor.Server.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.ClientApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<HttpClient>(s =>
            {
                var client = new HttpClient(){ BaseAddress = new System.Uri("https://localhost:5001/") };
                return client;
            });

            //Base para dados de teste
            //services.AddScoped<ICustomerDataService, CustomerDataService>();
            services.AddScoped<ICustomerDataService, CustomerDataService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
