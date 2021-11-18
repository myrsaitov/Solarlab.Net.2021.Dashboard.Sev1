using EventBusRabbitMQ.Interfaces;
using EventBusRabbitMQ.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NotificationsEmail.Services;
using RabbitMQ.Client;
using System.IO;

namespace EventBusRabbitMQ
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "EventBusRabbitMQ.xml");
                c.IncludeXmlComments(filePath);
            });



            // RabbitMQ Subscriber
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory
                {
#if DEBUG
                    Uri = new System.Uri(Configuration["DebugLocalRabbitMQConnection"])
#else
                    Uri = new System.Uri(Configuration["DefaultRabbitMQConnection"])
#endif
                };

                return new RabbitMQConnection(factory);
            });
            services.AddSingleton<IRabbitMQSubscriber>(x => new RabbitMQSubscriber(
                x.GetService<IRabbitMQConnection>(),
                "Notification.Email.Queue",
                "NotificationEmail.*"));
            services.AddHostedService<NotificationEmailRabbitMQConsumer>();
            services.AddScoped<IRabbitMQPublisher>(x => new RabbitMQPublisher(x.GetService<IRabbitMQConnection>()));
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
