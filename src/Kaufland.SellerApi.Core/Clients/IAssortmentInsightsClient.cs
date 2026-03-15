using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IAssortmentInsightsClient
    {
        Task<CollectionApiResponse_AssortmentInsight_> GetAssortmentInsightsAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);
    }
}
