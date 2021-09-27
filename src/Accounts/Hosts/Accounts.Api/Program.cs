using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Sev1.Advertisements.Api
{
    // Хост настраивается, строится и запускается в классе Program
    public class Program
    {
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Абстракция инициализации программы
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}