using Entities;

namespace Domain.Data
{
    public interface IUserRepo
    {
        
        public Entities.User GetUser(string username);
        public void AddFriendship(Friendship friendship);
    }
}