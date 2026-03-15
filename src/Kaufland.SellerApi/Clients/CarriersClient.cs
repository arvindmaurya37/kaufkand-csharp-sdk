using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class CarriersClient : BaseClient, ICarriersClient
    {

        public CarriersClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<ApiResponse_Carriers_> GetCarriersAsync(
            CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"carriers", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_Carriers_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
