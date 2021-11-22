using Entities;

namespace Domain.User
{
    public interface IUserValidation
    {
        public User ValidateUser(string userName, string password);
    }
}