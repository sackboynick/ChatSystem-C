using System.Threading.Tasks;
using Entities;

namespace Blazor.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
    }
}