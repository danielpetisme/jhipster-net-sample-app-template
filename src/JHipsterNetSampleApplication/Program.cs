using JHipsterNet.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace JHipsterNetSampleApplication {
    public class Program {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .PrintBanner()
                .Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(params string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseSerilog((ctx, config) => {
                    config.Enrich.WithThreadId();
                    config.ReadFrom.Configuration(ctx.Configuration);
                })
                .UseStartup<Startup>();
        }
    }
}
