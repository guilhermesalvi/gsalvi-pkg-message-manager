using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace GSalvi.MessageManager.UnitTests
{
    public class MessageManagerRequestOptionsTests
    {
        private readonly MessageManagerRequestOptions _options;

        public MessageManagerRequestOptionsTests()
        {
            _options = new MessageManagerRequestOptions();
        }

        [Fact]
        public void DefaultRequestCulture_ShouldNotBeChangedAfterAssigned()
        {
            var requestCulture = new RequestCulture("en-us");
            _options.DefaultRequestCulture = requestCulture;

            Assert.Equal(requestCulture, _options.DefaultRequestCulture);
        }

        [Fact]
        public void SupportedCultures_ShouldNotBeChangedAfterAssigned()
        {
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-us")
            };
            _options.SupportedCultures = supportedCultures;

            Assert.Equal(supportedCultures, _options.SupportedCultures);
        }
    }
}
