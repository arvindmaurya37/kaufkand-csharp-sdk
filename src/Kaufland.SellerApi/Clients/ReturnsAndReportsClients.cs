using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class ReturnsClient : BaseClient, IReturnsClient
    {
        public ReturnsClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_Return_> GetReturnsAsync(
            string? sort = null, int? limit = null, int? offset = null, CancellationToken cancellationToken = default)
        {
            var queryParams = new System.Collections.Generic.List<string>();
            if (sort != null) queryParams.Add($"sort={Uri.EscapeDataString(sort)}");
            if (limit.HasValue) queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue) queryParams.Add($"offset={offset.Value}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;
            using var response = await _httpClient.GetAsync($"returns{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<CollectionApiResponse_Return_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_ReturnDetails_> GetReturnAsync(
            string id_return, string? embedded = null, CancellationToken cancellationToken = default)
        {
            var queryString = embedded != null ? $"?embedded={Uri.EscapeDataString(embedded)}" : string.Empty;
            using var response = await _httpClient.GetAsync($"returns/{id_return}{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<ApiResponse_ReturnDetails_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }

    internal class ReturnUnitsClient : BaseClient, IReturnUnitsClient
    {
        public ReturnUnitsClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_ReturnUnit_> GetReturnUnitsAsync(
            string? sort = null, int? limit = null, int? offset = null, CancellationToken cancellationToken = default)
        {
            var queryParams = new System.Collections.Generic.List<string>();
            if (sort != null) queryParams.Add($"sort={Uri.EscapeDataString(sort)}");
            if (limit.HasValue) queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue) queryParams.Add($"offset={offset.Value}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;
            using var response = await _httpClient.GetAsync($"return-units{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<CollectionApiResponse_ReturnUnit_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_ReturnUnitDetails_> GetReturnUnitAsync(
            long id_return_unit, string? embedded = null, CancellationToken cancellationToken = default)
        {
            var queryString = embedded != null ? $"?embedded={Uri.EscapeDataString(embedded)}" : string.Empty;
            using var response = await _httpClient.GetAsync($"return-units/{id_return_unit}{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<ApiResponse_ReturnUnitDetails_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }

    internal class ReportsClient : BaseClient, IReportsClient
    {
        public ReportsClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_Report_> GetReportsAsync(
            string? sort = null, int? limit = null, int? offset = null, CancellationToken cancellationToken = default)
        {
            var queryParams = new System.Collections.Generic.List<string>();
            if (sort != null) queryParams.Add($"sort={Uri.EscapeDataString(sort)}");
            if (limit.HasValue) queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue) queryParams.Add($"offset={offset.Value}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;
            using var response = await _httpClient.GetAsync($"reports{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<CollectionApiResponse_Report_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_Report_> GetReportAsync(
            long id_report, CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"reports/{id_report}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<ApiResponse_Report_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
