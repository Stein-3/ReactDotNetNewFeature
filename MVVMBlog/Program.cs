using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MVVMBlog;
using MVVMBlog.Models;
using MVVMBlog.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient("blog", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddTransient<CounterViewModel>();
builder.Services.AddTransient<FetchDataViewModel>();
builder.Services.AddTransient<FetchData2ViewModel>();

builder.Services.AddSingleton<FetchDataModel>();

await builder.Build().RunAsync();