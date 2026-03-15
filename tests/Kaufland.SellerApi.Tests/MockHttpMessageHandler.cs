using System.Net;

namespace Kaufland.SellerApi.Tests
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _handlerFunc;

        public MockHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> handlerFunc)
        {
            _handlerFunc = handlerFunc ?? throw new ArgumentNullException(nameof(handlerFunc));
        }

        public static MockHttpMessageHandler CreateMockResponse(string responseContent, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new MockHttpMessageHandler(request => new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(responseContent)
            });
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_handlerFunc(request));
        }
    }
}
