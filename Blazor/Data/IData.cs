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
        
        Task<IList<Friendship>> UserFriendships(int userId);
        Task<IList<Chat>> UserChats(int userId);
        Task<IList<Participant>> GetParticipants(int groupId);
        Task<IList<Message>> GetPrivateMessages(int chatId);
        Task<IList<Message>> GetGroupMessages(int groupId);
        
        // IList<GroupChat> UserCreatedGroupChats(int userId);
        Task<Message> GetMessage(int messageId);
        Task UpdateMessage(Message message);
        Task RemoveMessage(int messageId);
        
        Task AddFriendship(Friendship friendship);
        Task RemoveFriend(int friendshipId);
        
        
        Task CreateGroup(string groupCreator);
        Task UpdateGroup(GroupChat groupChat);
        
        Task AddParticipant(Participant participant);
        Task UpdateParticipant(Participant participant);
        Task RemoveParticipant(int participantId);

        Task ForwardMessage(string toUser, int messageId);
        Task PinMessage(int messageId);
    }
}