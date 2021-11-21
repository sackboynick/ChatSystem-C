using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class ChatList {
        [Required]
        [JsonPropertyName("username")]
        private readonly ICollection<Chat> chats;

        public ChatList(){
            this.chats=new List<Chat>();
        }

        public ICollection<Chat> GetChats() {
            return chats;
        }
    }
}