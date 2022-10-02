using ApiBestPractices.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBestPractices.Services
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<List<User>> GetAllUser();
        Task<User> GetByUserId(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByUsername(string username);
        Task<User> GetUserByPhone(string phone);
        Task DeleteUser (int id);
        Task<User> UpdateUser(User user);

    }
}
