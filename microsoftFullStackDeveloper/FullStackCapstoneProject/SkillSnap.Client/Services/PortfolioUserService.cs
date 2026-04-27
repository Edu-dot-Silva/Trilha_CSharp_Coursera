using System.Net.Http.Json;
using System.Text.Json;
using SkillSnap.Client.Models;

namespace SkillSnap.Client.Services
{
    public class PortfolioUserService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public PortfolioUserService(HttpClient httpClient, AuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        private async Task AddAuthorizationHeaderAsync()
        {
            var token = await _authService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = 
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<List<PortfolioUserDTO>> GetPortfolioUsersAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<PortfolioUserDTO>>("api/PortfolioUsers") 
                    ?? new List<PortfolioUserDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching portfolio users: {ex.Message}");
                return new List<PortfolioUserDTO>();
            }
        }

        public async Task<PortfolioUserDTO?> GetPortfolioUserAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<PortfolioUserDTO>($"api/PortfolioUsers/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching portfolio user: {ex.Message}");
                return null;
            }
        }

        public async Task<PortfolioUserDTO?> AddPortfolioUserAsync(PortfolioUserDTO user)
        {
            try
            {
                await AddAuthorizationHeaderAsync();
                var response = await _httpClient.PostAsJsonAsync("api/PortfolioUsers", user);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<PortfolioUserDTO>(content);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding portfolio user: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdatePortfolioUserAsync(int id, PortfolioUserDTO user)
        {
            try
            {
                await AddAuthorizationHeaderAsync();
                var response = await _httpClient.PutAsJsonAsync($"api/PortfolioUsers/{id}", user);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating portfolio user: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeletePortfolioUserAsync(int id)
        {
            try
            {
                await AddAuthorizationHeaderAsync();
                var response = await _httpClient.DeleteAsync($"api/PortfolioUsers/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting portfolio user: {ex.Message}");
                return false;
            }
        }
    }
}
