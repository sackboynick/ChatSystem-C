using System;
using System.Collections.Generic;
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
            var chatContext = new ChatContext();

            if (message.ReceiverUsername != null || message.PrivateChatId!=null )
            {
                if (chatContext.PrivateChats.FirstOrDefault(chat =>
                        chat.Participant1 == message.SenderUsername && chat.Participant2 == message.ReceiverUsername) ==
                    null)
                {

                    if (chatContext.PrivateChats.FirstOrDefault(chat =>
                            chat.Participant1 == message.ReceiverUsername &&
                            chat.Participant2 == message.SenderUsername) == null)
                    {
                        PrivateChat chat = new PrivateChat(message.SenderUsername, message.ReceiverUsername);
                        Message newMess = new Message(message.SenderUsername, message.ReceiverUsername, message.Text,
                            chatContext.PrivateChats.Count() + 1);
                        chat.Messages.Add(newMess);
                        chatContext.PrivateChats.Add(chat);
                    }
                    else
                    {

                        chatContext.Messages.Add(message);
                    }

                }
                else
                {

                    chatContext.Messages.Add(message);
                    //chatContext.PrivateChats.First(chat => chat.Participant1 == message.SenderUsername & chat.Participant2 == message.ReceiverUsername).Messages.Add(message);
                }
            }
            else
            {
                chatContext.Messages.Add(message);
            }

            chatContext.SaveChanges();
        }


        public PrivateChat GetPrivateChat(int chatId)
        {
            var chatContext = new ChatContext();

            return chatContext.PrivateChats.Include(m=> m.Messages).ToList().FirstOrDefault(chat => chat.Id == chatId);
        }

        public GroupChat GetGroupChat(int chatId)
        {
            var chatContext = new ChatContext();

            return chatContext.GroupChats.Include(m=> m.Messages).Include(m=> m.Participants).First(chat => chat.Id == chatId);
        }

        public void CreateGroup(GroupChat groupChat)
        {
            var chatContext = new ChatContext();

            chatContext.GroupChats.Add(groupChat);
            chatContext.SaveChanges();
        }




        public void RemoveFriend(int friendshipId)
        {
            var chatContext = new ChatContext();

            chatContext.Friendships.Remove(chatContext.Friendships.Find(friendshipId));
            chatContext.SaveChanges();
        }

        public Message GetMessage(int messageId)
        {
            var chatContext = new ChatContext();
            
            return chatContext.Messages.Find(messageId);
            
        }

        public void RemoveMessage(int messageId)
        {
            var chatContext = new ChatContext();

            chatContext.Messages.Remove(chatContext.Messages.Find(messageId));
            chatContext.SaveChanges();
        }

        public Participant GetParticipant(int participantId)
        {
            var chatContext = new ChatContext();

            return chatContext.Participants.Find(participantId);
        }

        public void AddParticipant(Participant participant)
        {
            var chatContext = new ChatContext();

            chatContext.Participants.Add(participant);
            chatContext.SaveChanges();
        }

        public void UpdateParticipant(Participant participant)
        {
            var chatContext = new ChatContext();

            chatContext.Participants.Update(participant);
            chatContext.SaveChanges();
        }

        public void RemoveParticipant(int participantId)
        {
            var chatContext = new ChatContext();

            chatContext.Participants.Remove(chatContext.Participants.Find(participantId));
            chatContext.SaveChanges();
        }

        public void UpdateMessage(Message message)
        {
            var chatContext = new ChatContext();

            chatContext.Messages.Update(message);
            chatContext.SaveChanges();
        }

        public Friendship GetFriendship(int friendshipId)
        {
            var chatContext = new ChatContext();
            return chatContext.Friendships.Find(friendshipId);
        }


        public User GetUser(int usernameId)
        {
            var chatContext = new ChatContext();
            return chatContext.Users.Find(usernameId);
        }

        public void AddFriendship(Friendship friendship)
        {
            var chatContext = new ChatContext();

            chatContext.Friendships.Add(friendship);

            chatContext.SaveChanges();
        }

        public void UpdateFriendship(Friendship friendship)
        {
            var chatContext = new ChatContext();

            chatContext.Friendships.Update(friendship);
            chatContext.SaveChanges();
        }

        public List<Friendship> GetFriendshipsList()
        {
            var chatContext = new ChatContext();

            return chatContext.Friendships.ToList();
        }

        public List<User> GetUsersList()
        {
            
            var chatContext = new ChatContext();

            return chatContext.Users.Include(m => m.Friends).ToList();
        }

        public User GetUserFromUsername(string username)
        {
            var chatContext = new ChatContext();

            return chatContext.Users.FirstOrDefault(user => user.Username == username);
        }

        public void RemoveUser(int userId)
        {
            var chatContext = new ChatContext();
            chatContext.Users.Remove(chatContext.Users.Find(userId));
            chatContext.SaveChanges();
        }

        public List<PrivateChat> GetPrivateChats()
        {
            var chatContext = new ChatContext();

            return chatContext.PrivateChats.Include(m=> m.Messages).ToList();
        }

        public List<GroupChat> GetGroupChats()
        {
            var chatContext = new ChatContext();

            return chatContext.GroupChats.Include(m=> m.Messages).Include(m=> m.Participants).ToList();
        }

        public List<Message> GetMessages()
        {
            var chatContext = new ChatContext();

            return chatContext.Messages.ToList();
        }

        public List<Participant> GetParticipants()
        {
            var chatContext = new ChatContext();

            return chatContext.Participants.ToList();
        }

        public void AddPrivateChat(PrivateChat privateChat)
        {
            using ChatContext chatContext = new ChatContext();

            chatContext.PrivateChats.Add(privateChat);
            chatContext.SaveChanges();
        }


        public void UpdateUser(User user)
        {
            var chatContext = new ChatContext();

            chatContext.Users.Update(user);
            chatContext.SaveChanges();
        }
    }
}