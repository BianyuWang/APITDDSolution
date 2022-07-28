using APITDDSolution.API.Models;

namespace APITDDSolution.API.Services
{
    public interface IUserService
    {
       public Task<  List<User>> GetAllUsers();
    }
}
