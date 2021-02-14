using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Reflection;
using Xunit;

namespace GSalvi.MessageManager.UnitTests
{
    public class ApplicationMessageManagerTests
    {
        private readonly ILogger<ApplicationMessageManager<SharedResource>> _logger;
        private readonly Mock<IStringLocalizerFactory> _localizerFactory;
        private readonly Mock<IStringLocalizer> _localizer;
        private readonly LocalizedString _localizedString;
        private readonly ApplicationMessageManager<SharedResource> _appMessageManager;

        public ApplicationMessageManagerTests()
        {
            _logger = NullLogger<ApplicationMessageManager<SharedResource>>.Instance;
            _localizerFactory = new Mock<IStringLocalizerFactory>();
            _localizer = new Mock<IStringLocalizer>();
            _localizedString = new LocalizedString("INVALID_CUSTOMER_EMAIL", "The e-mail '{0}' is invalid.");

            _localizer.Setup(x => x[It.IsAny<string>(), It.IsAny<object[]>()]).Returns(() => _localizedString);
            _localizerFactory.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).Returns(() => _localizer.Object);

            _appMessageManager = new ApplicationMessageManager<SharedResource>(_localizerFactory.Object, _logger);
        }

        [Fact]
        public void Constructor_ShouldThrowsAnException_WhenStringLocalizerFactoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ApplicationMessageManager<SharedResource>(null, _logger));
        }

        [Fact]
        public void Constructor_ShouldThrowsAnException_WhenLoggerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ApplicationMessageManager<SharedResource>(_localizerFactory.Object, null));
        }

        [Fact]
        public void Constructor_ShouldCallCreateMethodFromStringLocalizerFactory()
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.Assembly.FullName);
            _localizerFactory.Verify(x => x.Create(type.Name, assemblyName.Name), Times.Once);
        }

        [Fact]
        public void FindValueByKey_ShouldFindOneItemByItsKey()
        {
            var value = _appMessageManager.FindValueByKey(_localizedString.Name);
            Assert.Equal(_localizedString.Value, value);
        }

        [Fact]
        public void FindValueByKey_ShouldPassKeyAndValueParamsToStringLocalizer()
        {
            var email = "abc@abc";
            var value = _appMessageManager.FindValueByKey(_localizedString.Name, email);
            _localizer.Verify(x => x[_localizedString.Name, email], Times.Once);
        }

        private class SharedResource { }
    }
}
