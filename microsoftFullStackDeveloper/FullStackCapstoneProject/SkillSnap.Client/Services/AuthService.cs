using System.Text;
using System.Text.Json;
using Microsoft.JSInterop;
using SkillSnap.Client.Models;

namespace SkillSnap.Client.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;
    private readonly UserSessionService _sessionService;
    private const string TokenKey = "authToken";

    public AuthService(HttpClient httpClient, IJSRuntime jsRuntime, UserSessionService sessionService)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
        _sessionService = sessionService;
    }

    public async Task<(bool Success, string Message)> RegisterAsync(string email, string password, string firstName, string lastName)
    {
        try
        {
            var registerRequest = new { email, password, firstName, lastName };
            var json = JsonSerializer.Serialize(registerRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/auth/register", content);

            if (response.IsSuccessStatusCode)
            {
                return (true, "Registro realizado com sucesso!");
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            return (false, $"Erro: {errorContent}");
        }
        catch (Exception ex)
        {
            return (false, $"Erro ao registrar: {ex.Message}");
        }
    }

    public async Task<(bool Success, string Message, string Token)> LoginAsync(string email, string password)
    {
        try
        {
            var loginRequest = new { email, password };
            var json = JsonSerializer.Serialize(loginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                using var jsonDoc = JsonDocument.Parse(responseContent);
                var root = jsonDoc.RootElement;
                
                if (root.TryGetProperty("token", out var tokenElement))
                {
                    var token = tokenElement.GetString() ?? "";
                    if (!string.IsNullOrEmpty(token))
                    {
                        await StoreTokenAsync(token);
                        
                        // Extract user info from response and store in session
                        if (root.TryGetProperty("userId", out var userIdElement) && 
                            root.TryGetProperty("email", out var emailElement))
                        {
                            var userId = userIdElement.GetString();
                            var userEmail = emailElement.GetString();
                            
                            if (!string.IsNullOrEmpty(userId) && int.TryParse(userId, out var userIdInt))
                            {
                                _sessionService.SetUserInfo(userIdInt, userEmail ?? "", email, "User");
                            }
                        }
                        
                        return (true, "Login realizado com sucesso!", token);
                    }
                }
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            return (false, $"Erro no login: {errorContent}", "");
        }
        catch (Exception ex)
        {
            return (false, $"Erro ao fazer login: {ex.Message}", "");
        }
    }

    public async Task StoreTokenAsync(string token)
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
    }

    public async Task<string> GetTokenAsync()
    {
        try
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", TokenKey);
            return token ?? "";
        }
        catch
        {
            return "";
        }
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var token = await GetTokenAsync();
        return !string.IsNullOrEmpty(token);
    }

    public async Task LogoutAsync()
    {
        await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", TokenKey);
        _sessionService.Logout();
    }
}
