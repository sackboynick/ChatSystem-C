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

        private ChatContext chatContext;

        public DatabaseDataHandler(ChatContext _chatContext)
        {
            chatContext = _chatContext;
        }
        
        public void SendMessage(Message message)
        {

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

            return chatContext.PrivateChats.Include(m=> m.Messages).ToList().FirstOrDefault(chat => chat.Id == chatId);
        }

        public GroupChat GetGroupChat(int chatId)
        {

            return chatContext.GroupChats.Include(m=> m.Messages).Include(m=> m.Participants).First(chat => chat.Id == chatId);
        }

        public void CreateGroup(GroupChat groupChat)
        {

            chatContext.GroupChats.Add(groupChat);
            chatContext.SaveChanges();
        }




        public void RemoveFriend(int friendshipId)
        {

            chatContext.Friendships.Remove(chatContext.Friendships.Find(friendshipId));
            chatContext.SaveChanges();
        }

        public Message GetMessage(int messageId)
        {
            
            return chatContext.Messages.Find(messageId);
            
        }

        public void RemoveMessage(int messageId)
        {

            chatContext.Messages.Remove(chatContext.Messages.Find(messageId));
            chatContext.SaveChanges();
        }

        public Participant GetParticipant(int participantId)
        {

            return chatContext.Participants.Find(participantId);
        }

        public void AddParticipant(Participant participant)
        {

            chatContext.Participants.Add(participant);
            chatContext.SaveChanges();
        }

        public void UpdateParticipant(Participant participant)
        {

            chatContext.Participants.Update(participant);
            chatContext.SaveChanges();
        }

        public void RemoveParticipant(int participantId)
        {

            chatContext.Participants.Remove(chatContext.Participants.Find(participantId));
            chatContext.SaveChanges();
        }

        public void UpdateMessage(Message message)
        {

            chatContext.Messages.Update(message);
            chatContext.SaveChanges();
        }

        public Friendship GetFriendship(int friendshipId)
        {
            return chatContext.Friendships.Find(friendshipId);
        }


        public User GetUser(int usernameId)
        {
            return chatContext.Users.Find(usernameId);
        }

        public void AddFriendship(Friendship friendship)
        {

            chatContext.Friendships.Add(friendship);

            chatContext.SaveChanges();
        }

        public void UpdateFriendship(Friendship friendship)
        {

            chatContext.Friendships.Update(friendship);
            chatContext.SaveChanges();
        }

        public List<Friendship> GetFriendshipsList()
        {

            return chatContext.Friendships.ToList();
        }

        public List<User> GetUsersList()
        {

            return chatContext.Users.Include(m => m.Friends).ToList();
        }

        public User GetUserFromUsername(string username)
        {

            return chatContext.Users.FirstOrDefault(user => user.Username == username);
        }

        public void RemoveUser(int userId)
        {
            chatContext.Users.Remove(chatContext.Users.Find(userId));
            chatContext.SaveChanges();
        }

        public List<PrivateChat> GetPrivateChats()
        {

            return chatContext.PrivateChats.Include(m=> m.Messages).ToList();
        }

        public List<GroupChat> GetGroupChats()
        {

            return chatContext.GroupChats.Include(m=> m.Messages).Include(m=> m.Participants).ToList();
        }

        public List<Message> GetMessages()
        {

            return chatContext.Messages.ToList();
        }

        public List<Participant> GetParticipants()
        {

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

            chatContext.Users.Update(user);
            chatContext.SaveChanges();
        }
    }
}