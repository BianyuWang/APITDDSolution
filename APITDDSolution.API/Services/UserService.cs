using APITDDSolution.API.Models;

namespace APITDDSolution.API.Services
{
    public class UserService : IUserService

    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var usersResponse = await _httpClient.GetAsync("http://example.com");
            return new List<User>
            {
            };

        }
    }
}
