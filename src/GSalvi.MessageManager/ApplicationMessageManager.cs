using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GSalvi.MessageManager.UnitTests")]
namespace GSalvi.MessageManager
{
    internal class ApplicationMessageManager<TResource> : IApplicationMassageManager
        where TResource : class
    {
        private readonly IStringLocalizer _localizer;
        private readonly ILogger<ApplicationMessageManager<TResource>> _logger;

        public ApplicationMessageManager(
            IStringLocalizerFactory factory,
            ILogger<ApplicationMessageManager<TResource>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            if (factory is null) throw new ArgumentNullException(nameof(factory));

            var type = typeof(TResource);
            var assemblyName = new AssemblyName(type.Assembly.FullName);

            _localizer = factory.Create(type.Name, assemblyName.Name);
        }

        public string FindValueByKey(string key, params string[] valueParams)
        {
            var value = _localizer[key, valueParams].Value;
            _logger.LogInformation("----- Found value '{value}' with key '{key}' from localizer.", value, key);

            return value;
        }
    }
}
