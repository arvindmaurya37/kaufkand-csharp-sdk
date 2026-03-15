using Kaufland.SellerApi.Authentication;
using Kaufland.SellerApi.Core.Configuration;
using Microsoft.Extensions.Options;
using Moq;

namespace Kaufland.SellerApi.Tests
{
    [TestFixture]
    public class AuthenticationHandlerTests
    {
        [Test]
        public async Task SendAsync_ShouldAddRequiredSignaturesAndHeaders()
        {
            // Arrange
            var options = new KauflandSellerApiOptions
            {
                ClientKey = "test-client-key",
                SecretKey = "test-secret-key"
            };

            var optionsMock = new Mock<IOptions<KauflandSellerApiOptions>>();
            optionsMock.Setup(x => x.Value).Returns(options);

            var handler = new KauflandAuthenticationHandler(optionsMock.Object)
            {
                InnerHandler = new MockHttpMessageHandler()
            };

            var client = new HttpClient(handler) { BaseAddress = new Uri("https://sellerapi.kaufland.com/v2/") };
            var requestUri = new Uri("https://sellerapi.kaufland.com/v2/orders");

            // Act
            var response = await client.GetAsync(requestUri);

            // Assert
            var request = ((MockHttpMessageHandler)handler.InnerHandler).LastRequest;
            Assert.That(request, Is.Not.Null);
            Assert.That(request!.Headers.Contains("Shop-Client-Key"), Is.True);
            Assert.That(request.Headers.GetValues("Shop-Client-Key").First(), Is.EqualTo("test-client-key"));

            Assert.That(request.Headers.Contains("Shop-Timestamp"), Is.True);
            Assert.That(request.Headers.Contains("Shop-Signature"), Is.True);
            Assert.That(request.Headers.Contains("User-Agent"), Is.True);
        }

        private class MockHttpMessageHandler : HttpMessageHandler
        {
            public HttpRequestMessage? LastRequest { get; private set; }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                LastRequest = request;
                return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK));
            }
        }
    }
}
