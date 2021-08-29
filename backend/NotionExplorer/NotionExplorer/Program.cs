using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotionApi;
using RestUtil;

namespace NotionExplorer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(ConfigureServices)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        private static void ConfigureServices(HostBuilderContext contextBuilder, IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<NotionExplorerOptions>(o => contextBuilder.Configuration.GetSection(nameof(NotionExplorer)).Bind(o));
            serviceCollection.Configure<NotionClientOptions>(o => contextBuilder.Configuration.GetSection(nameof(NotionClient)).Bind(o));
            serviceCollection.Configure<RestClientOptions>(o => contextBuilder.Configuration.GetSection(nameof(RestClient)).Bind(o));

            serviceCollection.AddTransient<IRestClient, RestClient>();

            ServiceConfigurator.Configure(serviceCollection);

            serviceCollection.AddTransient<INotionClient, NotionClient>();
        }
    }
}