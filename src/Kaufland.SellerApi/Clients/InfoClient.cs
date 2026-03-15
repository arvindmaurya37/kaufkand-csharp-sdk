using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class InfoClient : BaseClient, IInfoClient
    {

        public InfoClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<ApiResponse_CountryVatRatesArray_> GetVatIndicatorsAsync(
            string? storefront = null,
            CancellationToken cancellationToken = default)
        {
            var queryString = storefront != null ? $"?storefront={Uri.EscapeDataString(storefront)}" : string.Empty;

            using var response = await _httpClient.GetAsync($"info/vat-indicators{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_CountryVatRatesArray_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_InfoLocaleObject_> GetLocalesAsync(
            string? storefront = null,
            CancellationToken cancellationToken = default)
        {
            var queryString = storefront != null ? $"?storefront={Uri.EscapeDataString(storefront)}" : string.Empty;

            using var response = await _httpClient.GetAsync($"info/locale{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_InfoLocaleObject_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_stringArray_> GetStorefrontsAsync(
            CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"info/storefront", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_stringArray_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
