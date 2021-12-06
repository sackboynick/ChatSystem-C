using System;
using System.Linq;
using DataAccess.Persistence;
using Domain.Data;
using Entities;

namespace DataAccess.Data
{
    public class DatabaseDataHandler:IDataRepo,IUserRepo
    {
        public void SendMessage(Message message)
        {
            using var chatContext = new ChatContext();

            if(chatContext.PrivateChats.FirstOrDefault(chat => chat.Participant1==message.SenderUsername && chat.Participant2==message.ReceiverUsername)==null)
            {
                if (chatContext.PrivateChats.FirstOrDefault(chat =>
                    chat.Participant1 == message.ReceiverUsername && chat.Participant2 == message.SenderUsername) == null)
                {
                    PrivateChat chat = new PrivateChat(message.SenderUsername, message.ReceiverUsername);
                    Message newMess = new Message(message.SenderUsername, message.ReceiverUsername, message.Text);
                    chat.Messages.Add(newMess);
                    chatContext.PrivateChats.Add(chat);
                }
            }
            else
            {
                chatContext.PrivateChats.First(chat => chat.Participant1 == message.SenderUsername & chat.Participant2 == message.ReceiverUsername).Messages.Add(message);
            }
            chatContext.SaveChanges();
        }


        public PrivateChat GetPrivateChat(int chatId)
        {
            using ChatContext chatContext = new ChatContext();

            return chatContext.PrivateChats.FirstOrDefault(chat => chat.Id == chatId);
        }

        public GroupChat GetGroupChat(int chatId)
        {
            using ChatContext chatContext = new ChatContext();

            return chatContext.GroupChats.FirstOrDefault(chat => chat.Id == chatId);
        }

        public void CreateGroup(string groupCreator)
        {
            using ChatContext chatContext = new ChatContext();

            chatContext.GroupChats.Add(new GroupChat(groupCreator));
            chatContext.SaveChanges();
        }

        public void AddParticipantToGroup(int groupId, string userToAdd)
        {
            using ChatContext chatContext = new ChatContext();

            GetGroupChat(groupId).Participants.Add(new Participant(userToAdd,false));

            chatContext.SaveChanges();

        }

        public void RemoveParticipantFromGroup(int groupId, string userToRemove)
        {
            using ChatContext chatContext = new ChatContext();

            GetGroupChat(groupId).Participants.Remove( GetGroupChat(groupId).Participants.First(participant => participant.Username==userToRemove));

            chatContext.SaveChanges();
        }

        public void PromoteParticipantToAdmin(int groupId, string userToPromote)
        {
            using ChatContext chatContext = new ChatContext();

            GetGroupChat(groupId).Participants.First(participant => participant.Username==userToPromote).Admin=true;

            chatContext.SaveChanges();
        }

        public User GetUser(string username)
        {
            using ChatContext chatContext = new ChatContext();

            return chatContext.Users.FirstOrDefault(user => user.Username == username);
        }

        public void AddFriend(string username, string friendToAdd,bool closeFriend)
        {
            using ChatContext chatContext = new ChatContext();
            if(chatContext.Users.FirstOrDefault(user => user.Username==username)!=null)
                chatContext.Users.First(user => user.Username==username).AddFriend(friendToAdd,closeFriend);
            chatContext.SaveChanges();
        }
    }
}