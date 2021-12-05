using System.Linq;
using DataAccess.Persistence;
using Domain.Data;
using Entities;

namespace DataAccess.Data
{
    public class DatabaseDataHandler:IDataRepo
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
    }
}