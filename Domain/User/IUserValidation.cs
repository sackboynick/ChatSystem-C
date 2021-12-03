using Entities;

namespace Domain.User
{
    public interface IUserValidation
    {
        Entities.User ValidateUser(string userName, string password);
        void RegisterUser(Entities.User user);
    }
}