using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class ShippingGroupsClient : BaseClient, IShippingGroupsClient
    {
        public ShippingGroupsClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_ShippingGroup_> GetShippingGroupsAsync(
            string? sort = null, int? limit = null, int? offset = null, CancellationToken cancellationToken = default)
        {
            var queryParams = new System.Collections.Generic.List<string>();
            if (sort != null) queryParams.Add($"sort={Uri.EscapeDataString(sort)}");
            if (limit.HasValue) queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue) queryParams.Add($"offset={offset.Value}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;
            using var response = await _httpClient.GetAsync($"shipping-groups{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<CollectionApiResponse_ShippingGroup_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_ShippingGroup_> GetShippingGroupAsync(
            long id_shipping_group, CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"shipping-groups/{id_shipping_group}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<ApiResponse_ShippingGroup_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }

    internal class StatusClient : BaseClient, IStatusClient
    {
        public StatusClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<ApiResponse_PingMessage_> PingAsync(CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"status/ping", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<ApiResponse_PingMessage_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }

    internal class TicketsClient : BaseClient, ITicketsClient
    {
        public TicketsClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_Ticket_> GetTicketsAsync(
            string? sort = null, int? limit = null, int? offset = null, CancellationToken cancellationToken = default)
        {
            var queryParams = new System.Collections.Generic.List<string>();
            if (sort != null) queryParams.Add($"sort={Uri.EscapeDataString(sort)}");
            if (limit.HasValue) queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue) queryParams.Add($"offset={offset.Value}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;
            using var response = await _httpClient.GetAsync($"tickets{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<CollectionApiResponse_Ticket_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_TicketWithEmbedded_> GetTicketAsync(
            string id_ticket, CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"tickets/{Uri.EscapeDataString(id_ticket)}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<ApiResponse_TicketWithEmbedded_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }

    internal class UnitsClient : BaseClient, IUnitsClient
    {
        public UnitsClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_UnitEmbedded_> GetUnitsAsync(
            string? sort = null, int? limit = null, int? offset = null, CancellationToken cancellationToken = default)
        {
            var queryParams = new System.Collections.Generic.List<string>();
            if (sort != null) queryParams.Add($"sort={Uri.EscapeDataString(sort)}");
            if (limit.HasValue) queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue) queryParams.Add($"offset={offset.Value}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;
            using var response = await _httpClient.GetAsync($"units{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<CollectionApiResponse_UnitEmbedded_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_Unit_> GetUnitAsync(
            long id_unit, CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"units/{id_unit}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<ApiResponse_Unit_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }

    internal class VariantSuggestionsClient : BaseClient, IVariantSuggestionsClient
    {
        public VariantSuggestionsClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_ProductCategoriesImportFileResponse_> GetVariantSuggestionFeedsAsync(
            string? sort = null, int? limit = null, int? offset = null, CancellationToken cancellationToken = default)
        {
            var queryParams = new System.Collections.Generic.List<string>();
            if (sort != null) queryParams.Add($"sort={Uri.EscapeDataString(sort)}");
            if (limit.HasValue) queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue) queryParams.Add($"offset={offset.Value}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;
            using var response = await _httpClient.GetAsync($"variant-suggestions/feed{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<CollectionApiResponse_ProductCategoriesImportFileResponse_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }

    internal class WarehousesClient : BaseClient, IWarehousesClient
    {
        public WarehousesClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<CollectionApiResponse_Warehouse_> GetWarehousesAsync(
            string? sort = null, int? limit = null, int? offset = null, CancellationToken cancellationToken = default)
        {
            var queryParams = new System.Collections.Generic.List<string>();
            if (sort != null) queryParams.Add($"sort={Uri.EscapeDataString(sort)}");
            if (limit.HasValue) queryParams.Add($"limit={limit.Value}");
            if (offset.HasValue) queryParams.Add($"offset={offset.Value}");

            var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : string.Empty;
            using var response = await _httpClient.GetAsync($"warehouses{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<CollectionApiResponse_Warehouse_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_Warehouse_> GetWarehouseAsync(
            long id_warehouse, CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"warehouses/{id_warehouse}", cancellationToken);
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<ApiResponse_Warehouse_>(await response.Content.ReadAsStringAsync(cancellationToken), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
