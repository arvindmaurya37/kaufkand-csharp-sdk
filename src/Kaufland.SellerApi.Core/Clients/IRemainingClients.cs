using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IShippingGroupsClient
    {
        Task<CollectionApiResponse_ShippingGroup_> GetShippingGroupsAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_ShippingGroup_> GetShippingGroupAsync(
            long id_shipping_group,
            CancellationToken cancellationToken = default);
    }

    public interface IStatusClient
    {
        Task<ApiResponse_PingMessage_> PingAsync(CancellationToken cancellationToken = default);
    }

    public interface ITicketsClient
    {
        Task<CollectionApiResponse_Ticket_> GetTicketsAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_TicketWithEmbedded_> GetTicketAsync(
            string id_ticket,
            CancellationToken cancellationToken = default);
    }

    public interface IUnitsClient
    {
        Task<CollectionApiResponse_UnitEmbedded_> GetUnitsAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_Unit_> GetUnitAsync(
            long id_unit,
            CancellationToken cancellationToken = default);
    }

    public interface IVariantSuggestionsClient
    {
        Task<CollectionApiResponse_ProductCategoriesImportFileResponse_> GetVariantSuggestionFeedsAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);
    }

    public interface IWarehousesClient
    {
        Task<CollectionApiResponse_Warehouse_> GetWarehousesAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_Warehouse_> GetWarehouseAsync(
            long id_warehouse,
            CancellationToken cancellationToken = default);
    }
}
