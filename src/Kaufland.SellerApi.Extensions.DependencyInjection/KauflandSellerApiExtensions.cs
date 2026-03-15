using Kaufland.SellerApi.Authentication;
using Kaufland.SellerApi.Core.Clients;
using Kaufland.SellerApi.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;

namespace Kaufland.SellerApi.Extensions.DependencyInjection
{
    public static class KauflandSellerApiExtensions
    {
        public static IServiceCollection AddKauflandSellerApi(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<KauflandSellerApiOptions>? configureOptions = null)
        {
            var optionsSection = configuration.GetSection(KauflandSellerApiOptions.SectionName);
            services.Configure<KauflandSellerApiOptions>(optionsSection);

            if (configureOptions != null)
            {
                services.Configure(configureOptions);
            }

            services.AddTransient<KauflandAuthenticationHandler>();

            // Helper action to configure each domain's HttpClient
            Action<IServiceProvider, HttpClient> configureClient = (sp, client) =>
            {
                var options = sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<KauflandSellerApiOptions>>().Value;
                client.BaseAddress = options.GetBaseUri();
                client.DefaultRequestHeaders.Accept.Clear();
            };

            // Register specific domain clients against the standard resilient HTTP pipeline
            services.AddHttpClient<IAssortmentInsightsClient, Clients.AssortmentInsightsClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IAttributesClient, Clients.AttributesClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IBuyboxClient, Clients.BuyboxClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<ICarriersClient, Clients.CarriersClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<ICategoriesClient, Clients.CategoriesClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IImportFilesClient, Clients.ImportFilesClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IInfoClient, Clients.InfoClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IOrderInvoicesClient, Clients.OrderInvoicesClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IOrdersClient, Clients.OrdersClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IOrderUnitsClient, Clients.OrderUnitsClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IProductDataClient, Clients.ProductDataClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IProductsClient, Clients.ProductsClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IReportsClient, Clients.ReportsClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IReturnsClient, Clients.ReturnsClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IReturnUnitsClient, Clients.ReturnUnitsClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IShippingGroupsClient, Clients.ShippingGroupsClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IStatusClient, Clients.StatusClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<ITicketsClient, Clients.TicketsClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IUnitsClient, Clients.UnitsClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IVariantSuggestionsClient, Clients.VariantSuggestionsClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();
            services.AddHttpClient<IWarehousesClient, Clients.WarehousesClient>(configureClient).AddHttpMessageHandler<KauflandAuthenticationHandler>().AddStandardResilienceHandler();

            // Register the Root Client aggregating all domain clients
            services.AddTransient<IKauflandSellerApiClient, Clients.KauflandSellerApiClient>();

            return services;
        }
    }
}
