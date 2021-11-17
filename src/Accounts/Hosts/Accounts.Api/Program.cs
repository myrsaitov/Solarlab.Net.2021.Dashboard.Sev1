using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Sev1.Accounts.Api
{
    // Хост настраивается, строится и запускается в классе Program
    public class Program
    {
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            // Run()
            // Этот метод добавляет middleware-компонент в виде Run[Middleware],
            // который выполнится в конце конвейера.Как правило,
            // он действует как замыкающее middleware и добавляется
            // в конце конвейера запросов, поскольку не может вызывать
            // следующий middleware - компонент.
            // https://habr.com/ru/company/otus/blog/528692/
        }

        // Абстракция инициализации программы
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}