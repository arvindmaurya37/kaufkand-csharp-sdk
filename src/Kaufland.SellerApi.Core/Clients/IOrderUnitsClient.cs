using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IOrderUnitsClient
    {
        Task<CollectionApiResponse_OrderUnit_> GetOrderUnitsAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_OrderUnitDetails_> GetOrderUnitAsync(
            long id_order_unit,
            string? embedded = null,
            CancellationToken cancellationToken = default);
    }
}
