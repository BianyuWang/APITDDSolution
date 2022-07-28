using APITDDSolution.API.Models;

namespace APITDDSolution.API.Services
{
    public class UserService : IUserService

    {

        public UserService()
        {

        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
