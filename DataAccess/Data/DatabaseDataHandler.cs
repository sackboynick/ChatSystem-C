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

        private readonly ChatContext _chatContext;

        public DatabaseDataHandler()
        {
            _chatContext = new ChatContext();
        }
        
        public void SendMessage(Message message)
        {

            using ChatContext chatContext = new ChatContext();
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

            return _chatContext.PrivateChats.Include(m=> m.Messages).ToList().FirstOrDefault(chat => chat.Id == chatId);
        }

        public GroupChat GetGroupChat(int chatId)
        {

            return _chatContext.GroupChats.Include(m=> m.Messages).Include(m=> m.Participants).First(chat => chat.Id == chatId);
        }

        public void CreateGroup(GroupChat groupChat)
        {

            _chatContext.GroupChats.Add(groupChat);
            _chatContext.SaveChanges();
        }




        public void RemoveFriend(int friendshipId)
        {

            _chatContext.Friendships.Remove(_chatContext.Friendships.Find(friendshipId));
            _chatContext.SaveChanges();
        }

        public Message GetMessage(int messageId)
        {
            
            return _chatContext.Messages.Find(messageId);
            
        }

        public void RemoveMessage(int messageId)
        {

            _chatContext.Messages.Remove(_chatContext.Messages.Find(messageId));
            _chatContext.SaveChanges();
        }

        public Participant GetParticipant(int participantId)
        {

            return _chatContext.Participants.Find(participantId);
        }

        public void AddParticipant(Participant participant)
        {

            _chatContext.Participants.Add(participant);
            _chatContext.SaveChanges();
        }

        public void UpdateParticipant(Participant participant)
        {

            _chatContext.Participants.Update(participant);
            _chatContext.SaveChanges();
        }

        public void RemoveParticipant(int participantId)
        {

            _chatContext.Participants.Remove(_chatContext.Participants.Find(participantId));
            _chatContext.SaveChanges();
        }

        public void UpdateMessage(Message message)
        {

            _chatContext.Messages.Update(message);
            _chatContext.SaveChanges();
        }

        public Friendship GetFriendship(int friendshipId)
        {
            return _chatContext.Friendships.Find(friendshipId);
        }


        public User GetUser(int usernameId)
        {
            return _chatContext.Users.Find(usernameId);
        }

        public void AddFriendship(Friendship friendship)
        {

            _chatContext.Friendships.Add(friendship);

            _chatContext.SaveChanges();
        }

        public void UpdateFriendship(Friendship friendship)
        {

            _chatContext.Friendships.Update(friendship);
            _chatContext.SaveChanges();
        }

        public List<Friendship> GetFriendshipsList()
        {

            return _chatContext.Friendships.ToList();
        }

        public List<User> GetUsersList()
        {

            return _chatContext.Users.Include(m => m.Friends).ToList();
        }

        public User GetUserFromUsername(string username)
        {

            return _chatContext.Users.FirstOrDefault(user => user.Username == username);
        }

        public void RemoveUser(int userId)
        {
            _chatContext.Users.Remove(_chatContext.Users.Find(userId));
            _chatContext.SaveChanges();
        }

        public List<PrivateChat> GetPrivateChats()
        {

            return _chatContext.PrivateChats.Include(m=> m.Messages).ToList();
        }

        public List<GroupChat> GetGroupChats()
        {

            return _chatContext.GroupChats.Include(m=> m.Messages).Include(m=> m.Participants).ToList();
        }

        public List<Message> GetMessages()
        {

            return _chatContext.Messages.ToList();
        }

        public List<Participant> GetParticipants()
        {

            return _chatContext.Participants.ToList();
        }

        public void AddPrivateChat(PrivateChat privateChat)
        {
            using ChatContext chatContext = new ChatContext();

            chatContext.PrivateChats.Add(privateChat);
            chatContext.SaveChanges();
        }


        public void UpdateUser(User user)
        {

            _chatContext.Users.Update(user);
            _chatContext.SaveChanges();
        }
    }
}