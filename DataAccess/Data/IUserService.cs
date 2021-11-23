using Entities;

namespace DataAccess.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
        void RegisterUser(User user);
    }
}