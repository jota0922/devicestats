using Supabase;

namespace DeviceStats.Services;

public class SupabaseClientProvider
{
    public Client Client { get; }

    public SupabaseClientProvider(SupabaseConfig config)
    {
        var options = new SupabaseOptions
        {
            AutoConnectRealtime = false,
            AutoRefreshToken = true
        };

        Client = new Client(config.Url, config.AnonKey, options);
    }

    public Task InitializeAsync() => Client.InitializeAsync();
}
