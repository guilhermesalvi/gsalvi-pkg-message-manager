using System;

namespace GSalvi.MessageManager
{
    internal class NotificationFactory : INotificationFactory
    {
        private readonly IApplicationMassageManager _appMessageManager;

        public NotificationFactory(IApplicationMassageManager appMessageManager)
        {
            _appMessageManager = appMessageManager ?? throw new ArgumentNullException(nameof(appMessageManager));
        }

        public Notification CreateWithLocalizedValue(string key, params string[] valueParams)
        {
            var value = _appMessageManager.FindValueByKey(key, valueParams);
            return new Notification(key, value);
        }
    }
}
