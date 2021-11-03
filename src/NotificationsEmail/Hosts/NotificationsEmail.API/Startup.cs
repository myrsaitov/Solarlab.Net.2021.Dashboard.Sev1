using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationsEmail.Services;
using NotificationsEmail.Services.Interfaces;
using NotificationsEmail.Notification;
using NotificationsEmail.Mapper;
using NotificationsEmail.Repository;
using Microsoft.OpenApi.Models;
using System.IO;
using NotificationsEmail.ScheduledSender;
using Quartz.Spi;
using Quartz;
using EventBusRabbitMQ.Interfaces;
using EventBusRabbitMQ;
using RabbitMQ.Client;

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

#if DEBUG
            string connection = Configuration.GetConnectionString("RemoteConnection");
#else
            string connection = Configuration.GetConnectionString("DefaultConnection");
#endif
            services.AddDbContext<NotificationEmailDBContext>(options =>
                    options.UseSqlServer(connection, b => b.MigrationsAssembly("NotificationsEmail.Migrations")));

            services.AddControllersWithViews();

            // ��������������
            services.AddAutoMapper(typeof(LetterMapperProfile));
            services.AddScoped<INotificationEmailRepository, NotificationEmailRepository>();
            services.AddScoped<IEmailSender, SmtpNotifier>();

            // ������ �����������
            services.AddScoped<INotificationEmailService, NotificationEmailService>();

            // ������ �������� ����� �� �� �� ����������
            services.AddHostedService<NotificationScheduler>();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ScheduledNotificationService>();

            // RabbitMQ Subscriber
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory
                {
                    Uri = new System.Uri(Configuration["RabbitMQConnection"])
                };

                return new RabbitMQConnection(factory);
            });
            services.AddSingleton<IRabbitMQSubscriber>(x => new RabbitMQSubscriber(
                x.GetService<IRabbitMQConnection>(), 
                "Notification.Email.Queue", 
                "NotificationEmail.*"));
            services.AddHostedService<NotificationEmailEventBusSubscriber>();

            // Swagger
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
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
