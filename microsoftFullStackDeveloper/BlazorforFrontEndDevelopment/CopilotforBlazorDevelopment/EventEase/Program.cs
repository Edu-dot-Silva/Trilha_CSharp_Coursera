using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventEase.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register application services
builder.Services.AddScoped<SessionStateService>();
builder.Services.AddScoped<AttendanceTrackerService>();
builder.Services.AddScoped<EventDataService>();

await builder.Build().RunAsync();
