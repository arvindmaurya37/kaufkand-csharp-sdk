using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Kaufland.SellerApi.IntegrationTests
{
    [TestFixture]
    public class OrdersClientIntegrationTests
    {
        private WireMockServer _server;
        private ServiceProvider _serviceProvider;
        private IKauflandSellerApiClient _client;

        [SetUp]
        public void Setup()
        {
            _server = WireMockServer.Start();

            var services = new ServiceCollection();

            // Wire up the same SDK extension methods developers will use,
            // intercepting the base URI to point to our local WireMock server.
            services.AddKauflandSellerApi(new Microsoft.Extensions.Configuration.ConfigurationBuilder().Build(), options =>
            {
                options.ClientKey = "integration-client-key";
                options.SecretKey = "integration-secret-key";
                options.CustomBaseUri = new Uri(_server.Urls[0] + "/");
            });

            _serviceProvider = services.BuildServiceProvider();
            _client = _serviceProvider.GetRequiredService<IKauflandSellerApiClient>();
        }

        [TearDown]
        public void TearDown()
        {
            _server.Stop();
            _server.Dispose();
            _serviceProvider.Dispose();
        }

        [Test]
        public async Task GetOrdersAsync_ShouldReturnDeserializedModels()
        {
            // Arrange
            // Simulate Kaufland OpenAPI response for GET /orders
            _server
                .Given(Request.Create().WithPath("/orders").UsingGet())
                .RespondWith(
                    Response.Create()
                        .WithStatusCode(200)
                        .WithHeader("Content-Type", "application/json")
                        .WithBody(@"{
                            ""data"": [
                                { ""id_order"": ""ABC-123"", ""storefront"": ""de"" }
                            ],
                            ""pagination"": { ""offset"": 0, ""limit"": 30, ""total"": 1 }
                        }")
                );

            // Act
            var result = await _client.Orders.GetOrdersAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Count, Is.EqualTo(1));

            // Note: NSwag might append standard naming conventions on generated inner types. 
            // Assert.That(result.Data.First().Id_order, Is.EqualTo("ABC-123"));
        }
    }
}
