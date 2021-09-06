using MapsterMapper;
using Sev1.Advertisements.Api.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sev1.Advertisements.Application.MapProfiles;
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
                .AddCors()
                .AddApplicationModule(Configuration)
                .AddHttpContextAccessor()
                .AddDataAccessModule(configuration =>


                    configuration.InSqlServer(Configuration.GetConnectionString("SqlServerDb"))

                );


            services.AddSwaggerModule();

            //  Adding Angular ClientApp
            //  https://rramname.medium.com/add-angular-7-0-client-application-to-asp-net-core-2-2-web-api-project-ce1617d1d38d
            //
            //  Need to install:
            //    Microsoft.AspNetCore.SpaServices
            //    Microsoft.AspNetCore.SpaServices.Extensions
            //    Microsoft.CodeAnalysis
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });


            //Mapster
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

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PublicApi v1"));
            app.UseApplicationException();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


            //  Adding Angular ClientApp
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }






            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}