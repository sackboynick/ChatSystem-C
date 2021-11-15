using System.Collections.Generic;

namespace Entities
{
    public class ChatList {
        private List<Chat> chats;

        public ChatList(){
            this.chats=new List<Chat>();
        }

        public List<Chat> getChats() {
            return chats;
        }
    }
}