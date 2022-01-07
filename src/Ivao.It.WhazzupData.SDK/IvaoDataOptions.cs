using System;

namespace Ivao.It.WhazzupData.SDK
{
    /// <summary>
    /// Ivao data read options, already configured by default but overridable
    /// </summary>
    public sealed class IvaoDataOptions
    {
        /// <summary>
        /// Allowed read interval
        /// </summary>
        public TimeSpan ReadEvery { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Url to call
        /// </summary>
        public string WhazzupUrl { get; set; } = @"https://api.ivao.aero/v2/tracker/whazzup";

        /// <summary>
        /// Default HTTP Client name
        /// </summary>
        public string WhazzupHttpClientName { get; set; } = "IvaoWhazzupClient";

        internal void Validate()
        {
#if !DEBUG
            if (ReadEvery < TimeSpan.FromSeconds(30))
            {
                throw new ArgumentException("IVAO API 'ReadEvery' config should be not smaller than 30 seconds.");
            }
#endif
        }
    }
}
