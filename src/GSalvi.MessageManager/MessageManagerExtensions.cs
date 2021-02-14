using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace GSalvi.MessageManager
{
    /// <summary>
    /// Defines extension methods to registering dependencies and middlewares.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class MessageManagerExtensions
    {
        /// <summary>
        /// Adds required services to ASP.NET container.
        /// </summary>
        /// <typeparam name="TResource"></typeparam>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddMessageManager<TResource>(
            this IServiceCollection services,
            Action<MessageManagerOptions> setupAction)
            where TResource : class
        {
            if (services is null) throw new ArgumentNullException(nameof(services));
            if (setupAction is null) throw new ArgumentNullException(nameof(setupAction));

            var messageManagerOptions = new MessageManagerOptions();
            setupAction.Invoke(messageManagerOptions);

            if (string.IsNullOrWhiteSpace(messageManagerOptions.ResourcesPath)) throw new ArgumentException("Options ResourcesPath should not be null.");

            services.AddScoped<INotificationManager, NotificationManager>();
            services.AddScoped<INotificationFactory, NotificationFactory>();
            services.AddScoped<IApplicationMassageManager, ApplicationMessageManager<TResource>>();
            services.AddLocalization(options => options.ResourcesPath = messageManagerOptions.ResourcesPath);

            return services;
        }

        /// <summary>
        /// Adds required services to ASP.NET pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="setupAction"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMessageManager(
            this IApplicationBuilder app,
            Action<MessageManagerRequestOptions> setupAction)
        {
            if (app is null) throw new ArgumentNullException(nameof(app));
            if (setupAction is null) throw new ArgumentNullException(nameof(setupAction));

            var requestOptions = new MessageManagerRequestOptions();
            setupAction.Invoke(requestOptions);

            if (requestOptions.DefaultRequestCulture is null) throw new ArgumentException("Options DefaultRequestCulture should not be null.");
            if (requestOptions.SupportedCultures is null) throw new ArgumentException("Options SupportedCultures should not be null.");

            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = requestOptions.DefaultRequestCulture;
                options.SupportedCultures = requestOptions.SupportedCultures;
                options.SupportedUICultures = requestOptions.SupportedCultures;
            });

            return app;
        }
    }
}
