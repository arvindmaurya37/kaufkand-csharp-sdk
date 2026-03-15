using Kaufland.SellerApi.Core.Configuration;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace Kaufland.SellerApi.Authentication
{
    public class KauflandAuthenticationHandler : DelegatingHandler
    {
        private readonly KauflandSellerApiOptions _options;
        private readonly string _userAgent;

        public KauflandAuthenticationHandler(IOptions<KauflandSellerApiOptions> options)
        {
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrWhiteSpace(_options.ClientKey))
                throw new ArgumentException("Kaufland ClientKey is required.");
            if (string.IsNullOrWhiteSpace(_options.SecretKey))
                throw new ArgumentException("Kaufland SecretKey is required.");

            _userAgent = "Kaufland.SellerApi.NET/1.0.0";
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

            var body = string.Empty;
            if (request.Content != null)
            {
                // Read the body asynchronously to include in the signature
                body = await request.Content.ReadAsStringAsync(cancellationToken);
            }

            var method = request.Method.Method;
            var uri = request.RequestUri?.ToString() ?? string.Empty;

            // The structure for the string to be signed is: `string = method + "\n" + uri + "\n" + body + "\n" + timestamp`
            var stringToSign = $"{method}\n{uri}\n{body}\n{timestamp}";
            var signature = ComputeSignature(stringToSign, _options.SecretKey);

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Shop-Client-Key", _options.ClientKey);
            request.Headers.Add("Shop-Timestamp", timestamp);
            request.Headers.Add("Shop-Signature", signature);

            if (!request.Headers.UserAgent.TryParseAdd(_userAgent))
            {
                request.Headers.TryAddWithoutValidation("User-Agent", _userAgent);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        private static string ComputeSignature(string data, string secretKey)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));

            // Convert to a lowercase hex string
            var sb = new StringBuilder(hashBytes.Length * 2);
            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
