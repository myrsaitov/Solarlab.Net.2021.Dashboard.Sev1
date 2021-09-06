using MapsterMapper;
using Sev1.Advertisements.Api.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sev1.Advertisements.Mapper.MapProfiles;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;

using System;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Sev1.Advertisements.Infrastructure;
using Sev1.Advertisements.Infrastructure.DataAccess;

namespace Sev1.Advertisements.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services
                .AddCors() // Добавить сервис Cross-Origin Requests
                .AddApplicationModule(Configuration) // Инжектирование наших сервисов
                .AddHttpContextAccessor() // Инкапсулирует всю специфичную для HTTP информацию об отдельном HTTP-запросе.
                .AddDataAccessModule(configuration =>


                    configuration.InSqlServer(Configuration.GetConnectionString("SqlServerDb"))

                ); // Подключение к БД через информацию в "ConnectionString"


            services.AddSwaggerModule();


            //Инженктируем Mapster
            services.AddSingleton(CategoryMapProfile.GetConfiguredMappingConfig());
            services.AddSingleton(AdvertisementMapProfile.GetConfiguredMappingConfig());
            services.AddSingleton(TagMapProfile.GetConfiguredMappingConfig());

            services.AddScoped<IMapper, ServiceMapper>();
            
            services.AddApplicationException(config => { config.DefaultErrorStatusCode = 500; });
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
            // and the Swagger UI:
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PublicApi v1"));
            
            // Обработка исключительных ситуаций
            app.UseApplicationException();


            // Маршрутизация отвечает за сопоставление входящих HTTP-запросов
            // и отправку этих запросов исполняемым конечным точкам приложения. 
            app.UseRouting();

            // Конечные точки - это единицы приложения исполняемого кода обработки запросов.
            // Конечные точки определяются в приложении и настраиваются при запуске приложения. 
            // Процесс сопоставления конечных точек может извлекать значения из 
            // URL-адреса запроса и предоставлять эти значения для обработки запроса. 
            // Используя информацию о конечных точках из приложения, маршрутизация 
            // также может генерировать URL-адреса, которые сопоставляются с конечными точками.
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}