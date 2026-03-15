namespace Kaufland.SellerApi.Clients
{
    public abstract class BaseClient
    {
        protected readonly HttpClient _httpClient;

        protected BaseClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
    }
}
