using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class ProductsClient : BaseClient, IProductsClient
    {

        public ProductsClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<ApiResponse_ProductWithEmbedded_> GetProductByEanAsync(
            string ean,
            string? embedded = null,
            CancellationToken cancellationToken = default)
        {
            var queryString = embedded != null ? $"?embedded={Uri.EscapeDataString(embedded)}" : string.Empty;

            using var response = await _httpClient.GetAsync($"products/ean/{Uri.EscapeDataString(ean)}{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_ProductWithEmbedded_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_ProductWithEmbedded_> GetProductByIdAsync(
            long id_product,
            string? embedded = null,
            CancellationToken cancellationToken = default)
        {
            var queryString = embedded != null ? $"?embedded={Uri.EscapeDataString(embedded)}" : string.Empty;

            using var response = await _httpClient.GetAsync($"products/{id_product}{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_ProductWithEmbedded_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<CollectionApiResponse_ProductWithEmbedded_> SearchProductsAsync(
            string q,
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default)
        {
            var queryParams = new System.Collections.Generic.List<string> { $"q={Uri.EscapeDataString(q)}" };
            if (sort != null) queryParams.Add($"sort={Uri.EscapeDataString(sort)}");
            if (limit.HasValue) queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue) queryParams.Add($"offset={offset.Value}");

            var queryString = "?" + string.Join("&", queryParams);

            using var response = await _httpClient.GetAsync($"products/search{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<CollectionApiResponse_ProductWithEmbedded_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
