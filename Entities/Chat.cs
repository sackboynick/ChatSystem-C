using System.Collections.Generic;

namespace Entities
{
    public class Chat {
        private readonly List<Message> _messages;

        public Chat(){
            this._messages=new List<Message>();
        }

        public List<Message> GetMessages() {
            return _messages;
        }
    }
}