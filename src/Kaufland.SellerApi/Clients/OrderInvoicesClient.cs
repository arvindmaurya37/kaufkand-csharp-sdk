using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class OrderInvoicesClient : BaseClient, IOrderInvoicesClient
    {

        public OrderInvoicesClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_OrderInvoice_> GetOrderInvoicesAsync(
            string id_order,
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

            using var response = await _httpClient.GetAsync($"orders/{Uri.EscapeDataString(id_order)}/invoices{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<CollectionApiResponse_OrderInvoice_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_OrderInvoice_> GetOrderInvoiceAsync(
            string id_order,
            int id_invoice,
            CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"orders/{Uri.EscapeDataString(id_order)}/invoices/{id_invoice}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_OrderInvoice_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
