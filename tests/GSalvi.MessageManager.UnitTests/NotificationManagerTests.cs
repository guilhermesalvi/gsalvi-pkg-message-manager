using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace GSalvi.MessageManager.UnitTests
{
    public class NotificationManagerTests
    {
        private readonly ILogger<NotificationManager> _logger;
        private readonly Mock<INotificationFactory> _notificationFactory;
        private readonly Notification _notification;
        private readonly string _key;
        private readonly string _value;
        private readonly string[] _valueParams;
        private readonly NotificationManager _manager;

        public NotificationManagerTests()
        {
            _key = "INVALID_CUSTOMER_EMAIL";
            _value = "The e-mail 'abc@abc.com' is invalid.";
            _valueParams = new string[] { "abc@abc.com" };
            _logger = NullLogger<NotificationManager>.Instance;
            _notificationFactory = new Mock<INotificationFactory>();
            _notification = new Notification(_key, _value);
            _manager = new NotificationManager(_notificationFactory.Object, _logger);
        }

        [Fact]
        public void Constructor_ShouldThrowsAnException_WhenNotificationFactoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new NotificationManager(null, _logger));
        }

        [Fact]
        public void Constructor_ShouldThrowsAnException_WhenLoggerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new NotificationManager(_notificationFactory.Object, null));
        }

        [Fact]
        public void AddNotification_ShouldThrowsAnException_WhenNotificationIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _manager.AddNotification((Notification)null));
        }

        [Fact]
        public void AddNotification_ShouldAddOneNotification()
        {
            _manager.AddNotification(_notification);

            Assert.Single(_manager.Notifications);
            Assert.Equal(_notification, _manager.Notifications.FirstOrDefault());
        }

        [Fact]
        public void AddNotification_ShouldCallNotificationFactoryWithKeyAndValueParams()
        {
            _notificationFactory.Setup(x => x.CreateWithLocalizedValue(_key, _valueParams)).Returns(() => _notification);
            _manager.AddNotification(_key, _valueParams);

            _notificationFactory.Verify(x => x.CreateWithLocalizedValue(_key, _valueParams), Times.Once);
        }

        [Fact]
        public void HasNotifications_ShouldReturnTrue_WhenThereIsNotifications()
        {
            _manager.AddNotification(_notification);
            Assert.True(_manager.HasNotifications);
        }

        [Fact]
        public void HasNotifications_ShouldReturnFalse_WhenThereIsNoNotifications()
        {
            Assert.False(_manager.HasNotifications);
        }
    }
}
