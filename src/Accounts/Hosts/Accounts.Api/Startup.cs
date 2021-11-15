using MapsterMapper;
using Sev1.Accounts.Api.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sev1.Accounts.MapsterMapper.MapProfiles;
using Microsoft.Extensions.Hosting;
using Sev1.Accounts.DataAccess;
using Sev1.Avdertisements.Contracts.ApiClients.RegionValidate;
using Sev1.Accounts.AppServices;

namespace Sev1.Accounts.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services

                // Добавить сервис Cross-Origin Requests
                .AddCors()

                // Инжектирование сервисов приложения
                .AddApplicationModule(Configuration)

                // Инкапсулирует всю специфичную для HTTP информацию об отдельном HTTP-запросе.
                .AddHttpContextAccessor()

                // Добавляем фабрику API-клиентов
                .AddHttpClient()

                // Инжектирование API-клиентов
                .AddTransient<IRegionValidateApiClient, RegionValidateApiClient>()

                // Подключение к БД через информацию в "ConnectionString"
                .AddDataAccessModule(configuration =>
#if DEBUG
                    configuration.InSqlServer(Configuration.GetConnectionString("RemoteConnection"))
#else
                    configuration.InSqlServer(Configuration.GetConnectionString("DefaultConnection"))
#endif
                )
                
                // Подключение Identity
                .AddIdentity(Configuration);

            // Подключение Swagger
            services.AddSwaggerModule();

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
            services.AddSingleton(AccountMapProfile.GetConfiguredMappingConfig());

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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Init migrations
            using var scope = app.ApplicationServices.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            db.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

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
            app.UseSwagger();

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

            // Маршрутизация отвечает за сопоставление входящих HTTP-запросов
            // и отправку этих запросов исполняемым конечным точкам приложения. 
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

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