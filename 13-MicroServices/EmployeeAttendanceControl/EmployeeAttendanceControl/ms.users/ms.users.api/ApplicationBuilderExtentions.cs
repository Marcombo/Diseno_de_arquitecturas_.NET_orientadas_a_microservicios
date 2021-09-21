using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ms.users.api.Consumers;

namespace ms.users.api
{
    /*public static class ConsumerMiddleware
    {
        //the simplest way to store a single long-living object, just for example.
        private static IConsumer _consumer { get; set; }

        public static IApplicationBuilder UseRabbitConsumer(this IApplicationBuilder app, IConsumer consumer)
        {
            //_consumer = app.ApplicationServices.GetService<UsersConsumer>();
            _consumer = consumer;

            var lifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            lifetime.ApplicationStarted.Register(OnStarted);

            
            lifetime.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            _consumer.Subscribe();
        }

        private static void OnStopping()
        {
            _consumer.Unsubscribe();
        }
    }*/
}
