using System.Threading.Tasks;
using Entities;

namespace WebApplication.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
        Task<Task> RegisterUser(User user);

        Task<User> SearchUser(string username);
    }
}