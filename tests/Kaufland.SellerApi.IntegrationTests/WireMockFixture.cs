using WireMock.Server;

namespace Kaufland.SellerApi.IntegrationTests
{
    [SetUpFixture]
    public class WireMockFixture
    {
        public static WireMockServer Server { get; private set; } = null!;

        [OneTimeSetUp]
        public void StartServer()
        {
            Server = WireMockServer.Start();
        }

        [OneTimeTearDown]
        public void StopServer()
        {
            if (Server != null)
            {
                Server.Stop();
                Server.Dispose();
            }
        }
    }
}
