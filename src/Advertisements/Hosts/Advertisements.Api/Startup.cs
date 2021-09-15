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
                .AddCors() // �������� ������ Cross-Origin Requests
                .AddApplicationModule(Configuration) // �������������� ����� ��������
                .AddHttpContextAccessor() // ������������� ��� ����������� ��� HTTP ���������� �� ��������� HTTP-�������.
                .AddDataAccessModule(configuration =>


                    configuration.InSqlServer(Configuration.GetConnectionString("Connection_Skarfe"))

                ); // ����������� � �� ����� ���������� � "ConnectionString"


            services.AddSwaggerModule();


            //������������ Mapster
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
            // ������������ �������� ������������� �������� ���-��������� �������� � �����, 
            // �������� �� ����, ������� ����������� ���-��������. 
            // ��� ����������� ���������� ��������� ����������� �������������. 
            // �������� ���� �� ������������� �� ��������� ������������ ����� 
            // ������ ���������������� ������ � ������� �����. 
            // ������ ����� ������������� ��������� ������ ������ ������ ������� � ���������� �� ������ ����������.
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            // In the Startup.Configure method, 
            // enable the middleware for serving the generated JSON document 
            // and the Swagger UI:
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PublicApi v1"));
            
            // ��������� �������������� ��������
            app.UseApplicationException();


            // ������������� �������� �� ������������� �������� HTTP-��������
            // � �������� ���� �������� ����������� �������� ������ ����������. 
            app.UseRouting();

            // �������� ����� - ��� ������� ���������� ������������ ���� ��������� ��������.
            // �������� ����� ������������ � ���������� � ������������� ��� ������� ����������. 
            // ������� ������������� �������� ����� ����� ��������� �������� �� 
            // URL-������ ������� � ������������� ��� �������� ��� ��������� �������. 
            // ��������� ���������� � �������� ������ �� ����������, ������������� 
            // ����� ����� ������������ URL-������, ������� �������������� � ��������� �������.
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}