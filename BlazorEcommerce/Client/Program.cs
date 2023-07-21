global using BlazorEcommerce.Client.Services.ProductSvc;
global using BlazorEcommerce.Shared;
global using System.Net.Http.Json;
global using BlazorEcommerce.Client.Services.CategorySvc;
using BlazorEcommerce.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// services
builder.Services.AddScoped<IProductSvc, ProductSvc>();
builder.Services.AddScoped<ICategorySvc, CategorySvc>();
//
await builder.Build().RunAsync();
