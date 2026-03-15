using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IProductDataClient
    {
        Task<CollectionApiResponse_ProductDataImportFileResponse_> GetProductDataImportFilesAsync(
            string? sort = null,
            int? limit = null,
            int? offset = null,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_ProductDataImportFileResponse_> GetProductDataImportFileAsync(
            long id_import_file,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_ProductDataObject_> GetProductDataAsync(
            string ean,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_ProductDataStatusResponse_> GetProductDataStatusAsync(
            string ean,
            CancellationToken cancellationToken = default);
    }
}
