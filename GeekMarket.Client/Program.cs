using GeekMarket.Client;
using GeekMarket.Client.Converters;
using GeekMarket.Client.Services.Implementations;
using GeekMarket.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();

builder.Services.AddHttpClient("ServiceClient",x =>
{
    x.BaseAddress = new Uri(builder.Configuration["ServiceUrl"] ?? "");
});

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSingleton<IFileConverter, FileConverter>();

await builder.Build().RunAsync();
