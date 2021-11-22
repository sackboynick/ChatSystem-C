using System.Linq;
using DataAccess.Persistence;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class DatabaseLogInValidator: IUserService
    {
        public User ValidateUser(string userName, string password)
        {
                using ChatContext userContext = new ChatContext();

                return userContext.Users.FirstOrDefault(user => user.Username == userName && user.Password==password);
        }
    }
}