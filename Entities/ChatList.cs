using System.Collections.Generic;

namespace Entities
{
    public class ChatList {
        private readonly List<Chat> chats;

        public ChatList(){
            this.chats=new List<Chat>();
        }

        public List<Chat> GetChats() {
            return chats;
        }
    }
}