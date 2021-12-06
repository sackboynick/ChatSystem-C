using Entities;

namespace Domain.Data
{
    public interface IDataRepo
    {
        public void SendMessage(Message message);
        public PrivateChat GetPrivateChat(int chatId);
        public GroupChat GetGroupChat(int chatId);
        public void CreateGroup(string groupCreator);

        public void UpdateGroup(GroupChat groupChat);
        /*
        public void AddParticipantToGroup(int groupId, string userToAdd);
        public void RemoveParticipantFromGroup(int groupId, string userToRemove);
        public void PromoteParticipantToAdmin(int groupId, string userToPromote);**/

    }
}