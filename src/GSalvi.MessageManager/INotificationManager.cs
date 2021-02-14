using System.Collections.Generic;

namespace GSalvi.MessageManager
{
    /// <summary>
    /// Defines a manager of <see cref="Notification"/>.
    /// </summary>
    public interface INotificationManager
    {
        /// <summary>
        /// Represents a list of <see cref="Notification"/>.
        /// </summary>
        IReadOnlyCollection<Notification> Notifications { get; }

        /// <summary>
        /// Indicates if there is at least one <see cref="Notification"/>
        /// item in the <see cref="Notifications"/>.
        /// </summary>
        bool HasNotifications { get; }

        /// <summary>
        /// Adds a new <see cref="Notification"/> informed from parameter
        /// to <see cref="Notifications"/>.
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        void AddNotification(Notification notification);

        /// <summary>
        /// Adds a new instance of <see cref="Notification"/> to <see cref="Notifications"/>
        /// created with <see cref="Notification.Value"/> localized value from resources.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueParams"></param>
        /// <returns></returns>
        void AddNotification(string key, params string[] valueParams);
    }
}
