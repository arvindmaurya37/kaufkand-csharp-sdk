using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Configuration;
using Kaufland.SellerApi.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kaufland.SellerApi.IntegrationTests
{
    [TestFixture]
    public class DependencyInjectionTests
    {
        [Test]
        public void AddKauflandSellerApi_RegistersAllClients()
        {
            // Arrange
            var services = new ServiceCollection();

            var configurationBuilder = new ConfigurationBuilder();
            var configuration = configurationBuilder.Build();

            // Act
            services.AddKauflandSellerApi(configuration, options =>
            {
                options.ClientKey = "test-client";
                options.SecretKey = "test-secret";
                options.Environment = KauflandEnvironment.Sandbox;
            });

            var serviceProvider = services.BuildServiceProvider();

            // Assert
            Assert.That(serviceProvider.GetService<IOrdersClient>(), Is.Not.Null);
            Assert.That(serviceProvider.GetService<IProductsClient>(), Is.Not.Null);
            Assert.That(serviceProvider.GetService<IKauflandSellerApiClient>(), Is.Not.Null);

            var options = serviceProvider.GetService<Microsoft.Extensions.Options.IOptions<KauflandSellerApiOptions>>();
            Assert.That(options, Is.Not.Null);
            Assert.That(options!.Value.GetBaseUri(), Is.EqualTo(new Uri("https://sellerapi.sandbox.kaufland.com/v2/")));
        }
    }
}
