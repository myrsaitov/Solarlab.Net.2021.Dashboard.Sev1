using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using MapsterMapper;
using Sev1.Advertisements.Api.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sev1.Advertisements.MapsterMapper.MapProfiles;
using Microsoft.Extensions.Hosting;
using Sev1.Advertisements.DataAccess;
using Sev1.Advertisement.Api;
using Sev1.Accounts.Contracts.ApiClients.User;
using Sev1.Accounts.Contracts.UserProvider;
using Sev1.Accounts.Contracts.Authorization;
using Sev1.Advertisements.AppServices;
using Sev1.UserFiles.Contracts.ApiClients.UserFilesUpload;

namespace Sev1.Advertisements.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
            // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0
            //
            // Сделано по примерм:
            // https://referbruv.com/blog/accessing-environment-variables-in-aspnet-core-inside-host-and-startup/
            // https://stackoverflow.com/questions/39231951/how-do-i-access-configuration-in-any-class-in-asp-net-core
            // https://dusted.codes/dotenv-in-dotnet
            // https://enlabsoftware.com/development/dotnet-core-environment-how-config-examples.html
            // https://www.reddit.com/r/dotnet/comments/xp7c7e/how_do_i_replace_a_value_in_appsettingsjson_with/
            
            var builder = new ConfigurationBuilder();
            
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                // Подключение основного файла "appsettings.json" (обязательно)
                .AddJsonFile("appsettings.json", optional: false)
                // Замещение значений из файла "appsettings.{ENV}.json" (необязательно)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                // Замещение значений из переменных среды
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
            
        }

        // Represents a set of key/value application configuration properties.
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        // Это опциональный метод в классе Startup,
        // который используется для настройки сервисов
        // для приложения.Когда в приложение поступает
        // какой-либо запрос, сначала вызывается метод
        // ConfigureService.
        // Метод ConfigureServices включает параметр
        // IServiceCollection для регистрации сервисов.
        // Этот метод должен быть объявлен с модификатором
        // доступа public, чтобы среда могла читать контент
        // из метаданных.
        // https://habr.com/ru/company/otus/blog/542494/
        public void ConfigureServices(IServiceCollection services)
        {
            //
            // Summary:
            //     Configures Newtonsoft.Json specific features such as input and output formatters.
            //
            // Parameters:
            //   builder:
            //     The Microsoft.Extensions.DependencyInjection.IMvcBuilder.
            //
            //   setupAction:
            //     Callback to configure Microsoft.AspNetCore.Mvc.MvcNewtonsoftJsonOptions.
            //
            // Returns:
            //     The Microsoft.Extensions.DependencyInjection.IMvcBuilder.
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services

                // Добавить сервис Cross-Origin Requests
                .AddCors()

                // Инжектирование сервисов приложения
                .AddApplicationModule(Configuration);

/*
            string kestrelCertificatesDefaultPassword = Environment.GetEnvironmentVariable("ASPNETCORE_Kestrel__Certificates__Default__Password");
            string kestrelCertificatesDefaultPath = Environment.GetEnvironmentVariable("ASPNETCORE_Kestrel__Certificates__Default__Path");
            
            if (!(string.IsNullOrWhiteSpace(kestrelCertificatesDefaultPassword) &&
                  string.IsNullOrWhiteSpace(kestrelCertificatesDefaultPassword)))
            {
                services
                    // Добавляем фабрику API-клиентов
                    // https://stackoverflow.com/questions/54547937/how-to-config-certificate-with-httpclientfactory
                    // https://stackoverflow.com/questions/63879068/net-core-httpclientfactory-how-to-configure-configureprimaryhttpmessagehandle
                    .AddHttpClient("signed")
                    .ConfigurePrimaryHttpMessageHandler(() =>
                        {
                            var handler = new HttpClientHandler();
                            var certificate = new X509Certificate2(
                                fileName: kestrelCertificatesDefaultPath,
                                password: kestrelCertificatesDefaultPassword);

                            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                            handler.ClientCertificates.Add(certificate);

                            return handler;
                        }
                    );
            }*/
            services.AddHttpClient();
            
            services

                // Инжектирование API-клиента User
                .AddTransient<IUserValidateApiClient, UserValidateApiClient>()

                // Инжектирование API-клиента UserFiles
                .AddTransient<IUserFilesUploadApiClient, UserFilesUploadApiClient>()

                // Инжектирование UserProvider
                .AddTransient<IUserProvider, UserProvider>()

                // Инкапсулирует всю специфичную для HTTP информацию об отдельном HTTP-запросе.
                .AddHttpContextAccessor()

                // Подключение к БД через информацию в "ConnectionString"
                .AddDataAccessModule(configuration => 
                    configuration.InPostgress(Configuration.GetConnectionString("PostgresAdvertisementsDb"))
                    //configuration.InSqlServer(Configuration.GetConnectionString("MsSqlAdvertisementsDb"))
                );

            // Подключение Swagger
            if (Configuration.GetSection("SwaggerOptions:UseSwagger").Get<bool>())
            {
                services.AddSwaggerModule();
            }

            // AddTransient
            // Transient(временные) объекты всегда разные; каждому контроллеру и сервису предоставляется новый инстанс.
            // Scoped
            // Scoped — используются одни и те же объекты в пределах одного запроса, но разные в разных запросах.
            // Singleton
            // Singleton — объекты одни и те же для каждого объекта и каждого запроса.
            // https://habr.com/ru/company/otus/blog/542494/

            // Инжектируем Mapster
            //
            // AddSingleton():
            //
            // As the name implies, AddSingleton() method 
            // creates a Singleton service. A Singleton service 
            // is created when it is first requested. 
            // This same instance is then used by all the 
            // subsequent requests. So in general, a Singleton service 
            // is created only one time per application 
            // and that single instance is used throughout 
            // the application life time.
            services.AddSingleton(CategoryMapProfile.GetConfiguredMappingConfig());
            services.AddSingleton(AdvertisementMapProfile.GetConfiguredMappingConfig());
            services.AddSingleton(TagMapProfile.GetConfiguredMappingConfig());
            services.AddSingleton(RegionMapProfile.GetConfiguredMappingConfig());

            // AddScoped():
            //
            // This method creates a Scoped service.
            // A new instance of a Scoped service is created
            // once per request within the scope.
            // For example, in a web application it creates 1 instance
            // per each http request but uses the same instance
            // in the other calls within that same web request.
            services.AddScoped<IMapper, ServiceMapper>();

            // Middleware обработки исключительных ситуаций
            services.AddApplicationException(config =>
            {
                config.DefaultErrorStatusCode = 500; // Статус код по умолчанию
            });
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        //
        // Метод Configure используется для указания того,
        // как приложение будет отвечать на каждый HTTP-запрос.
        // Этот метод в основном используется для регистрации
        // промежуточного программного обеспечения(middleware)
        // в HTTP-конвейере. Этот метод принимает параметр
        // IApplicationBuilder вместе с некоторыми другими сервисами,
        // такими как IHostingEnvironment и ILoggerFactory.
        // Как только мы добавим какой-либо сервис в метод ConfigureService,
        // он будет доступен для использования в методе Configure.
        // https://habr.com/ru/company/otus/blog/542494/

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Промежуточное программное обеспечение (Middleware) — это новая концепция,
            // представленная в Asp.net Core.
            //
            // Как правило, каждое middleware обрабатывает входящие запросы
            // и передает выполнение следующему middleware для дальнейшей обработки.
            // Но middleware-компонент также может решить не вызывать
            // следующую часть middleware в конвейере. Это называется
            // замыканием(short - circuiting) или завершением конвейера
            // запросов. Замыкание зачастую желательно, поскольку оно
            // позволяет избежать ненужной работы. Например, если это
            // запрос статического файла, такого как файл CSS, JavaScript,
            // изображение и т. д., middleware - компонент для статических
            // файлов может обработать и обслужить этот запрос, а затем
            // замкнуть остальную часть конвейера.
            // https://habr.com/ru/company/otus/blog/528692/

            //Init migrations
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            db.Database.Migrate();

            if (env.IsDevelopment())
            {
                // This middleware is used reports
                // app runtime errors in development environment.
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // This middleware is catches exceptions thrown in production environment.   
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days.
                // You may want to change this for production scenarios,
                // see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();// adds the Strict-Transport-Security header. 
            }

            // This middleware is used to redirects HTTP requests to HTTPS.  
            app.UseHttpsRedirection();

            // Cross-Origin Requests
            // Безопасность браузера предотвращает отправку веб-страницей запросов в домен, 
            // отличный от того, который обслуживает веб-страницу. 
            // Это ограничение называется политикой одинакового происхождения. 
            // Политика того же происхождения не позволяет вредоносному сайту 
            // читать конфиденциальные данные с другого сайта. 
            // Иногда может потребоваться разрешить другим сайтам делать запросы к приложению из разных источников.
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            // In the Startup.Configure method, 
            // enable the middleware for serving the generated JSON document 
            // and the Swagger UI.
            // This line enables the app to use Swagger, 
            // with the configuration in the ConfigureServices method.
            if (Configuration.GetSection("SwaggerOptions:UseSwagger").Get<bool>())
            {
                app.UseSwagger();
            }

            // This line enables Swagger UI, 
            // which provides us with a nice, simple UI 
            // with which we can view our API calls.
            app.UseSwaggerUI(c =>
            { 
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "PublicApi v1");
            });

            // Обработка исключительных ситуаций
            app.UseApplicationException();

            // This middleware is used to returns static files and
            // short-circuits further request processing.   
            app.UseStaticFiles();

            // Маршрутизация отвечает за сопоставление входящих HTTP-запросов
            // и отправку этих запросов исполняемым конечным точкам приложения.
            // This middleware is used to route requests.
            app.UseRouting();

            //     Adds the Microsoft.AspNetCore.Authentication.AuthenticationMiddleware to the
            //     specified Microsoft.AspNetCore.Builder.IApplicationBuilder, which enables authentication
            //     capabilities.
            app.UseAuthentication();

            // This middleware is used to authorizes a user to access
            // secure resources.
            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            // Конечные точки - это единицы приложения исполняемого кода обработки запросов.
            // Конечные точки определяются в приложении и настраиваются при запуске приложения. 
            // Процесс сопоставления конечных точек может извлекать значения из 
            // URI-адреса запроса и предоставлять эти значения для обработки запроса. 
            // Используя информацию о конечных точках из приложения, маршрутизация 
            // также может генерировать URI-адреса, которые сопоставляются с конечными точками.
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}