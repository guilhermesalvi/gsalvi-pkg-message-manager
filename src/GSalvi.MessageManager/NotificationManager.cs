using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSalvi.MessageManager
{
    internal class NotificationManager : INotificationManager
    {
        private readonly List<Notification> _notifications;
        private readonly INotificationFactory _notificationFactory;
        private readonly ILogger<NotificationManager> _logger;

        public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();
        public bool HasNotifications => _notifications.Any();

        public NotificationManager(
            INotificationFactory notificationFactory,
            ILogger<NotificationManager> logger)
        {
            _notificationFactory = notificationFactory ?? throw new ArgumentNullException(nameof(notificationFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _notifications = new List<Notification>();
        }

        public void AddNotification(Notification notification)
        {
            if (notification is null)
            {
                _logger.LogError("----- Notification not added to the list because it is null.");
                throw new ArgumentNullException(nameof(notification));
            }

            _logger.LogError("----- Adding notification to the list.");
            _notifications.Add(notification);
        }

        public void AddNotification(string key, params string[] valueParams)
        {
            var notification = _notificationFactory.CreateWithLocalizedValue(key, valueParams);
            AddNotification(notification);
        }
    }
}
