using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface ICarriersClient
    {
        Task<ApiResponse_Carriers_> GetCarriersAsync(
            CancellationToken cancellationToken = default);
    }
}
