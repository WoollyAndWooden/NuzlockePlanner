using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Routing;
using Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add routing configuration
builder.Services.AddRouting();
builder.Services.AddSingleton<IRouter, Router>();

// Set default page
builder.Services.AddSingleton<PageRouteHandler>("", new PageRouteHandler("Home"));

await builder.Build().RunAsync();
