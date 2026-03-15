using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class OrdersClient : BaseClient, IOrdersClient
    {

        public OrdersClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_Order_> GetOrdersAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default)
        {
            // Build query string
            var queryParams = new System.Collections.Generic.List<string>();
            if (sort != null) queryParams.Add($"sort={Uri.EscapeDataString(sort)}");
            if (limit.HasValue) queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue) queryParams.Add($"offset={offset.Value}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;

            using var response = await _httpClient.GetAsync($"orders{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<CollectionApiResponse_Order_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_OrderDetails_> GetOrderAsync(
            string id_order,
            string? embedded = null,
            CancellationToken cancellationToken = default)
        {
            var queryString = embedded != null ? $"?embedded={Uri.EscapeDataString(embedded)}" : string.Empty;

            using var response = await _httpClient.GetAsync($"orders/{id_order}{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_OrderDetails_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
