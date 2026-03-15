using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class CategoriesClient : BaseClient, ICategoriesClient
    {

        public CategoriesClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<ApiResponse_CategoryTree_> GetCategoryTreeAsync(
            string? storefront = null,
            CancellationToken cancellationToken = default)
        {
            var queryString = storefront != null ? $"?storefront={Uri.EscapeDataString(storefront)}" : string.Empty;

            using var response = await _httpClient.GetAsync($"categories/tree{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_CategoryTree_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<CollectionApiResponse_Category_> GetCategoriesAsync(
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

            using var response = await _httpClient.GetAsync($"categories{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<CollectionApiResponse_Category_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_CategoryWithEmbedded_> GetCategoryAsync(
            int id_category,
            string? embedded = null,
            CancellationToken cancellationToken = default)
        {
            var queryString = embedded != null ? $"?embedded={Uri.EscapeDataString(embedded)}" : string.Empty;

            using var response = await _httpClient.GetAsync($"categories/{id_category}{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_CategoryWithEmbedded_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
