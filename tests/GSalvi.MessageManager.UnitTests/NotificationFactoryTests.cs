using Moq;
using System;
using Xunit;

namespace GSalvi.MessageManager.UnitTests
{
    public class NotificationFactoryTests
    {
        private readonly Mock<IApplicationMassageManager> _appMessageManager;
        private readonly NotificationFactory _notificationFactory;
        private readonly string _key;
        private readonly string _value;
        private readonly string[] _valueParams;

        public NotificationFactoryTests()
        {
            _key = "INVALID_CUSTOMER_EMAIL";
            _value = "The e-mail 'abc@abc.com' is invalid.";
            _valueParams = new string[] { "abc @abc.com" };
            _appMessageManager = new Mock<IApplicationMassageManager>();
            _notificationFactory = new NotificationFactory(_appMessageManager.Object);
        }

        [Fact]
        public void Constructor_ShouldThrowsAnException_WhenApplicationMessageManagerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new NotificationFactory(null));
        }

        [Fact]
        public void CreateWithLocalizedValue_ShouldReturnOneItemWithValueFromApplicationMessageManager()
        {
            _appMessageManager.Setup(x => x.FindValueByKey(_key, _valueParams)).Returns(() => _value);
            var notification = _notificationFactory.CreateWithLocalizedValue(_key, _valueParams);

            Assert.Equal(_value, notification.Value);
            Assert.Equal(_key, notification.Key);
        }

        [Fact]
        public void CreateWithLocalizedValue_ShouldCallApplicationMessageManagerWithKeyAndValueParams()
        {
            var notification = _notificationFactory.CreateWithLocalizedValue(_key, _valueParams);
            _appMessageManager.Verify(x => x.FindValueByKey(_key, _valueParams), Times.Once);
        }
    }
}
