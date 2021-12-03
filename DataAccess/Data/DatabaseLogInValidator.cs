using System;
using System.Linq;
using DataAccess.Persistence;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class DatabaseLogInValidator : IUserService
    {
        public User ValidateUser(string userName, string password)
        {
            using ChatContext chatContext = new ChatContext();

            return chatContext.Users.FirstOrDefault(user => user.Username == userName && user.Password == password);
        }

        public void RegisterUser(User user)
        {
            using ChatContext chatContext = new ChatContext();

            Console.WriteLine(user.ToStringFullName());
            chatContext.Users.Add(user);
            chatContext.SaveChanges();
        }

        public IQueryable<User> SearchUser(string username)
        {
            using ChatContext chatContext = new ChatContext();
            return chatContext.Users.Where(x => x.Username == username);
        }
    }
}