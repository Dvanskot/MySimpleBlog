using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MySimpleBlog.Client;
using MySimpleBlog.Shared.Core.Interfaces;
using MySimpleBlog.Shared.Core.Serives;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Injecting ContactService and NewsArtcleService in the client application
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<INewsArticleService, NewsArticleService>();

await builder.Build().RunAsync();
