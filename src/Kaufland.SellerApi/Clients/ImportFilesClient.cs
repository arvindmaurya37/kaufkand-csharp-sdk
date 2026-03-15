using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Models;
using System.Text.Json;

namespace Kaufland.SellerApi.Clients
{
    internal class ImportFilesClient : BaseClient, IImportFilesClient
    {

        public ImportFilesClient(HttpClient httpClient) : base(httpClient) { }

        public async Task<ApiResponse_ProductDataImportFileResponse_> GetProductImportFileAsync(
            long id_import_file,
            CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"import-files/product/{id_import_file}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_ProductDataImportFileResponse_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_ImportFileInventoryCommand_> GetInventoryCommandImportFileAsync(
            long id_import_file,
            CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"import-files/inventory-command/{id_import_file}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_ImportFileInventoryCommand_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<ApiResponse_ImportFileOrderCommand_> GetOrderCommandImportFileAsync(
            long id_import_file,
            CancellationToken cancellationToken = default)
        {
            using var response = await _httpClient.GetAsync($"import-files/order-command/{id_import_file}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<ApiResponse_ImportFileOrderCommand_>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }
    }
}
