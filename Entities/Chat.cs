using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Chat {
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("messages")]
        public ICollection<Message> _messages { get; set; }

        public Chat(){
            _messages=new List<Message>();
        }
        
    }
}