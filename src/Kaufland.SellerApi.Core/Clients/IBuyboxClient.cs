using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IBuyboxClient
    {
        Task<ApiResponse_OffersRankings_> GetBuyboxRankingsAsync(
            long? id_product = null,
            string? id_item = null,
            string? storefront = null,
            CancellationToken cancellationToken = default);
    }
}
