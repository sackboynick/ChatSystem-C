using Entities;

namespace Domain.Data
{
    public interface IDataRepo
    {
        void SendMessage(Message message);
        PrivateChat GetPrivateChat(int chatId);
        GroupChat GetGroupChat(int chatId);
        void CreateGroup(GroupChat groupChat);
        void UpdateGroup(GroupChat groupChat);

        void RemoveGroup(GroupChat groupChat);

        void PinMessage(Message message);

        void ReplyMessage(Message message);

        void ForwardMessage(Message message, Entities.User user);

        void RemoveFriend(string username);

        void RemoveMessage(Message message);

    }
}