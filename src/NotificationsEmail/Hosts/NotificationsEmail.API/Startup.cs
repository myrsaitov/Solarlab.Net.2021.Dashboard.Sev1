using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationsEmail.Services;
using NotificationsEmail.Services.Interfaces;
using NotificationsEmail.Notification;
using NotificationsEmail.Mapper;
using NotificationsEmail.Repository;
using Microsoft.OpenApi.Models;
using System.IO;

namespace NotificationsEmail.API
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
            string connection = Configuration.GetConnectionString("Connection_Skarfe");

            services.AddDbContext<NotificationEmailDBContext>(options =>
                    options.UseSqlServer(connection, b => b.MigrationsAssembly("NotificationsEmail.Migrations")));

            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(LetterMapperProfile));

            services.AddScoped<INotificationEmailRepository, NotificationEmailRepository>();

            services.AddSingleton<INotificationEmailService, NotificationEmailService>();

            services.AddSingleton<IEmailSender, SmtpNotifier>();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "NotificationsEmail.API.xml");
                swagger.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseStaticFiles();

            //Запуск сервиса нотификации (для проверки пропущенных писем в БД)
            app.ApplicationServices.GetService<INotificationEmailService>();

            //app.UseHttpsRedirection();
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
