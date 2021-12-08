using Entities;

namespace Domain.Data
{
    public interface IUserRepo
    {
        
        public Entities.User GetUser(int userId);
        public void AddFriendship(Friendship friendship);
        void UpdateUser(Entities.User user);
    }
}