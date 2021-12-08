using Entities;

namespace Domain.Data
{
    public class DataRepoImpl : IDataRepo
    {
        public void SendMessage(Message message)
        {
            throw new System.NotImplementedException();
        }

        public PrivateChat GetPrivateChat(int chatId)
        {
            throw new System.NotImplementedException();
        }

        public GroupChat GetGroupChat(int chatId)
        {
            throw new System.NotImplementedException();
        }

        public void CreateGroup(GroupChat groupChat)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateGroup(GroupChat groupChat)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveGroup(GroupChat groupChat)
        {
            throw new System.NotImplementedException();
        }

        public void PinMessage(Message message)
        {
            throw new System.NotImplementedException();
        }

        public void ReplyMessage(Message message)
        {
            throw new System.NotImplementedException();
        }

        public void ForwardMessage(Message message, Entities.User user)
        {
            throw new System.NotImplementedException();
        }

        public Entities.User GetUser(string username)
        {
            throw new System.NotImplementedException();
        }

        public void AddFriend(string username, Friendship friendship)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveFriend(string username)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMessage(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}