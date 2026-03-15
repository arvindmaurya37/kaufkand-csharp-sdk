# Kaufland Seller API SDK for .NET 🛒🚀

[![NuGet version](https://img.shields.io/badge/NuGet-1.0.0-blue.svg)](https://www.nuget.org/packages/Kaufland.SellerApi/)
[![Build Status](https://github.com/your-org/kaufland-sdk-dotnet/workflows/.NET/badge.svg)](https://github.com/your-org/kaufland-sdk-dotnet/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A modern, robust, and strongly-typed C# wrapper for the **Kaufland Seller API**. Designed from the ground up for .NET 8, this SDK provides an elegant interface to interact with Kaufland's marketplace functionalities natively without depending on heavy third-party core libraries.

> **Disclaimer**: This is a community-driven, open-source SDK and is not officially affiliated with Kaufland.
>
> This project is an unofficial community SDK for the Kaufland Seller API.
> It is not affiliated with, endorsed by, or maintained by Kaufland or Schwarz Gruppe.
>
> All trademarks and product names belong to their respective owners.

## Why This SDK?

Integrating directly with the Kaufland Seller API requires handling request signing, rate limits, retries, and HTTP error handling.

This SDK abstracts those complexities and provides a clean, strongly typed .NET interface so developers can focus on business logic instead of API plumbing.

## Offical Kaufland Documentation link
https://sellerapi.kaufland.com/

## ✨ Key Features

*   **Native .NET 8 Built**: Uses `System.Text.Json` and native `HttpClientFactory` instead of legacy dependencies.
*   **Built-in Resilience**: Ships with `Microsoft.Extensions.Http.Resilience` to handle standard HTTP retries and Rate Limiting (HTTP 429) automatically.
*   **Zero-Friction Authentication**: Automatically computes the `Shop-Signature` (HMAC-SHA256) per request seamlessly.
*   **Complete Coverage**: Supports all 24 Kaufland endpoints (Orders, Tickets, Products, Returns, Buybox, etc.).
*   **Dependency Injection Ready**: Exposes a clean `AddKauflandSellerApi()` extension for your `IServiceCollection`.
*   **Strongly Typed**: DTOs powered by NSwag to give you reliable data structures mapped directly from Kaufland's OpenAPI specification.

---

## 📦 Installation

Install via NuGet Package Manager Console:
```powershell
Install-Package Kaufland.SellerApi
Install-Package Kaufland.SellerApi.Extensions.DependencyInjection
```

Or via the .NET CLI:
```bash
dotnet add package Kaufland.SellerApi
dotnet add package Kaufland.SellerApi.Extensions.DependencyInjection
```

> *Note: Depending exactly how the packages are hosted, modify the names appropriately.*

---

## 🚀 Quick Start

### 1. Register the SDK in your `Program.cs` or `Startup.cs`

Utilize the provided Dependency Injection extension to register the root client and all sub-domain HTTP clients:

```csharp
using Kaufland.SellerApi.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add Kaufland Seller API to DI container
builder.Services.AddKauflandSellerApi(options =>
{
    // Required authentication keys from your Kaufland Seller Portal
    options.ClientKey = "YOUR_KAUFLAND_CLIENT_KEY";
    options.SecretKey = "YOUR_KAUFLAND_SECRET_KEY";

    // Optional: Switch to Sandbox Environment (default is false/production)
    options.UseSandbox = true; 
});

var app = builder.Build();
```

### 2. Inject and Use the Client

Inject `IKauflandSellerApiClient` into your Services, Controllers, or Background Workers to start interacting with the marketplace.

```csharp
using Kaufland.SellerApi.Core.Clients;

public class OrderProcessingService
{
    private readonly IKauflandSellerApiClient _kaufland;

    public OrderProcessingService(IKauflandSellerApiClient kaufland)
    {
        _kaufland = kaufland;
    }

    public async Task FetchNewOrdersAsync()
    {
        // Fetch a list of orders effortlessly
        var orders = await _kaufland.Orders.GetOrdersAsync(limit: 100);

        foreach (var order in orders.Data)
        {
            Console.WriteLine($"Found Order: {order.Id_order}");
        }

        // Access other domains easily via the root object:
        var status = await _kaufland.Status.PingAsync();
        Console.WriteLine($"API Status: {status.Data.Message}");
    }
}
```

---

## 🧩 Supported API Domains

The SDK supports all major features exposed in the Kaufland OpenAPI spec:

- **Order Management**: `Orders`, `Order Invoices`, `Order Units`
- **Product & Inventory**: `Products`, `Product Data`, `Categories`, `Attributes`, `Variant Suggestions`
- **Import/Export Feeds**: `Import Files` (Orders, Inventory, Products), `Reports`
- **Performance**: `Buybox`, `Assortment Insights`
- **Logistics & Returns**: `Carriers`, `Shipping Groups`, `Warehouses`, `Returns`, `Return Units`
- **Customer Service**: `Tickets` 
- **Misc**: `Info` (VAT rates, Locales), `Status`

---

## 🛠 Project Structure

If you wish to clone and build locally, the repository follows Clean Architecture principles:

- **`Kaufland.SellerApi.Core`**: Contains Interfaces, Options, generic Models (DTOs), and core contracts. It is entirely stripped of implementation details.
- **`Kaufland.SellerApi`**: The concrete implementations for the HTTP Clients and the `KauflandAuthenticationHandler`.
- **`Kaufland.SellerApi.Extensions.DependencyInjection`**: Syntactic sugar for standard `.NET Generic Host` wiring.
- **`Kaufland.SellerApi.ConsoleTests`**: A quick sandbox application to verify SDK behavior manualy.

---

## 🤝 Contributing

Contributions, issues, and feature requests are always welcome! 

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Run the existing tests in `Kaufland.SellerApi.Tests` and `Kaufland.SellerApi.IntegrationTests`
4. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
5. Push to the Branch (`git push origin feature/AmazingFeature`)
6. Open a Pull Request

---

## ⚖️ License

Distributed under the MIT License. See `LICENSE` for more information.


## Support & Consultation

### Community Support

For bugs, feature requests, or general questions:

- Open a GitHub Issue
- Start a Discussion

### Professional Support

If you need help integrating Kaufland Seller API into your system or require custom development, consultation services may be available.

Please contact:

📧 arvind.maurya@gmail.com
