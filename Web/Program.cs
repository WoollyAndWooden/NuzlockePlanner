using Core.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddPokeApiClient().ConfigureHttpClient(client => client.BaseAddress = new Uri("https://beta.pokeapi.co/graphql/v1beta2"));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<PokeApi>();
builder.Services.AddScoped<GameSelectionState>();
builder.Services.AddScoped<SpriteState>();
await builder.Build().RunAsync();
