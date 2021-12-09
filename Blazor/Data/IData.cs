using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Blazor.Data
{
    public interface IData
    { 
        Task<User> GetUser(string username);
        Task RemoveUser(string username);
        Task PromoteUser(string username);

        Task AddFriendToGroup(string username);
        
        Task<IList<Friendship>> UsersFriendships();
        Task<IList<GroupChat>> UsersGroupChats();
        Task<IList<Participant>> GetParticipants();
        Task<IList<Message>> GetPrivateMessages();
        Task<IList<Message>> GetGroupMessages();
        
        // IList<GroupChat> UserCreatedGroupChats(int userId);
        Task<Message> GetMessage(Message message);
        Task UpdateMessage(Message message);
        Task RemoveMessage(int messageId);
        
        Task AddFriendship(Friendship friendship);
        Task RemoveFriend(int friendshipId);
        
        
        Task CreateGroup(GroupChat groupChat);
        Task UpdateGroup(GroupChat groupChat);
        
        Task AddParticipant(Participant participant);
        Task UpdateParticipant(Participant participant);
        Task RemoveParticipant(int participantId);

        Task ForwardMessage(string toUser, int messageId);
        Task PinMessage(int messageId);
    }
}