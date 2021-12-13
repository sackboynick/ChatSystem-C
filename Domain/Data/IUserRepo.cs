using System.Collections.Generic;
using Entities;

namespace Domain.Data
{
    public interface IUserRepo
    {
        
        public Entities.User GetUser(int userId);
        void UpdateUser(Entities.User user);
        
        List<Entities.User> GetUsersList();
        Entities.User GetUserFromUsername(string username);

        void RemoveUser(int userId);
    }
}