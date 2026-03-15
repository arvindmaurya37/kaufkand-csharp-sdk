using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IInfoClient
    {
        Task<ApiResponse_CountryVatRatesArray_> GetVatIndicatorsAsync(
            string? storefront = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_InfoLocaleObject_> GetLocalesAsync(
            string? storefront = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_stringArray_> GetStorefrontsAsync(
            CancellationToken cancellationToken = default);
    }
}
