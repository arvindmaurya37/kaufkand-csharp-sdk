using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IOrdersClient
    {
        /// <summary>
        /// Get a list of orders.
        /// </summary>
        Task<CollectionApiResponse_Order_> GetOrdersAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get an order by ID.
        /// </summary>
        Task<ApiResponse_OrderDetails_> GetOrderAsync(
            string id_order,
            string? embedded = null,
            CancellationToken cancellationToken = default);
    }
}
