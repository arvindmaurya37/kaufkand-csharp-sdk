namespace Kaufland.SellerApi.Core.Configuration
{
    public class KauflandSellerApiOptions
    {
        public const string SectionName = "KauflandSellerApi";

        /// <summary>
        /// The Environment to connect to. Defaults to Production.
        /// </summary>
        public KauflandEnvironment Environment { get; set; } = KauflandEnvironment.Production;

        /// <summary>
        /// Your Kaufland Seller API Key (Client Key)
        /// </summary>
        public string ClientKey { get; set; } = string.Empty;

        /// <summary>
        /// Your Kaufland Seller API Secret (Secret Key) used for signing requests.
        /// </summary>
        public string SecretKey { get; set; } = string.Empty;

        /// <summary>
        /// Overrides the base URI, useful for testing with tools like WireMock.
        /// </summary>
        public Uri? CustomBaseUri { get; set; }

        public Uri GetBaseUri()
        {
            if (CustomBaseUri != null)
            {
                return CustomBaseUri;
            }

            return Environment switch
            {
                KauflandEnvironment.Sandbox => new Uri("https://sellerapi.sandbox.kaufland.com/v2/"),
                _ => new Uri("https://sellerapi.kaufland.com/v2/")
            };
        }
    }

    public enum KauflandEnvironment
    {
        Production,
        Sandbox
    }
}
