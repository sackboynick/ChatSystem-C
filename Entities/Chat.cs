using System.Collections.Generic;

namespace Entities
{
    public class Chat {
        private List<Message> messages;

        public Chat(){
            this.messages=new List<Message>();
        }

        public List<Message> GetMessages() {
            return messages;
        }
    }
}