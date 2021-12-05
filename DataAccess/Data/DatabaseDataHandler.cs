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
            using ChatContext chatContext = new ChatContext();

            
            if(chatContext.Chats.First(chat => chat.Sender == message.SenderUsername & chat.Receiver == message.ReceiverUsername)==null)
            {
                Chat chat = new Chat(message.SenderUsername,message.ReceiverUsername);
                chat.Messages.Add(message);
                chatContext.Chats.Add(chat);
            }
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