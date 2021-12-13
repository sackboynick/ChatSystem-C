using System.Threading.Tasks;
using Entities;

namespace BlazorClient.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
        Task<Task> RegisterUser(User user);
    }
}