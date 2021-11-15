using System.Collections.Generic;

namespace Entities
{
    public class PrivateChat:Chat
    {
        private string sender, receiver;

        public PrivateChat(string sender,string receiver){
            this.sender=sender;
            this.receiver=receiver;
        }

        public string GetReceiver() {
            return receiver;
        }

        public string GetSender() {
            return sender;
        }

        public List<Message> GetMessages() {
            return base.GetMessages();
        }
    }
}