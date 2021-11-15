using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Chat {
        [Required]
        [JsonPropertyName("messages")]
        private readonly List<Message> _messages;

        public Chat(){
            this._messages=new List<Message>();
        }

        public List<Message> GetMessages() {
            return _messages;
        }
    }
}