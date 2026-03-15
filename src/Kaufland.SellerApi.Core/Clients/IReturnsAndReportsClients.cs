using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IReturnsClient
    {
        Task<CollectionApiResponse_Return_> GetReturnsAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_ReturnDetails_> GetReturnAsync(
            string id_return,
            string? embedded = null,
            CancellationToken cancellationToken = default);
    }

    public interface IReturnUnitsClient
    {
        Task<CollectionApiResponse_ReturnUnit_> GetReturnUnitsAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_ReturnUnitDetails_> GetReturnUnitAsync(
            long id_return_unit,
            string? embedded = null,
            CancellationToken cancellationToken = default);
    }

    public interface IReportsClient
    {
        Task<CollectionApiResponse_Report_> GetReportsAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_Report_> GetReportAsync(
            long id_report,
            CancellationToken cancellationToken = default);
    }
}
