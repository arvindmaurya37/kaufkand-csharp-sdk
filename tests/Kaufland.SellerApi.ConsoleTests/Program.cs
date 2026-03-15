using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kaufland.SellerApi.ConsoleTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Kaufland Seller API SDK - Console Sandbox");
            Console.WriteLine("-----------------------------------------");

            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddKauflandSellerApi(context.Configuration, options =>
                    {
                        options.ClientKey = "YOUR_KAUFLAND_CLIENT_KEY";
                        options.SecretKey = "YOUR_KAUFLAND_SECRET_KEY";
                        options.Environment = Core.Configuration.KauflandEnvironment.Sandbox;
                    });
                })
                .Build();

            var kauflandClient = host.Services.GetRequiredService<IKauflandSellerApiClient>();

            try
            {
                var ordersResponse = await kauflandClient.Orders.GetOrdersAsync(limit: 5);
                Console.WriteLine($"Success! Found {ordersResponse.Data.Count} orders.");
            }
            catch (Exception)
            {
                Console.WriteLine("[ERROR] Need real keys for actual Sandbox usage.");
            }
        }
    }
}
