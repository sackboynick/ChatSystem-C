namespace Domain.Data
{
    public interface IUserRepo
    {
        
        public Entities.User GetUser(string username);
        public void AddFriend(string user,string friendToAdd,bool closeFriend);
    }
}