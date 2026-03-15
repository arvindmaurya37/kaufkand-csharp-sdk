using Kaufland.SellerApi.Clients;

namespace Kaufland.SellerApi.Tests.Clients
{
    [TestFixture]
    public class ProductsClientTests
    {
        [Test]
        public async Task GetProductByEanAsync_ReturnsProduct()
        {
            // Arrange
            var jsonResponse = @"
            {
                ""data"": {
                    ""id_product"": 12345,
                    ""eans"": [""1234567890123""]
                }
            }";

            var handler = MockHttpMessageHandler.CreateMockResponse(jsonResponse);
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://sellerapi.kaufland.com/v2/")
            };
            var client = new ProductsClient(httpClient);

            // Act
            var result = await client.GetProductByEanAsync("1234567890123");

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data.Id_product, Is.EqualTo(12345));
            Assert.That(result.Data.Eans, Contains.Item("1234567890123"));
        }
    }
}
