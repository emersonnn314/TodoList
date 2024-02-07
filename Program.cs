using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoList;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<LocalStorageAccessor>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorageAsSingleton();



//public static async Task Main(string[] args)
//{
//    var builder = WebAssemblyHostBuilder.CreateDefault(args);
//    builder.RootComponents.Add<App>("app");

//    builder.Services.AddBlazoredLocalStorage();

//    await builder.Build().RunAsync();
//}

await builder.Build().RunAsync();

