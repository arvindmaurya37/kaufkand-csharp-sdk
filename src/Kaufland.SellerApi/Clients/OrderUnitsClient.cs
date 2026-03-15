using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class OrderUnitsClient : BaseClient, IOrderUnitsClient
    {

        public OrderUnitsClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_OrderUnit_> GetOrderUnitsAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default)
        {
            var queryParams = new System.Collections.Generic.List<string>();
            if (sort != null) queryParams.Add($"sort={Uri.EscapeDataString(sort)}");
            if (limit.HasValue) queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue) queryParams.Add($"offset={offset.Value}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;

            using var response = await _httpClient.GetAsync($"order-units{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<CollectionApiResponse_OrderUnit_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_OrderUnitDetails_> GetOrderUnitAsync(
            long id_order_unit,
            string? embedded = null,
            CancellationToken cancellationToken = default)
        {
            var queryString = embedded != null ? $"?embedded={Uri.EscapeDataString(embedded)}" : string.Empty;

            using var response = await _httpClient.GetAsync($"order-units/{id_order_unit}{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_OrderUnitDetails_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
