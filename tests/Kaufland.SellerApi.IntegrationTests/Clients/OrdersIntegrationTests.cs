using Kaufland.SellerApi.Clients;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Kaufland.SellerApi.IntegrationTests.Clients
{
    [TestFixture]
    public class OrdersIntegrationTests
    {
        private HttpClient _httpClient = null!;
        private OrdersClient _ordersClient = null!;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"{WireMockFixture.Server.Urls[0]}/v2/")
            };
            _ordersClient = new OrdersClient(_httpClient);
        }

        [TearDown]
        public void TearDown()
        {
            _httpClient?.Dispose();
            WireMockFixture.Server.Reset();
        }

        [Test]
        public async Task GetOrdersAsync_ReturnsOrders_WithWireMock()
        {
            // Arrange
            var jsonResponse = @"
            {
                ""data"": [
                    { ""id_order"": ""ORDER-456"" }
                ]
            }";

            WireMockFixture.Server
                .Given(Request.Create().WithPath("/v2/orders").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithHeader("Content-Type", "application/json").WithBody(jsonResponse));

            // Act
            var result = await _ordersClient.GetOrdersAsync(limit: 10);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Count, Is.EqualTo(1));
            Assert.That(System.Linq.Enumerable.First(result.Data).Id_order, Is.EqualTo("ORDER-456"));
        }
    }
}
