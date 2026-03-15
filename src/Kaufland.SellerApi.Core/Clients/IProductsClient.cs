using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IProductsClient
    {
        Task<ApiResponse_ProductWithEmbedded_> GetProductByEanAsync(
            string ean,
            string? embedded = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_ProductWithEmbedded_> GetProductByIdAsync(
            long id_product,
            string? embedded = null,
            CancellationToken cancellationToken = default);

        Task<CollectionApiResponse_ProductWithEmbedded_> SearchProductsAsync(
            string q,
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);
    }
}
