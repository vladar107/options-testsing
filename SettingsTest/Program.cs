using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SettingsTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel();
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:5010/");
                })
                .UseDefaultServiceProvider(options => options.ValidateScopes = false);
    }
}