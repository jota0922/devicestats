using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DeviceStats;
using DeviceStats.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var supabaseConfig = builder.Configuration.GetSection("Supabase").Get<SupabaseConfig>() ?? new SupabaseConfig();
builder.Services.AddSingleton(supabaseConfig);
builder.Services.AddSingleton<SupabaseClientProvider>();
builder.Services.AddSingleton<AuthService>();

var host = builder.Build();

if (!string.IsNullOrWhiteSpace(supabaseConfig.Url) && !supabaseConfig.Url.Contains("YOUR-PROJECT-REF"))
{
    await host.Services.GetRequiredService<SupabaseClientProvider>().InitializeAsync();
}

await host.RunAsync();
