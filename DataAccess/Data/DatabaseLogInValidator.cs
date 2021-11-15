using DataAccess.Persistence;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class DatabaseLogInValidator: IUserService
    {
        public User ValidateUser(string userName, string password)
        {
                using UserContext userContext = new UserContext();

                return userContext.Users.FirstOrDefaultAsync(user => user.GetUsername() == userName && user.GetPassword()==password).Result;
        }
    }
}