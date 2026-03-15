using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class BuyboxClient : BaseClient, IBuyboxClient
    {

        public BuyboxClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<ApiResponse_OffersRankings_> GetBuyboxRankingsAsync(
            long? id_product = null,
            string? id_item = null,
            string? storefront = null,
            CancellationToken cancellationToken = default)
        {
            var queryParams = new System.Collections.Generic.List<string>();
            if (id_product.HasValue) queryParams.Add($"id_product={id_product.Value}");
            if (id_item != null) queryParams.Add($"id_item={Uri.EscapeDataString(id_item)}");
            if (storefront != null) queryParams.Add($"storefront={Uri.EscapeDataString(storefront)}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;

            using var response = await _httpClient.GetAsync($"buybox{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_OffersRankings_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
