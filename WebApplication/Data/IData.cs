using System.Threading.Tasks;
using Entities;

namespace WebApplication.Data
{
    public interface IData
    {
        public Task<Task> SendMessage(Message message);
        public Task<PrivateChat> GetPrivateChat(int chatId);
        public Task<GroupChat> GetGroupChat(int chatId);
        
        public void AddParticipantToGroup(int groupId, string userToAdd);
        public void RemoveParticipantFromGroup(int groupId, string userToRemove);
        public void PromoteParticipantToAdmin(int groupId, string userToPromote);
        public Task<Task> CreateGroup(string groupCreator);
        public Task<User> GetUser(string username);
        public Task<Task> AddFriend(string user,string friendToAdd,bool closeFriend);
    }
}