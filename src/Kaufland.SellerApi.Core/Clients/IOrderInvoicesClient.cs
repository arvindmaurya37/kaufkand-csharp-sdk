using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IOrderInvoicesClient
    {
        Task<CollectionApiResponse_OrderInvoice_> GetOrderInvoicesAsync(
            string id_order,
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_OrderInvoice_> GetOrderInvoiceAsync(
            string id_order,
            int id_invoice,
            CancellationToken cancellationToken = default);
    }
}
