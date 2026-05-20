using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;

namespace DeviceStats.Services;

public class AuthService
{
    private readonly SupabaseClientProvider _provider;

    public event Action? StateChanged;

    public AuthService(SupabaseClientProvider provider)
    {
        _provider = provider;
        _provider.Client.Auth.AddStateChangedListener((_, _) => StateChanged?.Invoke());
    }

    public bool IsAuthenticated => _provider.Client.Auth.CurrentUser != null;

    public Guid? CurrentUserId =>
        Guid.TryParse(_provider.Client.Auth.CurrentUser?.Id, out var id) ? id : null;

    public string? CurrentEmail => _provider.Client.Auth.CurrentUser?.Email;

    public async Task<AuthResult> SignUpAsync(string email, string password)
    {
        try
        {
            var session = await _provider.Client.Auth.SignUp(email, password);
            return new AuthResult(true, session?.User?.Email);
        }
        catch (GotrueException ex)
        {
            return new AuthResult(false, null, ex.Message);
        }
        catch (Exception ex)
        {
            return new AuthResult(false, null, ex.Message);
        }
    }

    public async Task<AuthResult> SignInAsync(string email, string password)
    {
        try
        {
            var session = await _provider.Client.Auth.SignInWithPassword(email, password);
            return new AuthResult(true, session?.User?.Email);
        }
        catch (GotrueException ex)
        {
            return new AuthResult(false, null, ex.Message);
        }
        catch (Exception ex)
        {
            return new AuthResult(false, null, ex.Message);
        }
    }

    public async Task SignOutAsync()
    {
        await _provider.Client.Auth.SignOut();
    }
}

public record AuthResult(bool Success, string? Email, string? Error = null);
