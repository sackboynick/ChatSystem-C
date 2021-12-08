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

        void ForwardMessage(Message message, Entities.User user);

        void RemoveFriend(int friendshipId);

        Message GetMessage(int messageId);
        void RemoveMessage(int messageId);

        Participant GetParticipant(int participantId);
        void AddParticipant(Participant participant);
        void UpdateParticipant(Participant participant);
        void RemoveParticipant(int participantId);
        void UpdateMessage(Message message);
        Friendship GetFriendship(int friendshipId);
        void AddFriendship(Friendship friendship);
        void UpdateFriendship(Friendship friendship);
    }
}