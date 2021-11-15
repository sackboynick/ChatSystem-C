using System;

namespace Entities
{
    public class Message
    {
        private readonly string _senderUsername;
        private readonly DateTime _localDateTime;
        private readonly string text;

        public Message(String senderUsername,String text){
            this._senderUsername=senderUsername;
            this._localDateTime=DateTime.Now;
            this.text=text;
        }

        public String GetText() {
            return text;
        }

        public String GetSenderUsername() {
            return _senderUsername;
        }

        public DateTime GetLocalDateTime() {
            return _localDateTime;
        }
    }
}