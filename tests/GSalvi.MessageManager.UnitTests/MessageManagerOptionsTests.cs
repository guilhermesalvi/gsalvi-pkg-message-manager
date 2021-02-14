using Xunit;

namespace GSalvi.MessageManager.UnitTests
{
    public class MessageManagerOptionsTests
    {
        private readonly MessageManagerOptions _options;

        public MessageManagerOptionsTests()
        {
            _options = new MessageManagerOptions();
        }

        [Fact]
        public void ResourcesPath_ShouldNotBeChangedAfterAssigned()
        {
            var resourcesPath = "LocalizedResources";
            _options.ResourcesPath = resourcesPath;

            Assert.Equal(resourcesPath, _options.ResourcesPath);
        }
    }
}
