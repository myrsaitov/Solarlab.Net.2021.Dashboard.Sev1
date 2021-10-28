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
using Sev1.Advertisements.Application.Interfaces.Category;
using Sev1.Advertisements.Application.Implementations.Category;
using Sev1.Advertisements.Application.Interfaces.Advertisement;
using Sev1.Advertisements.Application.Implementations.Advertisement;
using Sev1.Advertisements.Application.Interfaces.Tag;
using Sev1.Advertisements.Application.Implementations.Tag;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System;
using Sev1.Advertisements.Contracts.ApiClients.User;

namespace Sev1.Advertisements.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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

                // Инжектирование наших сервисов
                .AddScoped<ICategoryService, CategoryServiceV1>()
                .AddScoped<IAdvertisementService, AdvertisementServiceV1>()
                .AddScoped<ITagService, TagServiceV1>()

                // Инжектирование API-клиента User
                .AddScoped<IUserApiClient, UserApiClient>()

                // Инкапсулирует всю специфичную для HTTP информацию об отдельном HTTP-запросе.
                .AddHttpContextAccessor()

                // Подключение к БД через информацию в "ConnectionString"
                .AddDataAccessModule(configuration =>
                    configuration.InSqlServer(Configuration.GetConnectionString("SqlServerDb"))
                )

            // Подключение Swagger
                .AddSwaggerGen(c =>
                {
                    c.CustomSchemaIds(type => type.FullName.Replace("+", "_"));
                    c.SwaggerDoc(
                        "v1", 
                        new OpenApiInfo 
                        { 
                            Title = "PublicApi", 
                            Version = "v1" 
                        });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                        Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n
                        Example: 'Bearer 12345abcdef'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                            },

                            new List<string>()
                        }
                    });

                    // Locate the XML file being generated by ASP.NET...
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                    //... and tell Swagger to use those XML comments.
                    c.IncludeXmlComments(xmlPath);
                });

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

            // AddScoped():
            //
            // This method creates a Scoped service.
            // A new instance of a Scoped service is created
            // once per request within the scope.
            // For example, in a web application it creates 1 instance
            // per each http request but uses the same instance
            // in the other calls within that same web request.
            services.AddScoped<IMapper, ServiceMapper>();
            
            services.AddApplicationException(config => { config.DefaultErrorStatusCode = 500; });
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
            // and the Swagger UI:
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PublicApi v1"));

            // Обработка исключительных ситуаций
            app.UseApplicationException();

            // This middleware is used to returns static files and
            // short-circuits further request processing.   
            app.UseStaticFiles();

            // Маршрутизация отвечает за сопоставление входящих HTTP-запросов
            // и отправку этих запросов исполняемым конечным точкам приложения.
            // This middleware is used to route requests.
            app.UseRouting();

            //app.UseAuthentication();
            
            // This middleware is used to authorizes a user to access
            // secure resources.
            //app.UseAuthorization();

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