using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace BlazorClient.Data
{
    public interface IData
    { 
        Task<User> GetUser(string username);
        Task<Task> RemoveUser(int userId);
        Task<Task> PromoteUser(int groupId,int participantId);

        Task<Task> SendMessage(Message message);

        Task<IList<Friendship>> UserFriendships(int userId);
        Task<IList<Chat>> UserChats(int userId);
        Task<IList<Participant>> GetParticipants(int groupId);
        Task<IList<Message>> GetPrivateMessages(int chatId);
        Task<IList<Message>> GetGroupMessages(int groupId);
        
        Task<Message> GetMessage(int messageId);
        Task<Task> UpdateMessage(Message message);
        Task<Task> RemoveMessage(int messageId);
        
        Task<Task> AddFriendship(int userId,int friendUserId, bool closeFriend);
        Task<Task> RemoveFriend(int friendshipId);
        Task<Friendship> GetFriendship(int friendshipId);
        
        
        Task<Task> CreateGroup(string groupCreator);
        Task<Task> UpdateGroup(GroupChat groupChat);
        
        Task<Task> AddParticipant(Participant participant);
        Task<Task> RemoveParticipant(int participantId);

        Task<Task> ForwardMessage(Message message,int forwardedMessageId);
        Task<Task> PinMessage(int messageId);
    }
}