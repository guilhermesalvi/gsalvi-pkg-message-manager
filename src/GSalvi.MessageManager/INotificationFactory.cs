namespace GSalvi.MessageManager
{
    /// <summary>
    /// Defines a factory of <see cref="Notification"/>.
    /// </summary>
    public interface INotificationFactory
    {
        /// <summary>
        /// Returns a new instance of <see cref="Notification"/>
        /// with <see cref="Notification.Value"/> localized from resources.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="valueParams"></param>
        /// <returns></returns>
        Notification CreateWithLocalizedValue(string key, params string[] valueParams);
    }
}
