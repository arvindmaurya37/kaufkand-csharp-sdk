using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface ICategoriesClient
    {
        Task<ApiResponse_CategoryTree_> GetCategoryTreeAsync(
            string? storefront = null,
            CancellationToken cancellationToken = default);

        Task<CollectionApiResponse_Category_> GetCategoriesAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_CategoryWithEmbedded_> GetCategoryAsync(
            int id_category,
            string? embedded = null,
            CancellationToken cancellationToken = default);
    }
}
