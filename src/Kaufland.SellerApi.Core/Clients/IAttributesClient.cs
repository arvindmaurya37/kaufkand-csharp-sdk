using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IAttributesClient
    {
        Task<CollectionApiResponse_Attribute_> GetAttributesAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_Attribute_> GetAttributeAsync(
            int id_attribute,
            CancellationToken cancellationToken = default);
    }
}
