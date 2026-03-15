namespace Kaufland.SellerApi.Core.Clients
{
    /// <summary>
    /// The root client interface for the Kaufland Seller API. Provides access to all specific domain operations.
    /// </summary>
    public interface IKauflandSellerApiClient
    {
        IAssortmentInsightsClient AssortmentInsights { get; }
        IAttributesClient Attributes { get; }
        IBuyboxClient Buybox { get; }
        ICarriersClient Carriers { get; }
        ICategoriesClient Categories { get; }
        IImportFilesClient ImportFiles { get; }
        IInfoClient Info { get; }
        IOrderInvoicesClient OrderInvoices { get; }
        IOrdersClient Orders { get; }
        IOrderUnitsClient OrderUnits { get; }
        IProductDataClient ProductData { get; }
        IProductsClient Products { get; }
        IReportsClient Reports { get; }
        IReturnsClient Returns { get; }
        IReturnUnitsClient ReturnUnits { get; }
        IShippingGroupsClient ShippingGroups { get; }
        IStatusClient Status { get; }
        ITicketsClient Tickets { get; }
        IUnitsClient Units { get; }
        IVariantSuggestionsClient VariantSuggestions { get; }
        IWarehousesClient Warehouses { get; }

        // Other domain clients will be added here (e.g., Products, Tickets, Reports)
    }
}
