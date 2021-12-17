using System;
using System.Linq;
using DataAccess.Persistence;
using Domain.User;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class DatabaseLogInValidator: IUserValidation
    {
        
        public User ValidateUser(string userName, string password)
        {
            var chatContext = new ChatContext();

                return chatContext.Users.Include(user1 => user1.Friends).FirstOrDefault(user => user.Username == userName && user.Password==password);
        }

        public void RegisterUser(User user)
        {
            var chatContext = new ChatContext();
            chatContext.Users.Add(user);
            chatContext.SaveChanges();
        }
    }
}