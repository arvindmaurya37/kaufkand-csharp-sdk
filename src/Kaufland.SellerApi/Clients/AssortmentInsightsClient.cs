using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class AssortmentInsightsClient : BaseClient, IAssortmentInsightsClient
    {

        public AssortmentInsightsClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_AssortmentInsight_> GetAssortmentInsightsAsync(
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

            using var response = await _httpClient.GetAsync($"assortment-coverage/insights{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<CollectionApiResponse_AssortmentInsight_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
