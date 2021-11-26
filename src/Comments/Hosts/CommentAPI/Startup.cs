using Comments.API.Filters;
using Comments.Mapper;
using Comments.Repository.Persistance;
using Comments.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using sev1.Accounts.Contracts.UserProvider;
using Sev1.Accounts.Contracts.ApiClients.User;
using Sev1.Accounts.Contracts.Authorization;
using Sev1.Avdertisements.Contracts.ApiClients.AdvertisementValidate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Comments.API
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
            services.AddControllersWithViews();
            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Comments.API.xml");
                c.IncludeXmlComments(filePath);
            });*/

            services
                .AddCors()
                .AddHttpClient()
                .AddTransient<IUserValidateApiClient, UserValidateApiClient>()
                .AddTransient<IAdvertisementValidateApiClient, AdvertisementValidateApiClient>()
                .AddTransient<IUserProvider, UserProvider>()
                .AddHttpContextAccessor();

            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.FullName.Replace("+", "_"));

                //The generated Swagger JSON file will have these properties.
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

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

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Comments.API.xml");
                c.IncludeXmlComments(filePath);
            });

#if DEBUG
            string connection = Configuration.GetConnectionString("RemoteConnection");
#else
            string connection = Configuration.GetConnectionString("DefaultConnection");
#endif

            services.AddDbContext<CommentDBContext>(options =>
                options.UseSqlServer(connection, b => b.MigrationsAssembly("Comments.Migrations")));


            services.AddScoped<ICommentsService, CommentsService>();
            services.AddScoped<CommentsExceptionFilter>();


            services.AddScoped<ICommentsRepository, CommentsRepository>();
            services.AddAutoMapper(typeof(CommentMapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
