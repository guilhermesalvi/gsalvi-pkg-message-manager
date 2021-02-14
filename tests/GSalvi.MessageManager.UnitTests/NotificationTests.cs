using Xunit;

namespace GSalvi.MessageManager.UnitTests
{
    public class NotificationTests
    {
        private readonly string _key;
        private readonly string _value;
        private readonly Notification _notification;

        public NotificationTests()
        {
            _key = "INVALID_CUSTOMER_EMAIL";
            _value = "The e-mail 'abc@abc.com' is invalid.";
            _notification = new Notification(_key, _value);
        }

        [Fact]
        public void Id_ShouldNotBeDefaultValue_WhenInitializingObject()
        {
            Assert.NotEqual(default, _notification.Id);
        }

        [Fact]
        public void Key_ShouldNotBeChanged_WhenInitializingObject()
        {
            Assert.Equal(_key, _notification.Key);
        }

        [Fact]
        public void Value_ShouldNotBeChanged_WhenInitializingObject()
        {
            Assert.Equal(_value, _notification.Value);
        }

        [Fact]
        public void Timestamp_ShouldNotBeDefaultValue_WhenInitializingObject()
        {
            Assert.NotEqual(default, _notification.Timestamp);
        }
    }
}
