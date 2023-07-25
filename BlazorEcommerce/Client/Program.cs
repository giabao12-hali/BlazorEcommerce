global using BlazorEcommerce.Client.Services.ProductSvc;
global using BlazorEcommerce.Shared;
global using System.Net.Http.Json;
global using BlazorEcommerce.Client.Services.CategorySvc;
global using Blazored.LocalStorage;
global using BlazorEcommerce.Client.Services.CartSvc;
global using BlazorEcommerce.Client.Services.AuthSvc;
global using Microsoft.AspNetCore.Components.Authorization;
global using BlazorEcommerce.Client.Services.OrderSvc;
global using BlazorEcommerce.Client.Services.AddressSvc;
global using BlazorEcommerce.Client.Services.ProductTypeSvc;
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
builder.Services.AddScoped<ICartSvc, CartSvc>();
builder.Services.AddScoped<IAuthSvc, AuthSvc>();
builder.Services.AddScoped<IOrderSvc, OrderSvc>();
builder.Services.AddScoped<IAddressSvc, AddressSvc>();
builder.Services.AddScoped<IProductTypeSvc, ProductTypeSvc>();
//

// services authorize
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
//

// local storage download on Nuget
builder.Services.AddBlazoredLocalStorage();
//

await builder.Build().RunAsync();
