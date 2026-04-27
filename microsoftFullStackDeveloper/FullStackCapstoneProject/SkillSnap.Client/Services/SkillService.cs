using System.Net.Http.Json;
using System.Text.Json;
using SkillSnap.Client.Models;

namespace SkillSnap.Client.Services
{
    public class SkillService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public SkillService(HttpClient httpClient, AuthService authService)
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

        public async Task<List<SkillDTO>> GetSkillsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<SkillDTO>>("api/Skills") 
                    ?? new List<SkillDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching skills: {ex.Message}");
                return new List<SkillDTO>();
            }
        }

        public async Task<SkillDTO?> GetSkillAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<SkillDTO>($"api/Skills/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching skill: {ex.Message}");
                return null;
            }
        }

        public async Task<List<SkillDTO>> GetSkillsByUserAsync(int userId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<SkillDTO>>($"api/Skills/user/{userId}") 
                    ?? new List<SkillDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching skills by user: {ex.Message}");
                return new List<SkillDTO>();
            }
        }

        public async Task<SkillDTO?> AddSkillAsync(SkillDTO skill)
        {
            try
            {
                await AddAuthorizationHeaderAsync();
                var response = await _httpClient.PostAsJsonAsync("api/Skills", skill);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<SkillDTO>(content);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding skill: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateSkillAsync(int id, SkillDTO skill)
        {
            try
            {
                await AddAuthorizationHeaderAsync();
                var response = await _httpClient.PutAsJsonAsync($"api/Skills/{id}", skill);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating skill: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            try
            {
                await AddAuthorizationHeaderAsync();
                var response = await _httpClient.DeleteAsync($"api/Skills/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting skill: {ex.Message}");
                return false;
            }
        }
    }
}
