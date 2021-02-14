using System;

namespace GSalvi.MessageManager
{
    /// <summary>
    /// Defines a notification.
    /// </summary>
    public record Notification
    {
        /// <summary>
        /// Represents the identifier of <see cref="Notification"/>.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Represents the key of <see cref="Notification"/>.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Represents the value of <see cref="Notification"/>.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Represents the timestamp of <see cref="Notification"/>.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Creates a new <see cref="Notification"/>.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public Notification(string key, string value)
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;
            Key = key;
            Value = value;
        }
    }
}
