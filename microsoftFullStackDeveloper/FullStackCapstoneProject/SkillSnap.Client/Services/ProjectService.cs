using System.Net.Http.Json;
using System.Text.Json;
using SkillSnap.Client.Models;

namespace SkillSnap.Client.Services
{
    public class ProjectService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;

        public ProjectService(HttpClient httpClient, AuthService authService)
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

        public async Task<List<ProjectDTO>> GetProjectsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ProjectDTO>>("api/Projects") 
                    ?? new List<ProjectDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching projects: {ex.Message}");
                return new List<ProjectDTO>();
            }
        }

        public async Task<ProjectDTO?> GetProjectAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProjectDTO>($"api/Projects/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching project: {ex.Message}");
                return null;
            }
        }

        public async Task<List<ProjectDTO>> GetProjectsByUserAsync(int userId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ProjectDTO>>($"api/Projects/user/{userId}") 
                    ?? new List<ProjectDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching projects by user: {ex.Message}");
                return new List<ProjectDTO>();
            }
        }

        public async Task<ProjectDTO?> AddProjectAsync(ProjectDTO project)
        {
            try
            {
                await AddAuthorizationHeaderAsync();
                var response = await _httpClient.PostAsJsonAsync("api/Projects", project);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ProjectDTO>(content);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding project: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateProjectAsync(int id, ProjectDTO project)
        {
            try
            {
                await AddAuthorizationHeaderAsync();
                var response = await _httpClient.PutAsJsonAsync($"api/Projects/{id}", project);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating project: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            try
            {
                await AddAuthorizationHeaderAsync();
                var response = await _httpClient.DeleteAsync($"api/Projects/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting project: {ex.Message}");
                return false;
            }
        }
    }
}
