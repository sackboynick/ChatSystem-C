using Entities;

namespace Domain.Data
{
    public interface IDataRepo
    {
        public void SendMessage(Message message);
        public PrivateChat GetPrivateChat(int chatId);
        public GroupChat GetGroupChat(int chatId);
        public void CreateGroup(GroupChat groupChat);

        public void UpdateGroup(GroupChat groupChat);


        Message GetMessage(int messageId);
    }
}