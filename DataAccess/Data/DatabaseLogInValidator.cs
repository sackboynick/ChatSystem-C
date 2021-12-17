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
        
        private ChatContext chatContext;

        public DatabaseLogInValidator(ChatContext _chatContext)
        {
            chatContext = _chatContext;
        }
        public User ValidateUser(string userName, string password)
        {

                return chatContext.Users.Include(user1 => user1.Friends).FirstOrDefault(user => user.Username == userName && user.Password==password);
        }

        public void RegisterUser(User user)
        {
            chatContext.Users.Add(user);
            chatContext.SaveChanges();
        }
    }
}