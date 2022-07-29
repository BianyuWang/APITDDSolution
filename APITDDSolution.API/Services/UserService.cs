using APITDDSolution.API.Config;
using APITDDSolution.API.Models;
using Microsoft.Extensions.Options;

namespace APITDDSolution.API.Services
{
    public class UserService : IUserService

    {
        private readonly HttpClient _httpClient;
        private readonly UsersAPIOptions _apiConfig;

        public UserService(HttpClient httpClient, IOptions<UsersAPIOptions> apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig.Value;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var usersResponse = await _httpClient.GetAsync(_apiConfig.Endpoint);
            if (usersResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<User>();
            }
            var responseContent = usersResponse.Content;
            var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
            return allUsers.ToList();
        }
    }
}
