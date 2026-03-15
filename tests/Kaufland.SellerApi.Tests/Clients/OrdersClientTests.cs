using Kaufland.SellerApi.Clients;

namespace Kaufland.SellerApi.Tests.Clients
{
    [TestFixture]
    public class OrdersClientTests
    {
        [Test]
        public async Task GetOrdersAsync_ReturnsOrders()
        {
            // Arrange
            var jsonResponse = @"
            {
                ""data"": [
                    { ""id_order"": ""ORDER-123"" }
                ]
            }";

            var handler = MockHttpMessageHandler.CreateMockResponse(jsonResponse);
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://sellerapi.kaufland.com/v2/")
            };
            var client = new OrdersClient(httpClient);

            // Act
            var result = await client.GetOrdersAsync(limit: 10);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Count, Is.EqualTo(1));
            Assert.That(System.Linq.Enumerable.First(result.Data).Id_order, Is.EqualTo("ORDER-123"));
        }
    }
}
