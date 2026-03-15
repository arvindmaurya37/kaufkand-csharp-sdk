using Kaufland.SellerApi.Core.Models;

namespace Kaufland.SellerApi.Core.Clients
{
    public interface IImportFilesClient
    {
        Task<ApiResponse_ProductDataImportFileResponse_> GetProductImportFileAsync(
            long id_import_file,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_ImportFileInventoryCommand_> GetInventoryCommandImportFileAsync(
            long id_import_file,
            CancellationToken cancellationToken = default);

        Task<ApiResponse_ImportFileOrderCommand_> GetOrderCommandImportFileAsync(
            long id_import_file,
            CancellationToken cancellationToken = default);
    }
}
