using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace GSalvi.MessageManager
{
    /// <summary>
    /// Options to configure message manager request.
    /// </summary>
    public class MessageManagerRequestOptions
    {
        /// <summary>
        /// Represents the default request culture.
        /// </summary>
        public RequestCulture DefaultRequestCulture { get; set; }

        /// <summary>
        /// Represents the cultures supported by the application.
        /// </summary>
        public IList<CultureInfo> SupportedCultures { get; set; }
    }
}
