using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class ProductDataClient : BaseClient, IProductDataClient
    {

        public ProductDataClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_ProductDataImportFileResponse_> GetProductDataImportFilesAsync(
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

            using var response = await _httpClient.GetAsync($"product-data/import-files{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<CollectionApiResponse_ProductDataImportFileResponse_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_ProductDataImportFileResponse_> GetProductDataImportFileAsync(
            long id_import_file,
            CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"product-data/import-files/{id_import_file}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_ProductDataImportFileResponse_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_ProductDataObject_> GetProductDataAsync(
            string ean,
            CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"product-data/{Uri.EscapeDataString(ean)}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_ProductDataObject_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_ProductDataStatusResponse_> GetProductDataStatusAsync(
            string ean,
            CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"product-data/{Uri.EscapeDataString(ean)}/status", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_ProductDataStatusResponse_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
