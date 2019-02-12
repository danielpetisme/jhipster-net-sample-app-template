using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace JHipsterNet.Hosting {
    public static class WebHostExtensions {
        public static IWebHost PrintBanner(this IWebHost @this)
        {
            var env = @this.Services.GetRequiredService<IHostingEnvironment>();
            var banner = System.IO.File.ReadAllText($"{env.ContentRootPath}/banner.txt")
                .Replace("${AnsiColor.RED}", "\u001b[31m")
                .Replace("${AnsiColor.GREEN}", "\u001b[32m")
                .Replace("${AnsiColor.WHITE}", "\u001b[37m")
                .Replace("${AnsiColor.MAGENTA}", "\u001b[35m")
                .Replace("${AnsiColor.BRIGHT_BLUE}", "\u001b[36m")
                .Replace("${AnsiColor.DEFAULT}", "\u001b[39m");
            Console.Write(banner);
            return @this;
        }
    }
}
