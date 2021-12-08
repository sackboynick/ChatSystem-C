using System;
using System.Linq;
using DataAccess.Persistence;
using Domain.Data;
using Entities;
using Microsoft.EntityFrameworkCore;

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

            return chatContext.PrivateChats.Include(m=> m.Messages).ToList().FirstOrDefault(chat => chat.Id == chatId);
        }

        public GroupChat GetGroupChat(int chatId)
        {
            using ChatContext chatContext = new ChatContext();

            return chatContext.GroupChats.Include(m=> m.Messages).Include(m=> m.Participants).First(chat => chat.Id == chatId);
        }

        public void CreateGroup(GroupChat groupChat)
        {
            using ChatContext chatContext = new ChatContext();

            chatContext.GroupChats.Add(groupChat);
            chatContext.SaveChanges();
        }

        public void UpdateGroup(GroupChat groupChat)
        {
            using ChatContext chatContext = new ChatContext();

            chatContext.GroupChats.Update(groupChat);
            chatContext.SaveChanges();
        }
        

        public User GetUser(string username)
        {
            using ChatContext chatContext = new ChatContext();

            return chatContext.Users.Include(m=> m.Friends).FirstOrDefault(user => user.Username == username);
        }

        public void AddFriendship(Friendship friendship)
        {
            using ChatContext chatContext = new ChatContext();

            
            chatContext.Friendships.Add(friendship);

            chatContext.SaveChanges();
        }
        
    }
}