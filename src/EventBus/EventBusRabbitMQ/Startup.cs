using EventBusRabbitMQ.Interfaces;
using EventBusRabbitMQ.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationsEmail.Services;
using RabbitMQ.Client;

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
