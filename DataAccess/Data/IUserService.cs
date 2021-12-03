using System.Linq;
using Entities;

namespace DataAccess.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
        void RegisterUser(User user);
        IQueryable<User> SearchUser(string username);
    }
}