using Kaufland.SellerApi.Core.Clients;

namespace Kaufland.SellerApi.Clients
{
    internal class KauflandSellerApiClient : IKauflandSellerApiClient
    {
        public IAssortmentInsightsClient AssortmentInsights { get; }
        public IAttributesClient Attributes { get; }
        public IBuyboxClient Buybox { get; }
        public ICarriersClient Carriers { get; }
        public ICategoriesClient Categories { get; }
        public IImportFilesClient ImportFiles { get; }
        public IInfoClient Info { get; }
        public IOrderInvoicesClient OrderInvoices { get; }
        public IOrdersClient Orders { get; }
        public IOrderUnitsClient OrderUnits { get; }
        public IProductDataClient ProductData { get; }
        public IProductsClient Products { get; }
        public IReportsClient Reports { get; }
        public IReturnsClient Returns { get; }
        public IReturnUnitsClient ReturnUnits { get; }
        public IShippingGroupsClient ShippingGroups { get; }
        public IStatusClient Status { get; }
        public ITicketsClient Tickets { get; }
        public IUnitsClient Units { get; }
        public IVariantSuggestionsClient VariantSuggestions { get; }
        public IWarehousesClient Warehouses { get; }

        public KauflandSellerApiClient(
            IAssortmentInsightsClient assortmentInsights,
            IAttributesClient attributes,
            IBuyboxClient buybox,
            ICarriersClient carriers,
            ICategoriesClient categories,
            IImportFilesClient importFiles,
            IInfoClient info,
            IOrderInvoicesClient orderInvoices,
            IOrdersClient orders,
            IOrderUnitsClient orderUnits,
            IProductDataClient productData,
            IProductsClient products,
            IReportsClient reports,
            IReturnsClient returns,
            IReturnUnitsClient returnUnits,
            IShippingGroupsClient shippingGroups,
            IStatusClient status,
            ITicketsClient tickets,
            IUnitsClient units,
            IVariantSuggestionsClient variantSuggestions,
            IWarehousesClient warehouses)
        {
            AssortmentInsights = assortmentInsights ?? throw new ArgumentNullException(nameof(assortmentInsights));
            Attributes = attributes ?? throw new ArgumentNullException(nameof(attributes));
            Buybox = buybox ?? throw new ArgumentNullException(nameof(buybox));
            Carriers = carriers ?? throw new ArgumentNullException(nameof(carriers));
            Categories = categories ?? throw new ArgumentNullException(nameof(categories));
            ImportFiles = importFiles ?? throw new ArgumentNullException(nameof(importFiles));
            Info = info ?? throw new ArgumentNullException(nameof(info));
            OrderInvoices = orderInvoices ?? throw new ArgumentNullException(nameof(orderInvoices));
            Orders = orders ?? throw new ArgumentNullException(nameof(orders));
            OrderUnits = orderUnits ?? throw new ArgumentNullException(nameof(orderUnits));
            ProductData = productData ?? throw new ArgumentNullException(nameof(productData));
            Products = products ?? throw new ArgumentNullException(nameof(products));
            Reports = reports ?? throw new ArgumentNullException(nameof(reports));
            Returns = returns ?? throw new ArgumentNullException(nameof(returns));
            ReturnUnits = returnUnits ?? throw new ArgumentNullException(nameof(returnUnits));
            ShippingGroups = shippingGroups ?? throw new ArgumentNullException(nameof(shippingGroups));
            Status = status ?? throw new ArgumentNullException(nameof(status));
            Tickets = tickets ?? throw new ArgumentNullException(nameof(tickets));
            Units = units ?? throw new ArgumentNullException(nameof(units));
            VariantSuggestions = variantSuggestions ?? throw new ArgumentNullException(nameof(variantSuggestions));
            Warehouses = warehouses ?? throw new ArgumentNullException(nameof(warehouses));
        }
    }
}
